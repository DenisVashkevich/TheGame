using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
	//Base class for entities with stats, like monsters and player
	public abstract class BaseStats
	{
		public int HitPointsTotal { get; set; }
		public int Damage { get; set; }
		public int Attac { get; set; }
		public int Defence { get; set; }
		public double MovesTotal { get; set; }
	}
}
