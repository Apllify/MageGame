using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Timers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UntitledMagusProject.EntityClasses
{
	public class Scene : Entity
	{
		protected List<Entity> regularEntitiesList;
		protected List<CollisionEntity> collisionEntitiesList;

		private CollisionEntity e1;
		private CollisionEntity e2;



		private double e1MoveIntensity;
		private double e2MoveIntensity;
		private double normalConstant;

		private Vector2 collisionVector;
		private float e1HalfDiag;
		private float e2HalfDiag;
		private float safeDistance;
		




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

		/// <summary>
		/// Adds a NON COLLISION entity to its proper list to be updated
		/// </summary>
		/// <param name="entity"></param>
		public void addEntity(Entity entity)
		{
			regularEntitiesList.Add(entity);
		}

		public void addCollisionEntity(CollisionEntity entity)
		{
			collisionEntitiesList.Add(entity);
		}


		/// <summary>
		/// Update all of the entities, correct and notify entities of collisions 
		/// </summary>
		/// <param name="gameTime">You know what GameTime is already</param>
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
			//TODO : find a more performant algorithm
			for (int i = 0; i < collisionEntitiesList.Count-1; i++)
			{

				e1 = collisionEntitiesList[i];

				for (int j = i+1; j< collisionEntitiesList.Count; j++)
				{
					e2 = collisionEntitiesList[j];
					

					if (e1.getHitbox().Intersects(e2.getHitbox()))
					{

						//don't care about collisions between two static objects
						if (e1.CollisionWeight.Equals(Double.PositiveInfinity) && e2.CollisionWeight.Equals(Double.PositiveInfinity))
						{
							continue;
						}

						//FIGURE OUT BETTER OPTION : don't care when two elements are perfectly superposed 
						if (e1.getPosition().EqualsWithTolerence(e2.getPosition(), 1E-02f))
						{
							continue;
						}

						//call the respective events
						e1.onCollision(e2);
						e2.onCollision(e1);

						//TODO : REALLY need to test this, and eventually optimize it by A LOT
						//correct the collision with the following steps:
						//1°) get separation vector
						//2°) compute the safe distance (distance that guarantees no collision)
						//3°) slide both e's along separation vector 2px by 2px with proportionate displacements
						//4°) stop sliding once either no collision, or safe distance reached
						collisionVector = e2.getHitbox().Center.ToVector2() - e1.getHitbox().Center.ToVector2();
						collisionVector.Normalize();

						e1HalfDiag = e1.getHitbox().Size.ToVector2().Length() / 2;
						e2HalfDiag = e2.getHitbox().Size.ToVector2().Length() / 2;
						safeDistance = e1HalfDiag + e2HalfDiag;



						//compute which percentage of the displacement each entity will do
						normalConstant = (1/e1.CollisionWeight) + (1/e2.CollisionWeight);
						e1MoveIntensity = (1 / e1.CollisionWeight) * normalConstant;
						e2MoveIntensity = (1 / e2.CollisionWeight) * normalConstant;

						for (int counter = 0; counter < safeDistance; counter += GameConstants.collisionPixelPrecision)
						{
							//shift both entities accordingly
							e1.shiftPosition(-collisionVector * (float)e1MoveIntensity);
							e2.shiftPosition(collisionVector * (float)e2MoveIntensity);


							//leave if collision is finally gone
							if (!e1.getHitbox().Intersects(e2.getHitbox()))
							{
								break;
							}
						}
						
					}
				}
			}
		}


		/// <summary>
		/// Just draw all of the entities
		/// </summary>
		/// <param name="spriteBatch"></param>
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
