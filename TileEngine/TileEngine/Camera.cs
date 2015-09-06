using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TileEngine
{
    class Camera
    {
        private TileMap map;
        private int squaresDown;
        private int squaresAcross;

        public Vector2 location = Vector2.Zero;

        public Camera(TileMap map, int squaresDown, int squaresAcross)
        {
            this.map = map;
            this.squaresDown = squaresDown;
            this.squaresAcross = squaresAcross;
        }

        public void moveUp()
        {
            location.Y = MathHelper.Clamp(location.Y - 2, 0, (map.mapHeight - squaresDown) * 32);
        }

        public void moveDown()
        {
            location.Y = MathHelper.Clamp(location.Y + 2, 0, (map.mapHeight - squaresDown) * 32);
        }

        public void moveLeft()
        {
            location.X = MathHelper.Clamp(location.X - 2, 0, (map.mapWidth - squaresAcross) * 32);
        }

        public void moveRight()
        {
            location.X = MathHelper.Clamp(location.X + 2, 0, (map.mapWidth - squaresAcross) * 32);
        }
    }
}
