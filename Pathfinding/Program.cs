using System.Collections.Generic;

namespace Pathfinding
{
    class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map("Level1");
            BreadthFirstSearch search = new BreadthFirstSearch();
            Dictionary<Point, int> moves = search.SearchDistance(map, new Point(0,0), 7);
            var path = search.SearchPath(map, new Point(0, 0), new Point(5, 5));
        }
    }
}
