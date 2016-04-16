using System;

namespace Core.Entities.Creatures
{
	public class Bear : Monster
	{
		public override string Name => "Bear";
		public override double Movement => Defines.Creature.Bear.MOVEMENT;
		public override uint Damage => Defines.Creature.Bear.DAMAGE;


		public Bear(uint id) : base(id, Defines.Creature.LAND_CREATURE_PASSABLE_TERRAIN_TYPES)
		{
		}
	}
}