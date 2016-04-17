namespace Core.Entities.Map.Tiles
{
	public class WaterTile : MapTileBase
	{
		public override uint MovesCostToMoveOnTile => Defines.Map.IMPASSABLE_FOR_NONFLYING_CREATURES_TERRAIN_MOVEMENT_COST;
		public override string Description => "Water";
		public override TerrainTypes TerrainType => TerrainTypes.WATER;
	}
}