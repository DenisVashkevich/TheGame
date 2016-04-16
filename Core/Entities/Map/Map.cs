using System.Linq;
using Core.Entities.ConsumableObjects;
using Core.Entities.Creatures;

namespace Core.Entities.Map
{
	public class Map
	{
		private readonly CreatureBase[,] _creaturesMap;
		private readonly ConsumableItemBase[,] _itemsMap;
		private readonly MapTileBase[,] _tileMap;

		public Map()
		{
			_tileMap = new MapTileBase[Defines.Map.MAP_WIDTH, Defines.Map.MAP_HEIGHT];
			_creaturesMap = new CreatureBase[Defines.Map.MAP_WIDTH, Defines.Map.MAP_HEIGHT];
			_itemsMap = new ConsumableItemBase[Defines.Map.MAP_WIDTH, Defines.Map.MAP_HEIGHT];
		}

		public bool TryToAddMonster(Monster monster, uint xPos, uint yPos)
		{
			if (_creaturesMap[xPos, yPos] == null)
			{
				_creaturesMap[xPos, yPos] = monster;

				return true;
			}

			return false;
		}

		public bool TryToAddItem(ConsumableItemBase item, uint xPos, uint yPos)
		{
			if (_itemsMap[xPos, yPos] == null)
			{
				_itemsMap[xPos, yPos] = item;

				return true;
			}

			return false;
		}

		public bool TryToCreateRectangularMapRegion(
			uint xPos,
			uint yPos,
			uint regionWidth,
			uint regionHeight,
			MapTileBase tile)
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
					_tileMap[xPos + i, yPos + j] = tile;
				}
			}

			return true;
		}

		public bool ValidateMap()
		{
			return _tileMap.Cast<MapTileBase>().All(tile => tile != null);
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