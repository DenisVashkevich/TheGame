using Core.Entities.Map;

namespace Core.Entities.Creatures
{
	public abstract class CreatureBase
	{
		private int _movement;
		protected double _movementLeftForThisTurn;
		protected TerrainTypes _passableTerrainTypes;

		public double Movement => _movement;
		public abstract string Name { get; }
		public double MovementLeftForThisTurn => _movementLeftForThisTurn;

		protected CreatureBase(int movement, TerrainTypes passableTerrainTypes)
		{
			_movement = movement;
			_passableTerrainTypes = passableTerrainTypes;
		}

		public abstract void Move();
	}
}