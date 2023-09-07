using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UntitledMagusProject.Implementations
{
	public class SpriteLoader
	{
		public static ContentManager contentManager;

		public static void initializeSpriteLoader(ContentManager _contentManager)
		{
			SpriteLoader.contentManager = _contentManager;
		}

		public static T loadContent<T>(String textureName)
		{
			return SpriteLoader.contentManager.Load<T>(textureName);
		}


	}
}
