using Core.Entities.Map;

namespace Core.Entities.Creatures
{
	public abstract class Monster : CreatureBase
	{
		private readonly int _damage;

		public int Damage => _damage;

		public Monster(string name, int moves, int damage, TerrainTypes passableTerrainTypes)
			: base(name, moves, passableTerrainTypes)
		{
			_damage = damage;
		}

		public abstract void Attack();
	}
}