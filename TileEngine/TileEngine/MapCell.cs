using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TileEngine
{
    class MapCell
    {
        public int tileID { get; set; }

        public MapCell(int tileID)
        {
            this.tileID = tileID;
        }
    }
}
