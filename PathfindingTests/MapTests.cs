using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pathfinding;

namespace PathfindingTests
{
    [TestClass]
    public class MapTests
    {
        private Map map;

        [TestInitialize]
        public void Initialize()
        {
            map = new Map("Level1");
            Assert.IsNotNull(map);
        }

        [TestMethod]
        public void LoadsMap()
        {
            map.LoadMap("Level2");
            Assert.IsNotNull(map);
            // Level1 is 10x10 so make so it can access very last
            Assert.IsNotNull(map[9, 9]);
        }

        [TestMethod]
        public void UsesCorrectXY()
        {
            // since in the grid, the first is actually Y and second X grid[y][x], make sure its
            // being accessed right by looking for blocks in [x][y] specific points
            map.LoadMap("Level2");
            Assert.IsFalse(map[4, 0].IsPassable);
            Assert.IsFalse(map[1, 8].IsPassable);
        }

        [TestMethod]
        public void NeighborsAllInBounds()
        {
            List<Point> neighbors = map.Neighbors(new Point(3, 4)).ToList();
            Assert.IsNotNull(neighbors);
            Assert.AreEqual(4, neighbors.Count);
            Assert.IsTrue(neighbors.Any(point => point.Equals(new Point(3, 3))));
            Assert.IsTrue(neighbors.Any(point => point.Equals(new Point(4, 4))));
            Assert.IsTrue(neighbors.Any(point => point.Equals(new Point(3, 5))));
            Assert.IsTrue(neighbors.Any(point => point.Equals(new Point(2, 4))));
        }

        [TestMethod]
        public void NeighbordsIgnoresOutOfBoundTiles()
        {
            List<Point> neighbors = map.Neighbors(new Point(0, 0)).ToList();
            Assert.IsNotNull(neighbors);
            Assert.AreEqual(2, neighbors.Count);
            Assert.IsTrue(neighbors.Any(point => point.Equals(new Point(0, 1))));
            Assert.IsTrue(neighbors.Any(point => point.Equals(new Point(1, 0))));
        }

        [TestMethod]
        public void InBounds()
        {
            Point point = new Point(0, 0);
            Assert.IsTrue(map.InBounds(point));
            point = new Point(-1, 0);
            Assert.IsFalse(map.InBounds(point));
            point = new Point(250, 0);
            Assert.IsFalse(map.InBounds(point));
            point = new Point(0, 250);
            Assert.IsFalse(map.InBounds(point));
        }
    }
}
