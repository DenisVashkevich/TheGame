﻿namespace Core.Entities.Map.Tiles
{
	public class DesertTile : MapTileBase
	{
		public override uint MovesCostToMoveOnTile => 4;
		public override string Description => "Desert";
		public override bool PasableByLandCreatures => true;
		public override bool PasableByFlyingCreatures => true;
	}
}