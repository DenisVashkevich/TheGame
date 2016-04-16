using System;

namespace Core.Entities.Map.Tiles
{
	[Flags]
	public enum TerrainTypes : short
	{
		NONE = 0,
		GRASS = 1,
		FOREST = 2,
		DESERT = 4,
		WATER = 8,
		ROCK = 16
	}
}