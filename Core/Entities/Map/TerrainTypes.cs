using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Map
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
