using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
	public interface ICreature
	{
		int Id { get; set; }
		string Name { get; set; }
		int HitPoints { get; set; }
		double Moves { get; set; }
	}
}
