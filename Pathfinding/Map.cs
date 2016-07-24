using System;
using System.Collections.Generic;
using System.IO;

namespace Pathfinding
{
    public class Map
    {
        private List<List<Tile>> grid;
        public Tile this[int x, int y] => grid[y][x];
        public static readonly Point[] DIRS = new[]
        {
            new Point(1, 0),
            new Point(0, -1),
            new Point(-1, 0),
            new Point(0, 1)
        };

        public Map(string levelName)
        {
            LoadMap(levelName);
        }

        public void LoadMap(string levelName)
        {
            grid = new List<List<Tile>>();
            using (StreamReader reader = File.OpenText($"Maps\\{levelName}.txt"))
            {
                string line;
                int sizeY = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    grid.Add(new List<Tile>());
                    int x = 0;
                    foreach (char c in line)
                    {
                        grid[sizeY].Add(new Tile(new Point(x, sizeY), Int32.Parse(c.ToString())));
                        x++;
                    }
                    sizeY++;
                }
            }
        }

        public bool InBounds(Point point)
        {
            return InBounds(point.x, point.y);
        }

        public bool InBounds(int x, int y)
        {
            return y >= 0 && y < grid.Count &&
                   x >= 0 && x < grid[y].Count;
        }

        public IEnumerable<Point> Neighbors(Point origin)
        {
            foreach (Point point in DIRS)
            {
                int x = origin.x + point.x;
                int y = origin.y + point.y;
                if (InBounds(x, y))
                {
                    Point next = grid[y][x].Location;
                    yield return next;
                }
            }
        }
    }
}