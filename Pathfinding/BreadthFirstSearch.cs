using System.Collections.Generic;

namespace Pathfinding
{
    public class BreadthFirstSearch
    {
        public Dictionary<Point, int> SearchDistance(Map map, Point origin)
        {
            return SearchDistance(map, origin, null);
        }

        public Dictionary<Point, int> SearchDistance(Map map, Point origin, int? maxMoves)
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

        public Stack<Point> SearchPath(Map map, Point origin, Point goal)
        {
            if (map == null || origin == null || goal == null || !map.InBounds(origin) ||
                    !map.InBounds(goal) || !map[origin.x, origin.y].IsPassable ||
                    !map[goal.x, goal.y].IsPassable)
            {
                return null;
            }

            Queue<Point> frontier = new Queue<Point>();
            frontier.Enqueue(origin);
            Dictionary<Point, Point> cameFrom = new Dictionary<Point, Point>();
            bool currentFound = false;

            while (frontier.Count != 0)
            {
                Point current = frontier.Dequeue();

                if (current.Equals(goal))
                {
                    currentFound = true;
                    break;
                }

                foreach (Point neighbor in map.Neighbors(current))
                {
                    if (!cameFrom.ContainsKey(neighbor) && map[neighbor.x, neighbor.y].IsPassable)
                    {
                        frontier.Enqueue(neighbor);
                        cameFrom.Add(neighbor, current);
                    }
                }
            }
            if (!currentFound)
            {
                return null;
            }
            return GetPathFromSearch(cameFrom, origin, goal);
        }

        public Stack<Point> GetPathFromSearch(Dictionary<Point, Point> spaces, Point start, Point goal)
        {
            Point current = goal;
            Stack<Point> path = new Stack<Point>();
            while (!current.Equals(start))
            {
                current = spaces[current];
                path.Push(current);
            }
            return path;
        }
    }
}