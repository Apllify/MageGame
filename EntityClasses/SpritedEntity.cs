using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
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

		protected float layerDepth;

		public SpritedEntity(float startingX, float startingY, Texture2D _sprite, String _spriteAnchor, float _layerDepth)
		{
			x = startingX;
			y = startingY;

			sprite = _sprite;
			spriteAnchor = _spriteAnchor;


			layerDepth = _layerDepth;

		}

		public SpritedEntity(float startingX, float startingY, Texture2D _sprite, String _spriteAnchor):
			this(startingX, startingY, _sprite, _spriteAnchor, GameConstants.activeDepth)
		{ }
		

		public override void Draw(SpriteBatch spriteBatch)
		{
			SpritedEntity.spriteDraw(spriteBatch, x, y, sprite, spriteAnchor, layerDepth);
		}



		public static void spriteDraw(SpriteBatch spriteBatch, float x, float y, Texture2D sprite, String spriteAnchor, float layerDepth)
		{
			//determine how to draw the sprite based on the anchor
			Vector2 origin;
			float spriteWidth = sprite.Width;


			if (spriteAnchor == "C")
			{
				origin = new Vector2(sprite.Width/2, sprite.Height/2);
			}
			else if (spriteAnchor == "NE")
			{
				origin = new Vector2(sprite.Width, 0);
			}
			else
			{
				origin = new Vector2(0, 0);
			}



			spriteBatch.Draw(sprite, new Vector2(x, y), null, Color.White, 0, origin, 1, SpriteEffects.None, layerDepth);
		}


	}
}
