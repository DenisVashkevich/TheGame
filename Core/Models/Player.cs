using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;

namespace Core
{
    public class Player: BaseStats, ICreature, IPlayer
    {
	    public int Id { get; set; }
	    public string Name { get; set; }
	    public int HitPoints { get; set; }
	    public double Moves { get; set; }

	    public void ConsumeInteractiveObject()
	    {
		    throw new NotImplementedException();
	    }
    }
}
