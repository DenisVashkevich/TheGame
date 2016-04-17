using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.ConsumableObjects
{
	public class HealthyCherry : ConsumableItemBase
	{
		public override ConsumptionEffect Effect { get; }
		public override uint MovementCostToConsume { get; }

		public override string Name => "Healthy Cherry";

		public HealthyCherry(uint id) : base(id)
		{
			Effect = new ConsumptionEffect() {HPAmountToRestore = 5, MovementAmountToRestore = 0};
			MovementCostToConsume = 1;
		}
	}
}
