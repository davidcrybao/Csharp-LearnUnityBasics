namespace _0._01Type_PlayerClass
{
    public class Class1
    {

    }
    public class Player
    {
        public string name;
        public int health;
        public int defence;
        public int attack;
        public int x,y;

        public Player()
        { }

        public Player(int x,int y,string name)
        {
            this.x = x;
            this.y = y;
            this.name = name;
        }

        public Player(int x, int y, string name, int health, int defence, int attack) : this(x,y,name)
        {
            this.health = health;
            this.defence = defence;
            this.attack = attack;
        }


        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("X");
        }
        public void Clear()
        {
            Console.SetCursorPosition(x, y);
            Console.Write("  ");
        }
    }
}
