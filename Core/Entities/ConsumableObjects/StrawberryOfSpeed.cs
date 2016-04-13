using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.ConsumableObjects
{
	public class StrawberryOfSpeed : ConsumableItemBase
	{
		public override string Name => "Strawberry Of Speed";

		public override ConsumptionEffect Effect { get; }
		public override uint MovementCostToConsume { get; }

		public StrawberryOfSpeed()
		{
			Effect = new ConsumptionEffect() {HPAmountToRestore = 0, MovementAmountToRestore = 5};
			MovementCostToConsume = 1;
		}
	}
}
