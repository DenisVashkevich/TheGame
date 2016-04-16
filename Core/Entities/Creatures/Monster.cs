using Core.Entities.Map;

namespace Core.Entities.Creatures
{
	public abstract class Monster : CreatureBase
	{
		private readonly int _damage;

		public int Damage => _damage;

		protected Monster(int movement, int damage, TerrainTypes passableTerrainTypes)
			: base(movement, passableTerrainTypes)
		{
			_damage = damage;
		}

		public abstract void Attack();
	}
}