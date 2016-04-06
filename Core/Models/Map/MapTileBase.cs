using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;

namespace Core.Models.Map
{
	public abstract class MapTileBase
	{
		public MapTileBase WestTile { get; set; }
		public MapTileBase NorthTile { get; set; }
		public MapTileBase EastTile { get; set; }
		public MapTileBase SouthTile { get; set; }

		public double CostToMoveOn { get; set; }

		public IConsumable ConsumableObject { get; set; }

		public ICreature Creature { get; set; }
	}
}
