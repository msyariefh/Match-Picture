namespace HiDE.Matcher.Gameplay
{
    public struct TileInfo
    {
        public int Value { get; private set; }
        public Coordinate2D Coordinate { get; private set; }
        public bool Assigned { get; set; }
        public TileInfo(int value, Coordinate2D coordinate)
        {
            Value = value;
            Coordinate = coordinate;
            Assigned = true;
        }
        
    }
}
