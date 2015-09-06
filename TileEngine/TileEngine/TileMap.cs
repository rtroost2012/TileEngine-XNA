using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TileEngine
{
    class TileMap
    {
        public List<MapRow> rows = new List<MapRow>();
        public int mapWidth = 50;
        public int mapHeight = 50;

        public TileMap()
        {
            // Fill the map with dummy cells
            for (int y = 0; y < mapHeight; y++)
            {
                MapRow row = new MapRow();

                for (int x = 0; x < mapWidth; x++)
                {
                    // Add a new cell with Tile ID 0 to the current row
                    MapCell cell = new MapCell(0);
                    row.columns.Add(cell);
                }
                rows.Add(row);
            }

            // Create Sample Map Data
            rows[0].columns[3].tileID = 3;
            rows[0].columns[4].tileID = 3;
            rows[0].columns[5].tileID = 1;
            rows[0].columns[6].tileID = 1;
            rows[0].columns[7].tileID = 1;

            rows[1].columns[3].tileID = 3;
            rows[1].columns[4].tileID = 1;
            rows[1].columns[5].tileID = 1;
            rows[1].columns[6].tileID = 1;
            rows[1].columns[7].tileID = 1;

            rows[2].columns[2].tileID = 3;
            rows[2].columns[3].tileID = 1;
            rows[2].columns[4].tileID = 1;
            rows[2].columns[5].tileID = 1;
            rows[2].columns[6].tileID = 1;
            rows[2].columns[7].tileID = 1;

            rows[3].columns[2].tileID = 3;
            rows[3].columns[3].tileID = 1;
            rows[3].columns[4].tileID = 1;
            rows[3].columns[5].tileID = 2;
            rows[3].columns[6].tileID = 2;
            rows[3].columns[7].tileID = 2;

            rows[4].columns[2].tileID = 3;
            rows[4].columns[3].tileID = 1;
            rows[4].columns[4].tileID = 1;
            rows[4].columns[5].tileID = 2;
            rows[4].columns[6].tileID = 2;
            rows[4].columns[7].tileID = 2;

            rows[5].columns[2].tileID = 3;
            rows[5].columns[3].tileID = 1;
            rows[5].columns[4].tileID = 1;
            rows[5].columns[5].tileID = 2;
            rows[5].columns[6].tileID = 2;
            rows[5].columns[7].tileID = 2;

            // End Create Sample Map Data
        }

    }

    class MapRow
    {
        public List<MapCell> columns = new List<MapCell>();
    }
}
