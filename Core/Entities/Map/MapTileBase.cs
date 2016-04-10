namespace Core.Entities.Map
{
	public abstract class MapTileBase
	{
		private readonly double _movesCostToMoveOnTile;
		private readonly string _description;
		private readonly TerrainTypes _terrainType;

		public double MovesCostToMoveOnTile => _movesCostToMoveOnTile;
		public string Description => _description;
		public TerrainTypes TerrainType => _terrainType;

		protected MapTileBase(string description, TerrainTypes terrainType, double movesCostToMoveOnTile)
		{
			_description = description;
			_terrainType = terrainType;
			_movesCostToMoveOnTile = movesCostToMoveOnTile;
		}
	}
}