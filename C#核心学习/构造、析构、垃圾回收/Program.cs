namespace 构造_析构_垃圾回收
{
    internal class Program
    {
        public class Player
        {
            private string name;
            private int health;
            private Weapon weapon;

            public Player() : this("bob", 50)
            {
            }

            public Player(string name, int health, Weapon weapon) : this(name, health)
            {
                this.weapon = weapon;
            }

            // 构造函数
            public Player(string name, int health)
            {
                this.name = name;
                this.health = health;
                this.weapon = new Weapon("剑", 10);
                Console.WriteLine($"{name} 进入了游戏！");
            }

            // 析构函数
            ~Player()
            {
                Console.WriteLine($"{name} 退出了游戏！");
            }

            public void Attack(Player target)
            {
                Console.WriteLine($"{name} 使用 {weapon.Name} 攻击了 {target.name}，造成 {weapon.Damage} 点伤害！");
                target.health -= weapon.Damage;
            }
        }

        public class Weapon
        {
            public string Name { get; }
            public int Damage { get; }

            public Weapon(string name, int damage)
            {
                Name = name;
                Damage = damage;
            }
        }

        public class Classes
        {

            public string className;
            public int totalTeacherNumber;
            public Classes() : this("Biology", 25)
            {
            }
            public Classes(string className, int totalTeacherNumber)
            {
                this.className = className;
                this.totalTeacherNumber = totalTeacherNumber;
            }
        }

        public class Ticket
        {
            private uint distance;
            private float price;

            public Ticket(uint distance)
            {
                if (distance <= 0)
                {
                    Console.WriteLine("初始化失败,距离为0");
                    return;
                }
                this.distance = distance;
            }
            public void GetPrice()
            {
                if (distance < 100)
                {
                    price = distance * 1;

                }
                else if (distance < 200)
                {
                    price = distance * 0.95f;
                }
                else if (distance < 300)
                {
                    price = distance * 0.9f;
                }
                else
                {
                    price = distance * 0.8f;
                }
                Console.WriteLine($"票价是{price}");

            }
        }
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            // 使用示例
            Player player1 = new Player("勇士", 100);
            Player player2 = new Player("法师", 80);
            Player player3 = new Player();
            player1.Attack(player2);
            Classes classes = new Classes();
            Console.WriteLine(classes.className + classes.totalTeacherNumber);
            Ticket ticket = new Ticket(0);
            Ticket ticket2 = new Ticket(350);
            ticket2.GetPrice();
        }
    }
}
