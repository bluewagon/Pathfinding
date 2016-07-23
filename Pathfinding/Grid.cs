using System.Collections.Generic;
using System.IO;

namespace Pathfinding
{
    public class Grid
    {
        private List<List<Point>> board;
        private int sizeX;
        private int sizeY;
        public static readonly Point[] DIRS = new[]
        {
            new Point(1, 0),
            new Point(0, -1),
            new Point(-1, 0),
            new Point(0, 1)
        };

        public Grid(int sizeX, int sizeY)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            board = new List<List<Point>>();
            for (int x = 0; x < sizeX; x++)
            {
                board.Add(new List<Point>());
                for (int y = 0; y < sizeY; y++)
                {
                    board[x].Add(new Point(x, y));
                }
            }
        }

        public Grid(string levelName)
        {
            List<List<Point>> map = new List<List<Point>>();
            using (StreamReader reader = File.OpenText($"Maps\\{levelName}.txt"))
            {
                string line;
                int size_y = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    map.Add(new List<Point>());
                    int size_x = line.Length;
                    int x = 0;
                    foreach (char c in line)
                    {
                        map[size_y].Add(new Point(x, size_y));
                        x++;
                    }
                    size_y++;
                }
            }
        }

        public bool InBounds(int x, int y)
        {
            return 0 <= x && x < sizeX
                && 0 <= y && y < sizeY;
        }

        public bool InBounds(Point point)
        {
            return InBounds(point.x, point.y);
        }

        public IEnumerable<Point> Neighbors(Point origin)
        {
            foreach (Point point in DIRS)
            {
                int x = origin.x + point.x;
                int y = origin.y + point.y;
                if (InBounds(x, y))
                {
                    Point next = board[x][y];
                    yield return next;
                }
            }
        }
    }
}