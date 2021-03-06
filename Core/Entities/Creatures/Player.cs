﻿using Core.Entities.ConsumableObjects;
using Core.Services.EventManager;
using Core.Services.EventManager.Messages;

namespace Core.Entities.Creatures
{
	public class Player : CreatureBase, IMessageHandler<AttackMessage>
	{
		private readonly uint _hitPoints;
		private readonly string _name;
		private uint _hitPointsLeft;
		private uint _movement;
		public uint HitPoints => _hitPoints;
		public uint HitPointsLeft => _hitPointsLeft;
		public override double Movement { get; }

		public override string Name => _name;


		public Player(string name, uint id)
			: base(id, Defines.Creature.LAND_CREATURE_PASSABLE_TERRAIN_TYPES)
		{
			_name = name;
			_movement = Defines.Creature.Player.PLAYER_BASE_MOVEMENT;
			_movementLeftForThisTurn = _movement;
			_hitPoints = Defines.Creature.Player.PLAYER_BASE_HITPOINTS;
			_hitPointsLeft = _hitPoints;

			EventManager.Subscribe<AttackMessage>(this);
		}

		public void Handle(AttackMessage message)
		{
			TakeDamage(message.Damage);
		}

		public bool TryToConsumeItem(ConsumableItemBase item)
		{
			if (_movementLeftForThisTurn < item.MovementCostToConsume)
			{
				return false;
			}

			var missingHP = _hitPoints - _hitPointsLeft;
			var misingMovement = Movement - _movementLeftForThisTurn;

			_hitPointsLeft += item.Effect.HPAmountToRestore <= missingHP
				? item.Effect.HPAmountToRestore
				: missingHP;

			_movementLeftForThisTurn += item.Effect.MovementAmountToRestore <= misingMovement
				? item.Effect.MovementAmountToRestore
				: misingMovement;

			return true;
		}

		private void TakeDamage(uint damage)
		{
			_hitPointsLeft -= damage;
		}
	}
}