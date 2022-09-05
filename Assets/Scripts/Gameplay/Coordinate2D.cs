namespace HiDE.Matcher.Gameplay
{
    public struct Coordinate2D
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Coordinate2D(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}