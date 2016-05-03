using Core.Entities.ConsumableObjects;
using Core.Entities.Creatures;

namespace Core.Entities
{
	interface IAbstractFactory
	{
		Bat CreateBat();
		Bear CreateBear();
		Wolf CreateWolf();

		HealthyCherry CreateHealthyCherry();
		StrawberryOfSpeed CreateStrawberryOfSpeed();
	}
}