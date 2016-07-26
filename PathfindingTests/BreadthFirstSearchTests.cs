using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pathfinding;

namespace PathfindingTests
{
    [TestClass]
    public class BreadthFirstSearchTests
    {
        private BreadthFirstSearch search;

        [TestInitialize]
        public void Initialize()
        {
            search = new BreadthFirstSearch();
        }

        [TestMethod]
        public void AllSpacesOpen()
        {
            Map map = new Map("Level1");
            var points = search.SearchDistance(map, new Point(0, 0));
            Assert.IsNotNull(points);
            Assert.AreEqual(100, points.Count);
        }

        [TestMethod]
        public void LimitMoves()
        {
            Map map = new Map("Level1");
            var points = search.SearchDistance(map, new Point(3, 3), 3);
            Assert.IsNotNull(points);
            Assert.AreEqual(1 + 4 + 4*2 + 4*3, points.Count);
            Assert.IsNotNull(points.FirstOrDefault(point =>point.Key.Equals(new Point(3, 3)) && point.Value == 0));
            Assert.IsNotNull(points.FirstOrDefault(point =>point.Key.Equals(new Point(3, 2)) && point.Value == 1));
            Assert.IsNotNull(points.FirstOrDefault(point =>point.Key.Equals(new Point(4, 3)) && point.Value == 1));
            Assert.IsNotNull(points.FirstOrDefault(point =>point.Key.Equals(new Point(3, 4)) && point.Value == 1));
            Assert.IsNotNull(points.FirstOrDefault(point =>point.Key.Equals(new Point(2, 3)) && point.Value == 1));
            Assert.IsNotNull(points.FirstOrDefault(point =>point.Key.Equals(new Point(3, 1)) && point.Value == 2));
            Assert.IsNotNull(points.FirstOrDefault(point =>point.Key.Equals(new Point(4, 2)) && point.Value == 2));
            Assert.IsNotNull(points.FirstOrDefault(point =>point.Key.Equals(new Point(5, 3)) && point.Value == 2));
            Assert.IsNotNull(points.FirstOrDefault(point =>point.Key.Equals(new Point(4, 4)) && point.Value == 2));
            Assert.IsNotNull(points.FirstOrDefault(point =>point.Key.Equals(new Point(3, 5)) && point.Value == 2));
            Assert.IsNotNull(points.FirstOrDefault(point =>point.Key.Equals(new Point(2, 4)) && point.Value == 2));
            Assert.IsNotNull(points.FirstOrDefault(point =>point.Key.Equals(new Point(1, 3)) && point.Value == 2));
            Assert.IsNotNull(points.FirstOrDefault(point =>point.Key.Equals(new Point(2, 2)) && point.Value == 2));
            Assert.IsNotNull(points.FirstOrDefault(point =>point.Key.Equals(new Point(3, 0)) && point.Value == 3));
            Assert.IsNotNull(points.FirstOrDefault(point =>point.Key.Equals(new Point(4, 1)) && point.Value == 3));
            Assert.IsNotNull(points.FirstOrDefault(point =>point.Key.Equals(new Point(5, 2)) && point.Value == 3));
            Assert.IsNotNull(points.FirstOrDefault(point =>point.Key.Equals(new Point(6, 3)) && point.Value == 3));
            Assert.IsNotNull(points.FirstOrDefault(point =>point.Key.Equals(new Point(5, 4)) && point.Value == 3));
            Assert.IsNotNull(points.FirstOrDefault(point =>point.Key.Equals(new Point(4, 5)) && point.Value == 3));
            Assert.IsNotNull(points.FirstOrDefault(point =>point.Key.Equals(new Point(3, 6)) && point.Value == 3));
            Assert.IsNotNull(points.FirstOrDefault(point =>point.Key.Equals(new Point(2, 5)) && point.Value == 3));
            Assert.IsNotNull(points.FirstOrDefault(point =>point.Key.Equals(new Point(1, 4)) && point.Value == 3));
            Assert.IsNotNull(points.FirstOrDefault(point =>point.Key.Equals(new Point(0, 3)) && point.Value == 3));
            Assert.IsNotNull(points.FirstOrDefault(point =>point.Key.Equals(new Point(1, 2)) && point.Value == 3));
            Assert.IsNotNull(points.FirstOrDefault(point =>point.Key.Equals(new Point(2, 1)) && point.Value == 3));
        }

        [TestMethod]
        public void IgnoresBlockedSpaces()
        {
            Map map = new Map("Level2");
            var points = search.SearchDistance(map, new Point(0, 0), 10);
            Assert.IsNotNull(points);
            Assert.AreEqual(1, points.Count);
            Assert.IsNotNull(points[new Point(0, 0)]);
        }

        [TestMethod]
        public void NoMovesLeft()
        {
            Map map = new Map("Level1");
            var points = search.SearchDistance(map, new Point(0, 0), 0);
            Assert.IsNotNull(points);
            Assert.AreEqual(1, points.Count);
            Assert.IsNotNull(points[new Point(0, 0)]);
        }

        [TestMethod]
        public void PathSearch()
        {
            Map map = new Map("Level3");
            Stack<Point> path = search.SearchPath(map, new Point(0, 0), new Point(2, 1));
            Assert.IsNotNull(path);
            Assert.AreEqual(5, path.Count);
            Assert.AreEqual(new Point(0,0), path.Pop());
            Assert.AreEqual(new Point(0,1), path.Pop());
            Assert.AreEqual(new Point(0,2), path.Pop());
            Assert.AreEqual(new Point(1,2), path.Pop());
            Assert.AreEqual(new Point(2,2), path.Pop());
        }

        [TestMethod]
        public void PathSearch_StartOutOfBounds()
        {
            Map map = new Map("Level3");
            Stack<Point> path = search.SearchPath(map, new Point(50, 50), new Point(0, 0));
            Assert.IsNull(path);
        }

        [TestMethod]
        public void PathSearch_GoalOutOfBounds()
        {
            Map map = new Map("Level3");
            Stack<Point> path = search.SearchPath(map, new Point(0, 0), new Point(50, 50));
            Assert.IsNull(path);
        }

        [TestMethod]
        public void PathSearch_StartIsNull()
        {
            Map map = new Map("Level3");
            Stack<Point> path = search.SearchPath(map, null, new Point(50, 50));
            Assert.IsNull(path);
        }

        [TestMethod]
        public void PathSearch_GoalIsNull()
        {
            Map map = new Map("Level3");
            Stack<Point> path = search.SearchPath(map, new Point(0, 0), null);
            Assert.IsNull(path);
        }

        [TestMethod]
        public void PathSearch_StartIsUnpassable()
        {
            Map map = new Map("Level3");
            Stack<Point> path = search.SearchPath(map, new Point(1, 0), new Point(5, 5));
            Assert.IsNull(path);
        }

        [TestMethod]
        public void PathSearch_GoalIsUnpassable()
        {
            Map map = new Map("Level3");
            Stack<Point> path = search.SearchPath(map, new Point(0, 0), new Point(1, 0));
            Assert.IsNull(path);
        }

        [TestMethod]
        public void PathSearch_GoalImpossibleToReach()
        {
            Map map = new Map("Level3");
            Stack<Point> path = search.SearchPath(map, new Point(0, 0), new Point(6, 7));
            Assert.IsNull(path);
        }
    }
}