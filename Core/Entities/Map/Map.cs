using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities.ConsumableObjects;
using Core.Entities.Creatures;
using Core.Entities.Map.Tiles;
using Core.Services.EventManager;
using Core.Services.EventManager.Messages;

namespace Core.Entities.Map
{
	public class Map : IMessageHandler<MoveCreatureMessage>, IMessageHandler<ItemConsumedMessage>
	{
		private readonly Dictionary<uint, OnMapPosition> _creaturesPositions;
		private readonly Dictionary<uint, OnMapPosition> _itemsPositions;
		private readonly MapTileBase[,] _tileMap;

		public Map()
		{
			_tileMap = new MapTileBase[Defines.Map.MAP_HEIGHT, Defines.Map.MAP_WIDTH];
			_creaturesPositions = new Dictionary<uint, OnMapPosition>();
			_itemsPositions = new Dictionary<uint, OnMapPosition>();

			EventManager.Subscribe<MoveCreatureMessage>(this);
		}

		public bool TryToAddMonster(uint monsterId, uint xPos, uint yPos)
		{
			var monsterPos = new OnMapPosition() {XPos = xPos, YPos = yPos};

			if (_creaturesPositions.ContainsValue(monsterPos))
			{
				return false;
			}

			//TODO: implement check for mapTile passability

			_creaturesPositions.Add(monsterId, monsterPos);

			return true;
		}

		public bool TryToAddItem(uint itemId, uint xPos, uint yPos)
		{
			var itemPos = new OnMapPosition() {XPos = xPos, YPos = yPos};

			if (_itemsPositions.ContainsValue(itemPos))
			{
				return false;
			}

			//TODO: implement check for mapTile passability only for land creatures

			_itemsPositions.Add(itemId, itemPos);

			return true;
		}

		public bool TryToCreateRectangularMapRegion<T>(
			uint xPos,
			uint yPos,
			uint regionWidth,
			uint regionHeight) where T : MapTileBase, new()
		{
			if ((xPos + regionWidth > Defines.Map.MAP_WIDTH) || (yPos + regionHeight > Defines.Map.MAP_HEIGHT) ||
			    regionWidth == 0 || regionHeight == 0)
			{
				return false;
			}

			for (var i = 0; i <= regionHeight - 1; i++)
			{
				for (var j = 0; j <= regionWidth - 1; j++)
				{
					_tileMap[yPos + i, xPos + j] = new T();
				}
			}

			return true;
		}

		public bool ValidateMap()
		{
			return _tileMap.Cast<MapTileBase>().All(tile => tile != null);
		}

		public void GenerateDefaultMap()
		{
			TryToCreateRectangularMapRegion<GrassTile>(0, 0, 21, 24);
			TryToCreateRectangularMapRegion<ForestTile>(4, 0, 5, 4);
			TryToCreateRectangularMapRegion<ForestTile>(7, 4, 2, 16);
			TryToCreateRectangularMapRegion<WaterTile>(4, 4, 3, 16);
			TryToCreateRectangularMapRegion<ForestTile>(12, 4, 2, 2);
			TryToCreateRectangularMapRegion<ForestTile>(13, 12, 3, 9);
			TryToCreateRectangularMapRegion<ForestTile>(16, 12, 3, 4);
			TryToCreateRectangularMapRegion<RockTile>(17, 5, 4, 4);
			TryToCreateRectangularMapRegion<RockTile>(19, 9, 2, 6);
			TryToCreateRectangularMapRegion<DesertTile>(19, 15, 2, 4);
			TryToCreateRectangularMapRegion<DesertTile>(21, 5, 3, 19);
			TryToCreateRectangularMapRegion<ForestTile>(21, 0, 3, 5);
			TryToCreateRectangularMapRegion<RockTile>(22, 21, 2, 3);
		}

		public MapTileInfo GetAdjoiningLocationInfo(uint creatureId, MoveDirection direction)
		{
			var curentCreaturePosition = _creaturesPositions[creatureId];

			if (curentCreaturePosition == null)
			{
				return null;
			}

			switch (direction)
			{
				case MoveDirection.EAST:
					return GetTileInfo((int)curentCreaturePosition.XPos + 1, (int)curentCreaturePosition.YPos);
					break;

				case MoveDirection.NORTH:
					return GetTileInfo((int)curentCreaturePosition.XPos + 1, (int)curentCreaturePosition.YPos - 1);
					break;

				case MoveDirection.SOUTH:
					return GetTileInfo((int)curentCreaturePosition.XPos, (int)curentCreaturePosition.YPos + 1);
					break;

				case MoveDirection.WEST:
					return GetTileInfo((int)curentCreaturePosition.XPos - 1, (int)curentCreaturePosition.YPos);
					break;
			}

			return null;
		}

		private MapTileInfo GetTileInfo(int x, int y)
		{
			if (x >= Defines.Map.MAP_WIDTH || y >= Defines.Map.MAP_HEIGHT)
			{
				return null;
			}

			var newPosition = new OnMapPosition()
			{
				XPos = (uint)x,
				YPos = (uint)y 
			};

			var ocupiedCreatureId = _creaturesPositions.Where(kv => kv.Value.Equals(newPosition)).Select(kv => kv.Key).FirstOrDefault();

			return new MapTileInfo()
			{
				CostToMoveOn = _tileMap[y, x].MovesCostToMoveOnTile,
				CreatureId = ocupiedCreatureId
			};
		}

		private OnMapPosition GetMonsterPosition(uint creatureId)
		{
			return _creaturesPositions[creatureId];
		}

		public void Handle(MoveCreatureMessage message)
		{
			switch (message.Direction)
			{
				case MoveDirection.EAST:
					_creaturesPositions[message.CreatureId].XPos += 1;
					break;
				case MoveDirection.NORTH:
					_creaturesPositions[message.CreatureId].YPos -= 1;
					break;
				case MoveDirection.SOUTH:
					_creaturesPositions[message.CreatureId].YPos += 1;
					break;
				case MoveDirection.WEST:
					_creaturesPositions[message.CreatureId].XPos -= 1;
					break;
			}

			var itemId = _itemsPositions.Where(kv => kv.Value.Equals(_creaturesPositions[message.CreatureId])).Select(kv => kv.Key).First();

			if (itemId != 0)
			{
				EventManager.Raise(new ConsumableItemFoundMessage() {ItemId = itemId});
			}
		}

		public void Handle(ItemConsumedMessage message)
		{
			_itemsPositions.Remove(message.ItemId);
		}
	}
}