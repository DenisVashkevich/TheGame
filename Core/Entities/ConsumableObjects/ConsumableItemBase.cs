namespace Core.Entities.ConsumableObjects
{
	public abstract class ConsumableItemBase
	{
		public abstract string Name { get; }

		public abstract ConsumptionEffect Effect { get; }

		public abstract uint MovementCostToConsume { get; }
	}
}