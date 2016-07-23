using System.Collections.Generic;

namespace Pathfinding
{
    public class BreadthFirstSearch
    {
        public Dictionary<Point, int> Search(Grid grid, Point origin)
        {
            return Search(grid, origin, null);
        }

        public Dictionary<Point, int> Search(Grid grid, Point origin, int? maxMoves)
        {
            if (grid == null || origin == null || !grid.InBounds(origin))
            {
                return null;
            }

            Queue<Point> frontier = new Queue<Point>();
            frontier.Enqueue(origin);
            Dictionary<Point, int> distance = new Dictionary<Point, int>();
            distance.Add(origin, 0);

            while (frontier.Count != 0)
            {
                Point current = frontier.Dequeue();
                foreach (Point neighbor in grid.Neighbors(current))
                {
                    if (!distance.ContainsKey(neighbor))
                    {
                        int length = distance[current] + 1;
                        if (length > maxMoves)
                        {
                            continue;
                        }
                        frontier.Enqueue(neighbor);
                        distance.Add(neighbor, length);
                    }
                }
            }
            return distance;
        }
    }
}