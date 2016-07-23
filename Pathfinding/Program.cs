using System.Collections.Generic;

namespace Pathfinding
{
    class Program
    {
        static void Main(string[] args)
        {
            Grid grid = new Grid(10, 10);
            BreadthFirstSearch search = new BreadthFirstSearch();
            Dictionary<Point, int> moves = search.Search(grid, new Point(0,0));
        }
    }
}
