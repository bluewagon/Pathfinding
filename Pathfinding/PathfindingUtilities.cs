using System.Collections.Generic;

namespace Pathfinding
{
    public class PathfindingUtilities
    {
        public static Stack<Point> GetPathFromSearch(Dictionary<Point, Point> spaces, Point start, Point goal)
        {
            if (!spaces.ContainsKey(goal) || !spaces.ContainsValue(start))
            {
                return null;
            }

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