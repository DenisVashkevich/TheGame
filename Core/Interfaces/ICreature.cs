using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
	interface IInterface
	{
		int Id { get; set; }
		string Name { get; set; }
		int HitPointsTotal { get; set; }
		int HitPoints { get; set; }
		int Damage { get; set; }
		double MovesTotal { get; set; }
		double Moves { get; set; }
	}
}
