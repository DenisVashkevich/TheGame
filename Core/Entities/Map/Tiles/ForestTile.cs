namespace Core.Entities.Map.Tiles
{
	public class ForestTile : MapTileBase
	{
		public override uint MovesCostToMoveOnTile => 2;
		public override string Description => "Forest";
		public override TerrainTypes TerrainType => TerrainTypes.FOREST;
	}
}