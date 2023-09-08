using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UntitledMagusProject.EntityClasses
{
	public class CollisionEntity : SpritedEntity
	{

		Rectangle curHitboxRectangle;



		/// <summary>
		/// Don't make this zero under ANY circumstances.
		/// </summary>
		public double CollisionWeight { get; set; }

		public CollisionEntity(Vector2 position,Texture2D _sprite, String _spriteAnchor, float _layerDepth):
			base(position, _sprite, _spriteAnchor, _layerDepth)
		{
			//collision entity stuff
			curHitboxRectangle = getHitbox();


			//stuff common to all entity subclasses
			Tag = "untagged-collision-entity";
			CollisionWeight = 1;
		}


		/// <summary>
		/// Compute the default hitbox of this CollisionEntity
		/// Supports the available spriteAnchors
		/// </summary>
		/// <returns>The bounds of the entity sprite</returns>
		public virtual Rectangle getHitbox()
		{
			//abort if we don't have a sprite
			if (sprite == null)
			{
				return Rectangle.Empty;
			}


			int spriteWidth = sprite.Width;
			int spriteHeight = sprite.Height;


			//determine the hitbox based on what point the coordinates represent
			if (spriteAnchor == "C")
			{
				return new Rectangle(new Point((int)position.X - spriteWidth / 2, (int)position.Y - spriteHeight / 2), new Point(spriteWidth, spriteHeight));
			}
			else if (spriteAnchor == "NE")
			{
				return new Rectangle(new Point((int)position.X - spriteWidth, (int)position.Y), new Point(spriteWidth, spriteHeight));
			}
			else
			{
				return new Rectangle(new Point((int)position.X, (int)position.Y), new Point(spriteWidth, spriteHeight));
			}

		}


		public virtual void onCollision(CollisionEntity otherEntity)
		{

		}

	}
}
