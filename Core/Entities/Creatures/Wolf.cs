using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Map.Tiles;

namespace Core.Entities.Creatures
{
	public class Wolf : Monster
	{
		public override double Movement => Defines.Creature.Wolf.MOVEMENT;
		public override string Name => "Wolf";
		public override uint Damage => Defines.Creature.Wolf.DAMAGE;

		public Wolf(uint id) : base(id, Defines.Creature.LAND_CREATURE_PASSABLE_TERRAIN_TYPES)
		{
		}


	}
}
