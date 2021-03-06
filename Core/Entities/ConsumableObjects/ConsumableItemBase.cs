﻿namespace Core.Entities.ConsumableObjects
{
	public abstract class ConsumableItemBase
	{
		protected readonly uint _id;

		public abstract string Name { get; }
		public abstract ConsumptionEffect Effect { get; }
		public abstract uint MovementCostToConsume { get; }

		public uint Id => _id;

		protected ConsumableItemBase(uint id)
		{
			_id = id;
		}
	}
}