using Core.Entities.Map;

namespace Core.Entities.Creatures
{
	public abstract class CreatureBase
	{
		private readonly string _name;
		private int _movement;
		private double _movesLeftForThisTurn;
		private TerrainTypes _passableTerrainTypes;

		public double Movement => _movement;
		public string Name => _name;
		public double MovesLeftForThisTurn => _movesLeftForThisTurn;

		protected CreatureBase(string name, int movement, TerrainTypes passableTerrainTypes)
		{
			_name = name;
			_movement = movement;
			_passableTerrainTypes = passableTerrainTypes;
		}

		public abstract void Move();
	}
}