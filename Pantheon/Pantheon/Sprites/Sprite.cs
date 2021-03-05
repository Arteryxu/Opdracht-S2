using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pantheon.Sprites
{
    public class Sprite : Component
    {
        Texture2D Background;
        Vector2 BackgroundPosition;

        Texture2D Char;
        Vector2 CharPosition;

        public Vector2 Position { get; set; }

        public Rectangle rectangle
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, Char.Width, Char.Height); }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Char, Position, Color.White);
        }

        public Sprite(Texture2D texture)
        {
            Char = texture;
        }

        public override void Update(GameTime gameTime)
        {

        }

    }
}
