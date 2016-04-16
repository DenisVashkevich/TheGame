using Core.Entities.Map.Tiles;

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
			public const TerrainTypes LAND_CREATURE_PASSABLE_TERRAIN_TYPES =
				TerrainTypes.DESERT | TerrainTypes.FOREST | TerrainTypes.GRASS;

			public const TerrainTypes FLYING_CREATURE_PASSABLE_TERRAIN_TYPES =
				LAND_CREATURE_PASSABLE_TERRAIN_TYPES | TerrainTypes.WATER | TerrainTypes.ROCK;

			public static class Player
			{
				public const int PLAYER_BASE_MOVEMENT = 4;
				public const int PLAYER_BASE_HITPOINTS = 10;
			}

			public static class Bear
			{
				public const int MOVEMENT = 2;
				public const int DAMAGE = 10;
			}

			public static class Wolf
			{
				public const int MOVEMENT = 3;
				public const int DAMAGE = 5;
			}

			public static class Bat
			{
				public const int MOVEMENT = 4;
				public const int DAMAGE = 2;
			}
		}
	}
}