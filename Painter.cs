using System;
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
        private Texture2D _cannonBarrel;

        private Vector2 _balloonPosition, _balloonOrigin;
        private Vector2 _cannonBarrelPosition, _cannonBarrelOrigin;

        private float _barrelAngle;

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
            _cannonBarrel = Content.Load<Texture2D>("spr_cannon_barrel");
            MediaPlayer.Play(Content.Load<Song>("snd_music"));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            MouseState currentMouseState = Mouse.GetState();
            _balloonOrigin = new Vector2(_balloon.Width / 2f, _balloon.Height);
            _cannonBarrelOrigin = new Vector2(_cannonBarrel.Height, _cannonBarrel.Height) / 2;
            
            _balloonPosition = new Vector2(currentMouseState.X, currentMouseState.Y);
            _cannonBarrelPosition = new Vector2(72, 405);

            _barrelAngle = (float) Math.Atan2(currentMouseState.Y - _cannonBarrelPosition.Y,
                currentMouseState.X - _cannonBarrelPosition.X);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(_background, Vector2.Zero, Color.White);
            _spriteBatch.Draw(_balloon, _balloonPosition - _balloonOrigin, Color.White);
            _spriteBatch.Draw(_cannonBarrel, _cannonBarrelPosition, null, Color.White,
                _barrelAngle, _cannonBarrelOrigin, 1.0f, SpriteEffects.None, 0);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
