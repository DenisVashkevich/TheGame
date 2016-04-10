namespace Core.Entities.Map
{
	public class RockTile : MapTileBase
	{
		public RockTile()
			: base("Rock", TerrainTypes.ROCK, Defines.Map.IMPASSABLE_FOR_NONFLYING_CREATURES_TERRAIN_MOVEMENT_COST)
		{
		}
	}
}