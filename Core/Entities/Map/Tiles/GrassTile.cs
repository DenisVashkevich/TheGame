using Core.Services.EventManager;
using Core.Services.EventManager.Messages;

namespace Core.Entities.Map.Tiles
{
	public class GrassTile : MapTileBase, IMessageHandler<NewTurnMessage>
	{
		private const uint BASE_MOVEMENT_COST = 1;

		private double _movementCost;
		public override uint MovesCostToMoveOnTile => (uint)_movementCost;
		public override string Description => "Grass";
		public override bool PasableByLandCreatures => true;
		public override bool PasableByFlyingCreatures => true;

		public GrassTile()
		{
			_movementCost = BASE_MOVEMENT_COST;
		}

		public void Handle(NewTurnMessage message)
		{
			GrowGrass();
		}

		private void GrowGrass()
		{
			_movementCost += _movementCost;
		}

		public void CutGrass()
		{
			_movementCost = BASE_MOVEMENT_COST;
		}
	}
}