using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using System;

using UntitledMagusProject.EntityClasses;
using UntitledMagusProject.Implementations;
using UntitledMagusProject.Implementations.Entities;

namespace UntitledMagusProject
{
	public class MageGame : Game
	{
		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;
		private RenderTarget2D _renderTarget; //used for virtual resolution

		private Wizard wizard;


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
			//initialize sprite batch + our universal sprite loader
			_spriteBatch = new SpriteBatch(GraphicsDevice);
			SpriteLoader.initializeSpriteLoader(Content);

			//now create the important entities
			wizard = new Wizard(new Vector2(100, 100));


		}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			// TODO: Add your update logic here
			wizard.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{

			//virtual rendering
			GraphicsDevice.SetRenderTarget(_renderTarget);
			GraphicsDevice.Clear(Color.Turquoise);


			_spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp);

			//DRAW LOGIC GOES HERE
			wizard.Draw(_spriteBatch);

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