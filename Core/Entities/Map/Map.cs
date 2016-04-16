using System.Collections.Generic;
using System.Linq;
using Core.Entities.ConsumableObjects;
using Core.Entities.Creatures;

namespace Core.Entities.Map
{
	public class Map
	{
		private readonly Dictionary<MapTileBase, CreatureBase> _creaturesPositions;
		private readonly Dictionary<MapTileBase, ConsumableItemBase> _itemsPositions;
		private MapTileBase[,] _tileMap = new MapTileBase[Defines.Map.MAP_WIDTH, Defines.Map.MAP_HEIGHT];

		public Map()
		{
			_creaturesPositions = new Dictionary<MapTileBase, CreatureBase>();
			_itemsPositions = new Dictionary<MapTileBase, ConsumableItemBase>();
		}

		public bool TryToAddCreature(CreatureBase creature, MapTileBase position)
		{
			if (!_creaturesPositions.ContainsKey(position))
			{
				_creaturesPositions.Add(position, creature);
				return true;
			}

			return false;
		}

		public bool TryToAddItem(ConsumableItemBase item, MapTileBase position)
		{
			if (!_itemsPositions.ContainsKey(position))
			{
				_itemsPositions.Add(position, item);
				return true;
			}

			return false;
		}

		public bool TryToCreateRectangularMapRegion(uint xPos, uint yPos, uint regionWidth, uint regionHeight, MapTileBase tile)
		{
			if ((xPos + regionWidth > Defines.Map.MAP_WIDTH) || (yPos + regionHeight > Defines.Map.MAP_HEIGHT) ||
			    regionWidth == 0 || regionHeight == 0 || tile == null)
			{
				return false;
			}

			for (var i = 0; i <= regionWidth - 1; i++)
			{
				for (var j = 0; j <= regionHeight - 1; j++)
				{
					_tileMap[xPos + i,yPos + j] = tile;
				}
			}

			return true;
		}

		public bool ValidateMap()
		{
			return _tileMap.Cast<MapTileBase>().Any(tile => tile == null);
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