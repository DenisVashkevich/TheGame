using System;

namespace Core.Entities.Map
{
	public class Map
	{
		private MapTileBase[,] _tileMap = new MapTileBase[Defines.Map.MAP_WIDTH, Defines.Map.MAP_HEIGHT];

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