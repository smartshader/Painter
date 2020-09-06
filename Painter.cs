using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Painter
{
    public class Painter : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D _background;
        private Texture2D _balloon;

        private Vector2 _balloonPosition;

        public Painter()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _balloon = Content.Load<Texture2D>("spr_lives");
            _background = Content.Load<Texture2D>("spr_background");
            MediaPlayer.Play(Content.Load<Song>("snd_music"));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            MouseState currentMouseState = Mouse.GetState();
            _balloonPosition = new Vector2(currentMouseState.X - _balloon.Width / 2,
                currentMouseState.Y - _balloon.Height);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(_background, Vector2.Zero, Color.White);
            _spriteBatch.Draw(_balloon, _balloonPosition, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
