using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Pantheon.Sprites;

namespace Pantheon.Core
{
    public class Camera
    {
        public Matrix Transform { get; private set; }

        public void Follow(Sprites.Sprite player)
        {
            var position = Matrix.CreateTranslation(
                    Game1.ScreenWidth / 2,
                    Game1.ScreenHeight / 2,
                    0);

            var offset = Matrix.CreateTranslation(
                -player.CharPosition.X - (player.Rectangle.Width / 2),
                -player.CharPosition.Y - (player.Rectangle.Height / 2),
                0);
            Transform = position * offset;
        }
    }
}
