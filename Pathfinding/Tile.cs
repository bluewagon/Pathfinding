namespace Pathfinding
{
    public class Tile
    {
        public Point Location { get; set; }
        public int Cost { get; set; }
        public bool IsPassable => Cost > 0;

        public Tile(Point point, int cost)
        {
            Location = point;
            Cost = cost;
        }
    }
}