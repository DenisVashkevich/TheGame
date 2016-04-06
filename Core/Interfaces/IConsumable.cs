using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
	//Interactive objects that can be consumed by player and affect stats should implement this interface
	public interface IConsumable
	{
		int TotalHPModifier { get; set; }
		int TotalMovesModifier { get; set; }
		int AttackModifier { get; set; }
		int DefenceModifier { get; set; }
		bool RestoreMoves { get; set; }
		bool RestoreHP { get; set; }
	}
}
