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

		protected Object sprite; //change me when the type of sprite is found pls
		protected String spriteAnchor;

		public SpritedEntity(float startingX, float startingY, Object _sprite, String _spriteAnchor)
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
		public static void spriteDraw(SpriteBatch spriteBatch, float x, float y, Object sprite, String spriteAnchor)
		{

		}

	}
}
