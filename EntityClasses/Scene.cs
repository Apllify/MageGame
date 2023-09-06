using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Timers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UntitledMagusProject.EntityClasses
{
	public class Scene : Entity
	{
		protected List<Entity> regularEntitiesList;
		protected List<CollisionEntity> collisionEntitiesList;


		///<summary>
		///The constructor, only creates the basic fields, does NOT load the entities
		///</summary>
		public Scene()
		{
			regularEntitiesList = new List<Entity>();
			collisionEntitiesList = new List<CollisionEntity>();
		}


		/// <summary>
		/// The function for creating all of the entities of the scene
		/// </summary>
		public virtual void Load()
		{
			

		}

		public override void Update(GameTime gameTime)
		{

			//updating all entities
			foreach(Entity entity in regularEntitiesList)
			{
				entity.Update(gameTime);
			}

			foreach(Entity collisionEntity in collisionEntitiesList)
			{
				collisionEntity.Update(gameTime);
			}


			//detecting then correcting collisions

		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			//drawing all held entities
			foreach (Entity entity in regularEntitiesList)
			{
				entity.Draw(spriteBatch);
			}

			foreach (Entity collisionEntity in collisionEntitiesList)
			{
				collisionEntity.Draw(spriteBatch);
			}
		}
	}
}
