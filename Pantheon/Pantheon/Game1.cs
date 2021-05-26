using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Pantheon.Core;
using Pantheon.Sprites;
using System;

namespace Pantheon
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Camera _camera;

        private List<Component> _components;

        private PlayerChar _player;

        EnemyChar _enemy;

        Texture2D _background;

        public static int ScreenHeight;

        public static int ScreenWidth;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            ScreenHeight = _graphics.PreferredBackBufferHeight;
            ScreenWidth = _graphics.PreferredBackBufferWidth;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _camera = new Camera();

            _enemy = new EnemyChar(Content.Load<Texture2D>("Sprites/Enemy"));
            _player = new PlayerChar(Content.Load<Texture2D>("Player"));
            _background = Content.Load<Texture2D>("Background/Background");

            _components = new List<Component>()
            {
                _enemy,
                _player,
            };
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            foreach (var component in _components)
                component.Update(gameTime);

            _camera.Follow(_player);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(transformMatrix: _camera.Transform);

            _spriteBatch.Draw(_background, new Rectangle(-ScreenWidth / (3 + 1 / 2), -ScreenHeight / 4 * 3, ScreenWidth * 3 / 2, ScreenHeight * 3 / 2), Color.White);

            foreach (var component in _components)
                component.Draw(gameTime, _spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
