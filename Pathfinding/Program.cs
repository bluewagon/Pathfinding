using System.Collections.Generic;

namespace Pathfinding
{
    class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map("Level2");
            BreadthFirstSearch search = new BreadthFirstSearch();
            Dictionary<Point, int> moves = search.Search(map, new Point(0,0), 7);
        }
    }
}
