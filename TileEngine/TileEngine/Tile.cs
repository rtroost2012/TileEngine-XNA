using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TileEngine
{
    static class Tile
    {
        static public Texture2D TileSetTexture;

        static public Rectangle getSourceRectangle(int tileIndex)
        {
            return new Rectangle(tileIndex * 32, 0, 32, 32);
        }
    }
}
