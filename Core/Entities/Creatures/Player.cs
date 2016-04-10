using System;
using Core.Entities.Creatures;

namespace Core
{
	public class Player : CreatureBase
	{
		private readonly int _hitPoints;
		private int _hitPointsLeft;

		public int HitPoints => _hitPoints;
		public int HitPointsLeft => _hitPointsLeft;

		public Player(int hitPoints)
			: base(
				"Local Hero",
				Defines.Creature.Player.PLAYER_BASE_MOVEMENT,
				Defines.Creature.LAND_CREATURE_BASE_PASSABLE_TERRAIN_TYPES)
		{
			_hitPoints = hitPoints;
		}

		public override void Move()
		{
			//TODO : implement player movement logic
			throw new NotImplementedException();
		}

		public void TakeDamage(int amount)
		{
			//TODO : implement player taking damage logic
		}
	}
}