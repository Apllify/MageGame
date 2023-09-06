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

		public CollisionEntity(Vector2 position, Rectangle hitboxRectangle, Texture2D _sprite, String _spriteAnchor, float _layerDepth):
			base(position, _sprite, _spriteAnchor, _layerDepth)
		{
			//collision entity stuff
			curHitboxRectangle = hitboxRectangle;


			//stuff common to all entity subclasses
			Tag = "untagged-collision-entity";
		}

		public Rectangle getHitbox()
		{
			return curHitboxRectangle;
		}


	}
}
