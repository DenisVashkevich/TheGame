using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Map;

namespace Core.Services.EventManager.Messages
{
	public class MoveCreatureMessage
	{
		public MoveDirection Direction { get; set; }
	}
}
