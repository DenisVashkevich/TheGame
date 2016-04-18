using System;
using Core.Entities.ConsumableObjects;
using Core.Entities.Map;
using Core.Services.EventManager;
using Core.Services.EventManager.Messages;

namespace Core.Entities.Creatures
{
	public class Player : CreatureBase, IMessageHandler<AttackMessage>, IMessageHandler<ConsumableItemFoundMessage>
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
			EventManager.Subscribe<ConsumableItemFoundMessage>(this);
		}

		public void Handle(AttackMessage message)
		{
			TakeDamage(message.Damage);
		}

		public ConsumptionResult TryToConsumeItem(uint itemId)
		{
			//if (_movementLeftForThisTurn < item.MovementCostToConsume)
			//{
			//	return ConsumptionResult.NOT_ENOUGH_MOVEMENT;
			//}

			//var missingHP = _hitPoints - _hitPointsLeft;
			//var misingMovement = Movement - _movementLeftForThisTurn;

			//_hitPointsLeft += item.Effect.HPAmountToRestore <= missingHP
			//	? item.Effect.HPAmountToRestore
			//	: missingHP;

			//_movementLeftForThisTurn += item.Effect.MovementAmountToRestore <= misingMovement
			//	? item.Effect.MovementAmountToRestore
			//	: misingMovement;

			return ConsumptionResult.CONSUMED;
		}

		private void TakeDamage(uint damage)
		{
			_hitPointsLeft -= damage;
		}

		public override void Move(MoveDirection direction)
		{
			//destinationTileInfo will be aquaired fom map object
			MapTileInfo destinationTileInfo = new MapTileInfo();

			if (MovementLeftForThisTurn > destinationTileInfo.CostToMoveOn &&
			    _passableTerrainTypes.HasFlag(destinationTileInfo.TerrainType) && destinationTileInfo.CreatureId == 0)
			{
				EventManager.Raise(new MoveCreatureMessage() {CreatureId = _id, Direction = direction});
			}
		}

		public void Handle(ConsumableItemFoundMessage message)
		{
			TryToConsumeItem(message.ItemId);
		}
	}
}