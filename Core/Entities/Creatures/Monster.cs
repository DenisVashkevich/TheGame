using Core.Entities.Map;
using Core.Entities.Map.Tiles;
using Core.Services.EventManager;
using Core.Services.EventManager.Messages;

namespace Core.Entities.Creatures
{
	public abstract class Monster : CreatureBase
	{
		public abstract uint Damage { get; }

		protected Monster(uint id,  TerrainTypes passableTerrainTypes)
			: base(id, passableTerrainTypes)
		{
		}

		public virtual void Attack()
		{
			EventManager.Raise(new AttackMessage() {Damage = Damage});
		}

		public override void Move(MoveDirection direction)
		{
			EventManager.Raise(new MoveCreatureMessage() { CreatureId = _id, Direction = direction });
		}
	}
}