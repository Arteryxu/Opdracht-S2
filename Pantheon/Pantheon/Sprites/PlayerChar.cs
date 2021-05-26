using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pantheon.Sprites
{
    class PlayerChar : Sprite
    {
        public Vector2 velocity;
        public float speed;

        public PlayerChar(Texture2D texture)
            : base(texture)
        {

        }

        public override void Update(GameTime gameTime)
        {
            //Player Movement
            velocity = new Vector2();
            speed = 3f;

            if (Keyboard.GetState().IsKeyDown(Keys.W))
                velocity.Y = -speed;
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                velocity.X = -speed;
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                velocity.Y = speed;
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                velocity.X = speed;

            CharPosition += velocity;
        }
    }
}
