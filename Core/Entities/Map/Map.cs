using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities.ConsumableObjects;
using Core.Entities.Creatures;
using Core.Entities.Map.Tiles;

namespace Core.Entities.Map
{
	public class Map
	{
		private readonly CreatureBase[,] _creaturesMap;
		private readonly ConsumableItemBase[,] _itemsMap;
		private readonly MapTileBase[,] _tileMap;
		private readonly Dictionary<Type, MapTileBase> _tilesDictionary; 

		public Map()
		{
			_tileMap = new MapTileBase[Defines.Map.MAP_HEIGHT, Defines.Map.MAP_WIDTH];
			_creaturesMap = new CreatureBase[Defines.Map.MAP_HEIGHT, Defines.Map.MAP_WIDTH];
			_itemsMap = new ConsumableItemBase[Defines.Map.MAP_HEIGHT, Defines.Map.MAP_WIDTH];
			_tilesDictionary = new Dictionary<Type, MapTileBase>();
		}

		public bool TryToAddMonster(Monster monster, uint xPos, uint yPos)
		{
			if (_creaturesMap[yPos, xPos] != null)
			{
				return false;
			}

			_creaturesMap[yPos, xPos] = monster;

			return true;
		}

		public bool TryToAddItem(ConsumableItemBase item, uint xPos, uint yPos)
		{
			if (_itemsMap[yPos, xPos] != null)
			{
				return false;
			}

			_itemsMap[yPos, xPos] = item;

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

		public MapTileBase GetAdjoiningTile(MapTileBase baseTile, MoveDirection direction)
		{
			if (baseTile == null)
			{
				return null;
			}

			switch (direction)
			{
				case MoveDirection.EAST:
					break;
				case MoveDirection.NORTH:
					break;
				case MoveDirection.SOUTH:
					break;
				case MoveDirection.WEST:
					break;
			}

			return null;
		}
	}
}