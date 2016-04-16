using System;
using Core.Entities.ConsumableObjects;
using Core.Services.EventManager;

namespace Core.Entities.Creatures
{
	public class Player : CreatureBase
	{
		private readonly string _name;
		private readonly uint _hitPoints;
		private uint _hitPointsLeft;

		public uint HitPoints => _hitPoints;
		public uint HitPointsLeft => _hitPointsLeft;

		public Player(string name, uint hitPoints)
			: base(
				Defines.Creature.Player.PLAYER_BASE_MOVEMENT,
				Defines.Creature.LAND_CREATURE_BASE_PASSABLE_TERRAIN_TYPES)
		{
			_name = name;
			_hitPoints = hitPoints;
		}

		public override string Name => _name;

		public override void Move()
		{
			//TODO : implement player movement logic
			throw new NotImplementedException();
		}

		public void TakeDamage(int amount)
		{
			//TODO : implement player taking damage logic
		}

		public ConsumptionResult TryToConsumeItem(ConsumableItemBase item)
		{
			if (_movementLeftForThisTurn < item.MovementCostToConsume)
			{
				return ConsumptionResult.NOT_ENOUGH_MOVEMENT;
			}

			var missingHP = _hitPoints - _hitPointsLeft;
			var misingMovement = Movement - _movementLeftForThisTurn;

			_hitPointsLeft += item.Effect.HPAmountToRestore <= missingHP 
				? item.Effect.HPAmountToRestore 
				: missingHP;

			_movementLeftForThisTurn += item.Effect.MovementAmountToRestore <= misingMovement
				? item.Effect.MovementAmountToRestore
				: misingMovement;

			return ConsumptionResult.CONSUMED;
		}
	}
}