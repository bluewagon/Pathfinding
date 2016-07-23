using System.Collections.Generic;

namespace Pathfinding
{
    public class BreadthFirstSearch
    {
        public Dictionary<Point, int> Search(Grid grid, Point origin)
        {
            Queue<Point> frontier = new Queue<Point>();
            frontier.Enqueue(origin);
            Dictionary<Point, int> distance = new Dictionary<Point, int> { {origin, 0} };

            while (frontier.Count != 0)
            {
                Point current = frontier.Dequeue();
                foreach (Point neighbor in grid.Neighbors(current))
                {
                    if (!distance.ContainsKey(neighbor))
                    {
                        frontier.Enqueue(neighbor);
                        distance.Add(neighbor, 1 + distance[current]);
                    }
                }
            }
            return distance;
        }
    }
}