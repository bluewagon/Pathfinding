using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pathfinding;

namespace PathfindingTests
{
    [TestClass]
    public class PathfindingUtilitiesTests
    {
        private Dictionary<Point, Point> spaces;

        [TestInitialize]
        public void Initialize()
        {
            spaces = new Dictionary<Point, Point>()
            {
                { new Point(1, 0), new Point(0, 0) },
                { new Point(2, 0), new Point(1, 0) },
                { new Point(3, 0), new Point(2, 0) },
                { new Point(3, 1), new Point(3, 0) },
                { new Point(0, 1), new Point(0, 0) },
                { new Point(1, 1), new Point(0, 1) },
                { new Point(2, 1), new Point(1, 1) },
            };
        }

        [TestMethod]
        public void GetPathFromSearch()
        {
            Stack<Point> path = PathfindingUtilities.GetPathFromSearch(spaces, new Point(0, 0), new Point(3, 1));
            Assert.IsNotNull(path);
            Assert.AreEqual(4, path.Count);
            Assert.AreEqual(new Point(0, 0), path.Pop());
            Assert.AreEqual(new Point(1, 0), path.Pop());
            Assert.AreEqual(new Point(2, 0), path.Pop());
            Assert.AreEqual(new Point(3, 0), path.Pop());
        }

        [TestMethod]
        public void GetPathFromSearch_ReturnsNullForMissingGoal()
        {
            Stack<Point> path = PathfindingUtilities.GetPathFromSearch(spaces, new Point(0, 0), new Point(8, 1));
            Assert.IsNull(path);
        }

        [TestMethod]
        public void GetPathFromSearch_ReturnsNullForMissingStart()
        {
            Stack<Point> path = PathfindingUtilities.GetPathFromSearch(spaces, new Point(8, 0), new Point(1, 1));
            Assert.IsNull(path);
        }
    }
}