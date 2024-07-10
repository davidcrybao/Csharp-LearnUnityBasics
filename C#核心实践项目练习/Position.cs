namespace C_核心实践项目练习
{
    internal struct Position
    {


        public int x { get; private set; }
        public int y { get; private set; }

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static bool operator ==(Position a, Position b)
        {
            if (a.x == b.x && a.y == b.y)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool operator !=(Position a, Position b)
        {
            if (a.x == b.x && a.y == b.y)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static Position operator +(Position a, (int x, int y) b)
        {
            return new Position(a.x + b.x, a.y + b.y);
        }
        public static Position operator -(Position a, (int x, int y) b)
        {
            return new Position(a.x - b.x, a.y - b.y);
        }
    }
}
