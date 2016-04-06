using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Enums;
using Core.Interfaces;

namespace Core.Models
{
	class Monster : BaseStats,ICreature,IAIControlled
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int HitPoints { get; set; }
		public double Moves { get; set; }

		public MoveDirection GetMoveDirrection()
		{
			throw new NotImplementedException();
		}
	}
}
