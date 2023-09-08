using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UntitledMagusProject.EntityClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using System.Runtime.InteropServices;

namespace UntitledMagusProject.Implementations.Entities
{
	public class Wizard : CollisionEntity
	{
		protected Vector2 directionalInput;
		protected Vector2 movementVector;
		protected Vector2 zeroVector;

		

		public Wizard(Vector2 position):
			base(position, null, "C", GameConstants.activeDepth)
		{
			directionalInput = new Vector2();
			movementVector = new Vector2();
			zeroVector = new Vector2(0, 0);

			CollisionWeight = 2;

			//TODO : replace this with actual wizard sprite
			this.sprite = SpriteLoader.loadContent<Texture2D>("Placeholders/Box");
			this.colorMask = Color.YellowGreen;
		}

		//TODO : potentially implement a custom hitbox override here?
		public override Rectangle getHitbox()
		{
			return base.getHitbox();
		}

		public override void Update(GameTime gameTime)
		{
			KeyboardState keyboard = Keyboard.GetState();

			//reset the previous direciton
			directionalInput = new Vector2(0, 0);

			//determine the direction that the player is pressing
			if (keyboard.IsKeyDown(Keys.D))
				directionalInput.X = 1;
			else if (keyboard.IsKeyDown(Keys.Q))
				directionalInput.X = -1;

			if (keyboard.IsKeyDown(Keys.Z))
				directionalInput.Y = -1;
			else if (keyboard.IsKeyDown(Keys.S))
				directionalInput.Y = 1;

			//normalize the vector to compute movement intensity
			if (!directionalInput.Equals(zeroVector))
			{
				directionalInput.Normalize();
				movementVector = (directionalInput * GameConstants.wizardSpeed) * (float)(gameTime.ElapsedGameTime.TotalSeconds);
				position += movementVector;
			}


		}

	}
}
