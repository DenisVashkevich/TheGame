namespace Core.Entities.Map.Tiles
{
	public abstract class MapTileBase
	{
		public abstract double MovesCostToMoveOnTile { get; }
		public abstract string Description { get; }
		public abstract TerrainTypes TerrainType { get; }

	}
}