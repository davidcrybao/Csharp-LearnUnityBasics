namespace _19Object的使用_万物之父中的方法
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Player player = new Player("Bob", 250, 100, 20);
            Console.WriteLine(player.ToString());
            Monster a = new Monster(25, 35, 100);
            Monster b = a.Copy();
            a.Speak();
            b.Speak();
            a.attack = 50;
            Console.WriteLine("change value");
            a.Speak();
            b.Speak();
        }
    }
    internal class Player
    {
        string playerName;
        int health;
        int attack;
        int defence;

        public Player(string playerName, int health, int attack, int defence)
        {
            this.playerName = playerName;
            this.health = health;
            this.attack = attack;
            this.defence = defence;

        }

        public override string ToString()
        {
            return $"玩家的名字是{playerName},现在生命值是{health},攻击是{attack},防御力是{defence}";
        }

    }
    internal class Monster
    {
        public int health;
        public int attack;
        public int defence;
        public int[] arrayList;

        public Monster(int health, int attack, int defence)
        {
            this.health = health;
            this.attack = attack;
            this.defence = defence;
        }
        public void Speak()
        {
            Console.WriteLine($"我的生命值攻击力防御力一次是:{health}, {attack} ,{defence}");
        }
        public Monster Copy()
        {
            return MemberwiseClone() as Monster;
        }
        public Monster DeepCopy()
        {
            var newMonster = (Monster)this.MemberwiseClone();
            newMonster.arrayList = (int[])this.arrayList.Clone();
            return newMonster;
            //相当于把里面每一个用到的引用类型,重新建立复制,然后?

        }

    }
}
