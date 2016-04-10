using Core.Entities.Map;

namespace Core.Entities.Creatures
{
	public abstract class Monster : CreatureBase
	{
		private readonly int _damage;

		public int Damage => _damage;

		protected Monster(string name, int movement, int damage, TerrainTypes passableTerrainTypes)
			: base(name, movement, passableTerrainTypes)
		{
			_damage = damage;
		}

		public abstract void Attack();
	}
}