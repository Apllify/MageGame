using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UntitledMagusProject.EntityClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Reflection.Metadata;

namespace UntitledMagusProject.Implementations.Entities
{
	public class Wizard : CollisionEntity
	{
		public Wizard(Vector2 position):
			base(position, new Rectangle(), null, "C", GameConstants.activeDepth)
		{
			//TODO : find way to load a sprite here ?
		}

	}
}
