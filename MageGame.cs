using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace UntitledMagusProject
{
	public class MageGame : Game
	{
		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;
		private RenderTarget2D _renderTarget; //used for virtual resolution

		private Texture2D ballSprite;

		public MageGame()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}

		protected override void Initialize()
		{
			// TODO: Add your initialization logic here
			_renderTarget = new RenderTarget2D(GraphicsDevice, GameConstants.screenWidth, GameConstants.screenHeight);

			base.Initialize();
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);

			// TODO: use this.Content to load your game content here
			ballSprite = Content.Load<Texture2D>("Placeholders/ball");
		}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			// TODO: Add your update logic here

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.SetRenderTarget(_renderTarget);
			GraphicsDevice.Clear(Color.White);

			_spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp);

			_spriteBatch.Draw(ballSprite, new Vector2(0, 0), null, Color.Black, 0, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.None, 0);
			_spriteBatch.Draw(ballSprite, new Rectangle(0, 0, 384, 216), Color.White);
			_spriteBatch.Draw(ballSprite, new Vector2(20, 20), null, Color.White, 0, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.None, 1);

			_spriteBatch.End();

			



			GraphicsDevice.SetRenderTarget(null); // Backbuffer

			_spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp);
			_spriteBatch.Draw(_renderTarget, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
			_spriteBatch.End();




			base.Draw(gameTime);
		}
	}
}