using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Map.Tiles;

namespace Core.Entities.Creatures
{
	public class Bat : Monster
	{
		public override double Movement => Defines.Creature.Bat.MOVEMENT;
		public override string Name => "Bat";
		public override uint Damage => Defines.Creature.Bat.DAMAGE;

		public Bat(uint id) : base(id, Defines.Creature.FLYING_CREATURE_PASSABLE_TERRAIN_TYPES)
		{
		}


	}
}
