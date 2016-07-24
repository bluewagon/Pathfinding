using System.Collections.Generic;

namespace Pathfinding
{
    public class BreadthFirstSearch
    {
        public Dictionary<Point, int> Search(Map map, Point origin)
        {
            return Search(map, origin, null);
        }

        public Dictionary<Point, int> Search(Map map, Point origin, int? maxMoves)
        {
            if (map == null || origin == null)
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
                foreach (Point neighbor in map.Neighbors(current))
                {
                    if (!distance.ContainsKey(neighbor) && map[neighbor.x, neighbor.y].IsPassable)
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