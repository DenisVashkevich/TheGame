using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
	//I'm not sure how to leverage this, maybe it's useless 
	public class AttackActionEventArgs
	{
		public int Attack { get; }
		public int Damage { get; }

		public AttackActionEventArgs(int attack, int damage)
		{
			Attack = attack;
			Damage = damage;
		}
	}
}
