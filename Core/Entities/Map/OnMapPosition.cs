using System;
using System.Collections;
using System.Collections.Generic;

namespace Core.Entities.Map
{
	public class OnMapPosition : IEqualityComparer<OnMapPosition>
	{
		public uint XPos { get; set; }
		public uint YPos { get; set; }

		public bool Equals(OnMapPosition x, OnMapPosition y)
		{
			if((x.XPos == y.XPos) && (x.YPos == y.YPos))
			{
				return true;
			}

			return false;
		}

		public bool Equals(OnMapPosition x)
		{
			if ((x.XPos == XPos) && (x.YPos == YPos))
			{
				return true;
			}

			return false;
		}


		public int GetHashCode(OnMapPosition obj)
		{
			unchecked 
			{
				int hash = 17;
				hash = hash * 23 + obj.XPos.GetHashCode();
				hash = hash * 23 + obj.YPos.GetHashCode();
				return hash;
			}
		}
	}
}