namespace C_进阶实践练习
{
    public struct Position
    {
        public int x;
        public int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static bool operator ==(Position a, Position b)
        {
            if (a.x == b.x && a.y == b.y) return true;
            return false;
        }

        public static bool operator !=(Position a, Position b)
        {
            if (a.x == b.x && a.y == b.y) return false;
            return true;
        }

        public static Position operator +(Position a, Position b)
        {
            Position temp = new Position(a.x + b.x, b.y + a.y);
            return temp;
        }
    }
}