using static Struct结构体.Program;

namespace Struct结构体
{
    internal class Program
    {
        public struct Classmate
        {
            string name;
            string sex;
            int age;
            string classroom;
            string professional;

            public Classmate(string name, string sex, int age, string classroom, string professional)
            {
                this.name = name;
                this.sex = sex;
                this.age = age;
                this.classroom = classroom;
                this.professional = professional;
            }
        }

        public struct Rectangle
        {
            int length;
            int width;

            public Rectangle(int length, int width)
            {
                this.length = length;
                this.width = width;
            }

            public void Calculate()
            {
                Console.WriteLine("长宽分别是{0} {1},周长是{2},面基是{3}", length, width, (length + width) * 2, length * width);
            }
        }

        public struct GameRole
        {
            public string name;
            public string role;
            public string skill;

            public void Display()
            {
                if (string.IsNullOrEmpty(role) && string.IsNullOrEmpty(skill) && string.IsNullOrEmpty(name)) return;



                Console.WriteLine("你的游戏角色姓名是{0},你的职业为{1},附带有技能{2}", name, role, skill);
            }
        }

        public struct Monster
        {
            public int attack;
            public int defense;
            public int health;
            public string name;

            public Monster(int attack, int defense, int health, string name)
            {
                this.attack = attack;
                this.defense = defense;
                this.health = health;
                this.name = name;
            }

            public void Attack(SuperMan superMan)
            {
                bool canAttack = attack > superMan.defense;

                if (canAttack)
                {
                    superMan.health -= attack;

                    Console.WriteLine("小怪兽对奥特曼造成了{0}的伤害,它的血量还有{1}", attack, superMan.health);
                }
                else
                {
                    Console.WriteLine("{0}的攻击太低了,完全打不动", name);
                }

            }
        }

        public struct SuperMan
        {
            public int attack;
            public int defense;
            public int health;
            public string name;

            public SuperMan(int attack, int defense, int health, string name)
            {
                this.attack = attack;
                this.defense = defense;
                this.health = health;
                this.name = name;
            }

            public void Attack(Monster monster)
            {
                bool canAttack = attack > monster.defense;

                if (canAttack)
                {
                    monster.health -= attack;

                    Console.WriteLine("奥特曼ouda小怪兽造成了{0}的伤害,它的血量还有{1}", attack, monster.health);
                }
                else
                {
                    Console.WriteLine("{0}的攻击太低了,完全打不动", name);
                }

            }
        }

        static void Main(string[] args)
        {
            Classmate mrWang = new Classmate("王", "男", 18, "二班", "艺术与文化");

            Classmate mrKang = new Classmate("康", "男", 28, "三班", "艺术与文化");

            Rectangle rectangle = new Rectangle(5, 4);
            rectangle.Calculate();

            GameRole player = new GameRole();
            while (true)
            {
                try
                {

                    Console.WriteLine("请输入你的姓名");
                    player.name = Console.ReadLine();
                    Console.WriteLine("选择你的职业,0:战士,1:猎人,2:法师");
                    if (int.TryParse(Console.ReadLine(), out int choice))
                    {
                        switch (choice)
                        {
                            case 0:
                                player.role = "战士";
                                player.skill = "冲锋";
                                break;
                            case 1:
                                player.role = "猎人";
                                player.skill = "冲锋22";
                                break;
                            case 2:
                                player.role = "法师";
                                player.skill = "冲锋3333";
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("请输入正确的数字");
                    }

                    if (!string.IsNullOrEmpty(player.skill))
                    {
                        break;
                    }


                }
                catch (Exception)
                {

                    Console.WriteLine("请输入正确的数字");
                }
            }
            player.Display();

            Monster[] monsters = new Monster[10];
            for (int i = 0; i < 10; i++)
            {
                monsters[i] = new Monster(50 + i * 5, 50, 150, "小怪兽" + i);
            }

            for (int i = 0; i < 10; i++)
            {
                Console.Write(monsters[i].name + "攻击力是" + monsters[i].attack + " ");
            }
            Monster monster = new Monster(50, 50, 150, "怪兽一号");
            SuperMan superMan = new SuperMan(60, 50, 150, "奥特曼1号");
            superMan.Attack(monster);

        }
    }
}
