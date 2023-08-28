using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using System;
using UntitledMagusProject.EntityClasses;

namespace UntitledMagusProject
{
	public class MageGame : Game
	{
		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;
		private RenderTarget2D _renderTarget; //used for virtual resolution

		private Texture2D ballTexture;

		private SpritedEntity ballA;
		private SpritedEntity ballB;
		private SpritedEntity ballC;


        public MageGame()
		{
			_graphics = new GraphicsDeviceManager(this);
			Window.AllowUserResizing = true;
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}

		protected override void Initialize()
		{
			_renderTarget = new RenderTarget2D(GraphicsDevice, GameConstants.virtualWidth, GameConstants.virtualHeight);

			base.Initialize();
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);

			ballTexture = Content.Load<Texture2D>("Placeholders/ball");

			ballA = new SpritedEntity(50, 50, ballTexture, "C");
			ballB = new SpritedEntity(100, 100, ballTexture, "C");
			ballC = new SpritedEntity(150, 150, ballTexture, "C");


		}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

            // TODO: Add your update logic here
		}

		protected override void Draw(GameTime gameTime)
		{

			//virtual rendering
			GraphicsDevice.SetRenderTarget(_renderTarget);
			GraphicsDevice.Clear(Color.Turquoise);


			_spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp);

			ballA.Draw(_spriteBatch);
			ballB.Draw(_spriteBatch);
			ballC.Draw(_spriteBatch);

			_spriteBatch.Draw(ballTexture, new Vector2(0, 0), null, Color.White, 0, new Vector2(0, 0), 1, SpriteEffects.None, 0.5f);

			_spriteBatch.End();




			//TODO : make black bars around game when resolution demands it
			float windowWidth = GraphicsDevice.Viewport.Width;
			float blackWidth = 1;

			//scaling of render target 
			GraphicsDevice.SetRenderTarget(null);
			_spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp);
			_spriteBatch.Draw(_renderTarget, GraphicsDevice.Viewport.Bounds, Color.White);
			_spriteBatch.End();

			
		}
	}
}