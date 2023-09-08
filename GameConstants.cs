using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UntitledMagusProject
{
	public static class GameConstants
	{
		//Overall project constants

		//virtual resolution
		//1920/384 = 1080/216 = 5	
		//384/32 = 12
		//216/32 = 6.75
		public const int virtualWidth = 384 ;
		public const int virtualHeight = 216;

		public const float activeDepth = 0.5f;
		public const float foregroundDepth = 0.2f;
		public const float backgroundDepth = 1f;

		public const int collisionPixelPrecision = 2;


		//Constants for balancing the wizards
		public const float wizardSpeed = 200;

	}
}
