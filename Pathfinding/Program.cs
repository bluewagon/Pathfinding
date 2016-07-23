using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding
{
    class Program
    {
        static void Main(string[] args)
        {
            Grid grid = new Grid(10, 10);
            BreadthFirstSearch search = new BreadthFirstSearch();
            Dictionary<Point, int> moves = search.Search(grid, new Point(5, 5));
        }
    }
}
