using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pantheon
{
    public class Game1 : Game
    {
        int Slow = 50;

        Texture2D Background;
        Vector2 BackgroundPosition;

        Texture2D Char;
        Vector2 CharPosition;
        float CharSpeed;
        float CharWalkSpeed = 150f;
        float CharRunSpeed = 225f;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            CharPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            BackgroundPosition = new Vector2(1000, 1000);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Char = Content.Load<Texture2D>("sprites/player");
            Background = Content.Load<Texture2D>("background/background");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.W))
                CharPosition.Y -= CharSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (kstate.IsKeyDown(Keys.S))
                CharPosition.Y += CharSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (kstate.IsKeyDown(Keys.A))
                CharPosition.X -= CharSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (kstate.IsKeyDown(Keys.D))
                CharPosition.X += CharSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.LeftShift))
                CharSpeed = CharRunSpeed;
            else
                CharSpeed = CharWalkSpeed;

            if (kstate.IsKeyDown(Keys.LeftControl) && kstate.IsKeyDown(Keys.LeftShift))
                CharSpeed = CharRunSpeed - Slow;
            else if (kstate.IsKeyDown(Keys.LeftControl))
                CharSpeed = CharWalkSpeed - Slow;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(Background, new Rectangle(0, 0, 800, 420), Color.White);
            _spriteBatch.Draw(
                Char,
                CharPosition,
                null,
                Color.White,
                0f,
                new Vector2(Char.Width / 2, Char.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
