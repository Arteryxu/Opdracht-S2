using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pantheon.Sprites
{
    class EnemyChar : Sprite
    {
        public Vector2 velocity;
        public float speed;



        public EnemyChar(Texture2D texture)
            : base(texture)
        {

        }

        public override void Update(GameTime gameTime)
        {
            velocity = new Vector2();
            speed = 2f;
            if (EnemyPosition.X > CharPosition.X)
            {
                velocity.X -= speed;
            }
            if (EnemyPosition.X < CharPosition.X)
            {
                velocity.X += speed;
            }
            if (EnemyPosition.Y > CharPosition.Y)
            {
                velocity.Y -= speed;
            }
            if (EnemyPosition.Y < CharPosition.Y)
            {
                velocity.Y += speed;
            }

            EnemyPosition += velocity;
        }
    }
}
