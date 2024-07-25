namespace _0._01Type_PlayerClass
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method|AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public class MyCustomAttribute:Attribute
    {
        public string info;
        public int version;
        public MyCustomAttribute(string info,int version)
        {
            this.info = info;
            this.version = version;
        }
    }

    public class PlayerAttritube
    {
        [MyCustom("测试名字防止修改", 1)]
        public string name;

        public int health;
        public int defence;
        public int attack;
        public int x,y;

        public PlayerAttritube()
        { }

        public PlayerAttritube(int x,int y,string name)
        {
            this.x = x;
            this.y = y;
            this.name = name;
        }

        public PlayerAttritube(int x, int y, string name, int health, int defence, int attack) : this(x,y,name)
        {
            this.health = health;
            this.defence = defence;
            this.attack = attack;
        }

        [Obsolete("这是一个过时的方法,你不应该还是用他")]
        public void OldDraw()
        { 
            
        }

        [MyCustomAttribute("测试熟悉",2)]
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
