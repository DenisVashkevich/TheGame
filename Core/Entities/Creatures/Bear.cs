using System;

namespace Core.Entities.Creatures
{
	public class Bear : Monster
	{
		public Bear()
			: base(
				Defines.Creature.Bear.BEAR_MOVEMENT,
				Defines.Creature.Bear.BEAR_DAMAGE,
				Defines.Creature.LAND_CREATURE_BASE_PASSABLE_TERRAIN_TYPES)
		{
		}

		public override string Name => "Bear";

		public override void Attack()
		{
			//TODO : implement monster attack logic
			throw new NotImplementedException();
		}

		public override void Move()
		{
			//TODO : implement monster movement logic
			throw new NotImplementedException();
		}
	}
}