using Core.Entities.ConsumableObjects;
using Core.Entities.Creatures;

namespace Core.Entities
{
	public class GameObjectsFactory : IAbstractFactory
	{
		private uint _nextObjectIdentifier;

		public GameObjectsFactory(uint startId)
		{
			_nextObjectIdentifier = startId;
		}

		public Bat CreateBat()
		{
			return new Bat(++_nextObjectIdentifier);
		}

		public Bear CreateBear()
		{
			return new Bear(++_nextObjectIdentifier);
		}

		public Wolf CreateWolf()
		{
			return new Wolf(++_nextObjectIdentifier);
		}

		public HealthyCherry CreateHealthyCherry()
		{
			return new HealthyCherry(++_nextObjectIdentifier);
		}

		public StrawberryOfSpeed CreateStrawberryOfSpeed()
		{
			return new StrawberryOfSpeed(++_nextObjectIdentifier);
		}
	}
}