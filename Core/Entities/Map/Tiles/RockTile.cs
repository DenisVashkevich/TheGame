namespace Core.Entities.Map.Tiles
{
	public class RockTile : MapTileBase
	{
		public override uint MovesCostToMoveOnTile => Defines.Map.IMPASSABLE_FOR_NONFLYING_CREATURES_TERRAIN_MOVEMENT_COST;
		public override string Description => "Rock";
		public override TerrainTypes TerrainType => TerrainTypes.ROCK;
	}
}