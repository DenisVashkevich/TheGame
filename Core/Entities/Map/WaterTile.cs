namespace Core.Entities.Map
{
	public class WaterTile : MapTileBase
	{
		public WaterTile()
			: base("Water", TerrainTypes.WATER, Defines.Map.IMPASSABLE_FOR_NONFLYING_CREATURES_TERRAIN_MOVEMENT_COST)
		{
		}
	}
}