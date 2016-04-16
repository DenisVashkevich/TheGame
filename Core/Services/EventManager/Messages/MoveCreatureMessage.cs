using Core.Entities.Map;

namespace Core.Services.EventManager.Messages
{
	public class MoveCreatureMessage
	{
		public uint CreatureId { get; set; }
		public MoveDirection Direction { get; set; }
	}
}