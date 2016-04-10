using Core.Entities.Map;

namespace Core
{
	public static class Defines
	{
		public static class Map
		{
			public const int IMPASSABLE_FOR_NONFLYING_CREATURES_TERRAIN_MOVEMENT_COST = 9999;
			public const int MAP_WIDTH = 24;
			public const int MAP_HEIGHT = 24;
		}

		public static class Creature
		{
			public static class Player
			{
				public const int PLAYER_BASE_MOVEMENT = 5;
				public const int PLAYER_BASE_HITPOINTS = 10;
			}

			public static class Bear
			{
				public const int BEAR_MOVEMENT = 5;
				public const int BEAR_DAMAGE = 10;
			}

			public const TerrainTypes LAND_CREATURE_BASE_PASSABLE_TERRAIN_TYPES =
				TerrainTypes.DESERT | TerrainTypes.FOREST | TerrainTypes.GRASS;
		}
	}
}