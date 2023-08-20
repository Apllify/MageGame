using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Graphics;


namespace UntitledMagusProject.EntityClasses
{
	public class SpritedEntity : Entity
	{
		protected float x;
		protected float y;

		protected Texture2D sprite;
		protected String spriteAnchor;
		//spriteAnchor can have values : "C", "NW", "NE" (for now)

		public SpritedEntity(float startingX, float startingY, Texture2D _sprite, String _spriteAnchor)
		{
			x = startingX;
			y = startingY;

			sprite = _sprite;
			spriteAnchor = _spriteAnchor;
		}

		public override void Draw()
		{
			//call sprite draw here with current entity parameters
		}



		//TODO : add draw logic here
		public static void spriteDraw(SpriteBatch spriteBatch, float x, float y, Texture2D sprite, String spriteAnchor)
		{

		}

	}
}
