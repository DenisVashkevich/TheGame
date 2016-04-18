using Core.Entities.Map;
using Core.Entities.Map.Tiles;
using Core.Services.EventManager;
using Core.Services.EventManager.Messages;

namespace Core.Entities.Creatures
{
	public abstract class CreatureBase : IMessageHandler<NewTurnMessage>
	{
		protected readonly uint _id;
		protected double _movementLeftForThisTurn;
		protected TerrainTypes _passableTerrainTypes;

		public uint Id => _id;
		public abstract double Movement { get; }
		public abstract string Name { get; }
		public double MovementLeftForThisTurn => _movementLeftForThisTurn;
		public TerrainTypes PassableTerrainTypes => _passableTerrainTypes;

		protected CreatureBase(uint id, TerrainTypes passableTerrainTypes)
		{
			_id = id;
			_passableTerrainTypes = passableTerrainTypes;
			EventManager.Subscribe<NewTurnMessage>(this);
		}

		public virtual void Handle(NewTurnMessage message)
		{
			_movementLeftForThisTurn = Movement;
		}
	}
}