using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pathfinding;

namespace PathfindingTests
{
    [TestClass]
    public class DijkstraSearchTests
    {
        [TestMethod]
        public void TakesLowerCostRoute()
        {
            Map map = new Map("Level1");
            DijkstraSearch dijkstraSearch = new DijkstraSearch();
            var path = dijkstraSearch.Search(map, new Point(0, 0), new Point(4, 0));
            Assert.IsNotNull(path);
            Assert.AreEqual(6, path.Count);
            Assert.AreEqual(new Point(0,0), path.Pop());
            Assert.AreEqual(new Point(0,1), path.Pop());
            Assert.AreEqual(new Point(1,1), path.Pop());
            Assert.AreEqual(new Point(2,1), path.Pop());
            Assert.AreEqual(new Point(3,1), path.Pop());
            Assert.AreEqual(new Point(4,1), path.Pop());
        }

        [TestMethod]
        public void IgnoresObstacles()
        {
            Map map = new Map("Level3");
            DijkstraSearch dijkstraSearch = new DijkstraSearch();
            var path = dijkstraSearch.Search(map, new Point(0, 0), new Point(6, 1));
            Assert.IsNotNull(path);
            Assert.IsFalse(path.Contains(new Point(1, 0)));
            Assert.IsFalse(path.Contains(new Point(1, 1)));
            Assert.IsFalse(path.Contains(new Point(5, 1)));
        }
    }
}