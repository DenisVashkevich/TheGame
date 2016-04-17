namespace Core.Entities.Map.Tiles
{
	public class GrassTile : MapTileBase
	{
		public override uint MovesCostToMoveOnTile => 1;
		public override string Description => "Grass";
		public override TerrainTypes TerrainType => TerrainTypes.GRASS;
	}
}