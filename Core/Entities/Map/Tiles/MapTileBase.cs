namespace Core.Entities.Map.Tiles
{
	public abstract class MapTileBase
	{
		public abstract uint MovesCostToMoveOnTile { get; }
		public abstract string Description { get; }
		public abstract bool PasableByLandCreatures { get; }
		public abstract bool PasableByFlyingCreatures { get; }
	}
}