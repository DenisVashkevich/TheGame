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
	public class Map : IMessageHandler<TryToMoveMonsterMessage>, IMessageHandler<TryToMovePlayerMessage>
	{
		private readonly Dictionary<uint, OnMapPosition> _creaturesPositions;
		private readonly Dictionary<uint, OnMapPosition> _itemsPositions;
		//private OnMapPosition _playerPosition;
		private readonly MapTileBase[,] _tileMap;
		private readonly Dictionary<Type, MapTileBase> _tilesDictionary; 

		public Map()
		{
			_tileMap = new MapTileBase[Defines.Map.MAP_HEIGHT, Defines.Map.MAP_WIDTH];
			_creaturesPositions = new Dictionary<uint, OnMapPosition>();
			_itemsPositions = new Dictionary<uint, OnMapPosition>();
			//_playerPosition = new OnMapPosition();
			_tilesDictionary = new Dictionary<Type, MapTileBase>();

			EventManager.Subscribe<TryToMoveMonsterMessage>(this);
			EventManager.Subscribe<TryToMovePlayerMessage>(this);
		}

		public bool TryToAddMonster(uint monsterId, uint xPos, uint yPos)
		{
			var monsterPos = new OnMapPosition() {XPos = xPos, YPos = yPos};

			if (_creaturesPositions.ContainsValue(monsterPos))
			{
				return false;
			}

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

			if (!_tilesDictionary.ContainsKey(typeof (T)))
			{
				_tilesDictionary.Add(typeof(T), new T());
			}

			var tile = _tilesDictionary[typeof (T)];

			for (var i = 0; i <= regionHeight - 1; i++)
			{
				for (var j = 0; j <= regionWidth - 1; j++)
				{
					_tileMap[yPos + i, xPos + j] = tile;
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
					if (curentCreaturePosition.XPos + 1 < Defines.Map.MAP_WIDTH)
					{
						var newCreaturePosition = new OnMapPosition()
						{
							XPos = curentCreaturePosition.XPos + 1,
							YPos = curentCreaturePosition.YPos
						};

						var ocupiedCreatureId = _creaturesPositions.Where(kv => kv.Value.Equals(newCreaturePosition)).Select(kv => kv.Key).First();

						return new MapTileInfo()
						{
							CostToMoveOn = _tileMap[newCreaturePosition.YPos, newCreaturePosition.XPos].MovesCostToMoveOnTile,
							CreatureId = ocupiedCreatureId,
							TerrainType = _tileMap[newCreaturePosition.YPos, newCreaturePosition.XPos].TerrainType
						};
					}

					return null;

					break;

				case MoveDirection.NORTH:
					if ((int)curentCreaturePosition.YPos - 1 >= 0)
					{
						var newCreaturePosition = new OnMapPosition()
						{
							XPos = curentCreaturePosition.XPos,
							YPos = curentCreaturePosition.YPos - 1
						};

						var ocupiedCreatureId = _creaturesPositions.Where(kv => kv.Value.Equals(newCreaturePosition)).Select(kv => kv.Key).First();

						return new MapTileInfo()
						{
							CostToMoveOn = _tileMap[newCreaturePosition.YPos, newCreaturePosition.XPos].MovesCostToMoveOnTile,
							CreatureId = ocupiedCreatureId,
							TerrainType = _tileMap[newCreaturePosition.YPos, newCreaturePosition.XPos].TerrainType
						};
					}

					return null;

					break;
				case MoveDirection.SOUTH:
					if (curentCreaturePosition.YPos + 1 < Defines.Map.MAP_HEIGHT)
					{
						var newCreaturePosition = new OnMapPosition()
						{
							XPos = curentCreaturePosition.XPos,
							YPos = curentCreaturePosition.YPos + 1
						};

						var ocupiedCreatureId = _creaturesPositions.Where(kv => kv.Value.Equals(newCreaturePosition)).Select(kv => kv.Key).First();

						return new MapTileInfo()
						{
							CostToMoveOn = _tileMap[newCreaturePosition.YPos, newCreaturePosition.XPos].MovesCostToMoveOnTile,
							CreatureId = ocupiedCreatureId,
							TerrainType = _tileMap[newCreaturePosition.YPos, newCreaturePosition.XPos].TerrainType
						};
					}

					return null;

					break;
				case MoveDirection.WEST:
					if ((int)curentCreaturePosition.XPos - 1 >= 0)
					{
						var newCreaturePosition = new OnMapPosition()
						{
							XPos = curentCreaturePosition.XPos -1,
							YPos = curentCreaturePosition.YPos
						};

						var ocupiedCreatureId = _creaturesPositions.Where(kv => kv.Value.Equals(newCreaturePosition)).Select(kv => kv.Key).First();

						return new MapTileInfo()
						{
							CostToMoveOn = _tileMap[newCreaturePosition.YPos, newCreaturePosition.XPos].MovesCostToMoveOnTile,
							CreatureId = ocupiedCreatureId,
							TerrainType = _tileMap[newCreaturePosition.YPos, newCreaturePosition.XPos].TerrainType
						};
					}

					return null;

					break;
			}

			return null;
		}

		private OnMapPosition GetMonsterPosition(uint creatureId)
		{
			return _creaturesPositions[creatureId];
		}

		public void Handle(TryToMoveMonsterMessage message)
		{
			throw new NotImplementedException();
		}

		public void Handle(TryToMovePlayerMessage message)
		{
			OnMapPosition newPosition;

			switch (message.Direction)
			{
				case MoveDirection.EAST:
					//if (_playerPosition.XPos + 1 < Defines.Map.MAP_WIDTH)
					//{
					//	newPosition = new OnMapPosition() {XPos = _playerPosition.XPos + 1, YPos = _playerPosition.YPos};

					//	if (!_creaturesPositions.ContainsValue(newPosition))
					//	{
							
					//	}
					//}
					
					break;
				case MoveDirection.NORTH:
					break;
				case MoveDirection.SOUTH:
					break;
				case MoveDirection.WEST:
					break;
			}

		}
	}
}