using System.Collections.Generic;
using System.Runtime.InteropServices;
using Priority_Queue;

namespace Pathfinding
{
    public class DijkstraSearch
    {
        public Stack<Point> Search(Map map, Point start, Point destination)
        {
            SimplePriorityQueue<Point> frontier = new SimplePriorityQueue<Point>();
            frontier.Enqueue(start, 0);
            Dictionary<Point, Point> cameFrom = new Dictionary<Point, Point>();
            Dictionary<Point, int> costSoFar = new Dictionary<Point, int>();
            costSoFar.Add(start, 0);
            while (frontier.Count != 0)
            {
                Point current = frontier.Dequeue();
                if (current.Equals(destination))
                {
                    break;
                }

                foreach (Point neighbor in map.Neighbors(current))
                {
                    int new_cost = costSoFar[current] + map[neighbor.x, neighbor.y].Cost;
                    if (!costSoFar.ContainsKey(neighbor))
                    {
                        costSoFar.Add(neighbor, new_cost);
                        UpdateCameFrom(cameFrom, frontier, new_cost, current, neighbor);
                    }
                    else if (new_cost < costSoFar[neighbor])
                    {
                        costSoFar[neighbor] = new_cost;
                        UpdateCameFrom(cameFrom, frontier, new_cost, current, neighbor);
                    }
                }
            }

            return GetPathFromSearch(cameFrom, start, destination);
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

        private void UpdateCameFrom(Dictionary<Point, Point> cameFrom, SimplePriorityQueue<Point> frontier,
            int new_cost, Point current, Point next)
        {
            int priority = new_cost;
            frontier.Enqueue(next, priority);
            if (cameFrom.ContainsKey(next))
            {
                cameFrom[next] = current;
            }
            else
            {
                cameFrom.Add(next, current);
            }
        }
    }
}