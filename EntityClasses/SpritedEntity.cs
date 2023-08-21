using System;
using System.Collections.Generic;
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

		public SpritedEntity(float startingX, float startingY, Texture2D _sprite, String _spriteAnchor, float _layerDepth = 1)
		{
			x = startingX;
			y = startingY;

			sprite = _sprite;
			spriteAnchor = _spriteAnchor;

			layerDepth = _layerDepth;
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			SpritedEntity.spriteDraw(spriteBatch, x, y, sprite, spriteAnchor, layerDepth);
		}



		public static void spriteDraw(SpriteBatch spriteBatch, float x, float y, Texture2D sprite, String spriteAnchor, float layerDepth)
		{
			//TODO : use sprite anchor to compute draw offset
			Vector2 offset = new Vector2(0, 0);

			spriteBatch.Draw(sprite, new Vector2(x, y), null, Color.White, 0, offset, 1, SpriteEffects.None, layerDepth);
		}

	}
}
