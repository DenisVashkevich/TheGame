using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Map;

namespace Core.Entities.Creatures
{
	public class Bear : Monster
	{
		public Bear(string name, int moves, int damage, TerrainTypes passableTerrainTypes) : base(name, moves, damage, passableTerrainTypes)
		{
		}

		public override void Move()
		{
			throw new NotImplementedException();
		}
	}
}
