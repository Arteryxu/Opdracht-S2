using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pantheon.Sprites
{
    public class Sprite : Component
    {
        protected Texture2D Char;
        protected Texture2D Enemy;

        public Vector2 CharPosition { get; set; }
        public Vector2 EnemyPosition { get; set; }

        public Rectangle Rectangle
        {
            get { return new Rectangle((int)CharPosition.X, (int)CharPosition.Y, Char.Width, Char.Height); }
        }

        public Rectangle EnemyRectangle
        {
            get { return new Rectangle((int)EnemyPosition.X, (int)EnemyPosition.Y, Enemy.Width, Enemy.Height); }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Char, CharPosition, Color.White);
            spriteBatch.Draw(Enemy, EnemyPosition, Color.White);
        }

        public Sprite(Texture2D texture)
        {
            Char = texture;
            Enemy = texture;
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
