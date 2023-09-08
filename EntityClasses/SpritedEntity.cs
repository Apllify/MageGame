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

		protected Vector2 position;

		protected Texture2D sprite;
		protected String spriteAnchor; 
		//spriteAnchor can have values : "C", "NW", "NE" (for now)

		protected Color colorMask;


		public float LayerDepth { get; protected set; }

		public SpritedEntity(Vector2 startingCoords, Texture2D _sprite, String _spriteAnchor, float _layerDepth)
		{
			//properties/fields that have argument values
			position = startingCoords;

			sprite = _sprite;
			spriteAnchor = _spriteAnchor;

			LayerDepth = _layerDepth;

			//default draw color, user can change it but not from constructor
			colorMask = Color.White;


			//default tag for all sprited entities
			Tag = "untagged-sprited-entity";
		}

		public SpritedEntity(Vector2 startingCoords, Texture2D _sprite, String _spriteAnchor):
			this(startingCoords, _sprite, _spriteAnchor, GameConstants.activeDepth)
		{ }

		public SpritedEntity(Vector2 startingCoords, Texture2D _sprite) :
			this(startingCoords, _sprite, "C", GameConstants.activeDepth)
		{ }

		/// <summary>
		/// Have to implement manually otherwise modifying it gets annoying
		/// </summary>
		/// <returns>The current position of the game object.</returns>
		public Vector2 getPosition()
		{
			return position;
		}

		public void shiftPosition(float shiftX, float shiftY)
		{
			position.X += shiftX;
			position.Y += shiftY;
		}

		public void shiftPosition(Vector2 shiftVector)
		{
			position += shiftVector;
		}
		

		public override void Draw(SpriteBatch spriteBatch)
		{
			//check for custom colors
			if (colorMask.Equals(Color.White))
			{
				SpritedEntity.spriteDraw(spriteBatch, position, sprite, spriteAnchor, LayerDepth);
			}
			else
			{
				SpritedEntity.spriteDraw(spriteBatch, position, sprite, spriteAnchor, LayerDepth, colorMask);

			}
		}



		public static void spriteDraw(SpriteBatch spriteBatch, Vector2 drawPosition, Texture2D sprite, String spriteAnchor, float layerDepth, Color colorMask)
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



			spriteBatch.Draw(sprite, drawPosition, null, colorMask, 0, origin, 1, SpriteEffects.None, layerDepth);
		}

		public static void spriteDraw(SpriteBatch spriteBatch, Vector2 drawPosition, Texture2D sprite, String spriteAnchor, float layerDepth)
		{
			spriteDraw(spriteBatch, drawPosition, sprite, spriteAnchor, layerDepth, Color.White);
		}


	}
}
