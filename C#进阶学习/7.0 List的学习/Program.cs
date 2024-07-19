
using System.Threading.Tasks;

namespace _7._0_List的学习
{

    public class TaskManager


    {
        public List<string> tasks;
        
        public TaskManager()
        {
            tasks = new List<string>();
        }
        public void Add(string task)
        {
            tasks.Add(task);
            Console.WriteLine($"任务 '{task}' 已添加。");
        }

        public void Remove(string task)
        {
            if (tasks.Count<=0)
            {
                Console.WriteLine("没有任务可以移除");
                return;
            }
            else
            {
                tasks.Remove(task);
            }

        }
        public bool Find(string task)
        {
            if (tasks.Count <= 0)
            {
                Console.WriteLine("a你都没任务啊查找什么?");
                return false;
            }
            else
            {
                Console.WriteLine("查询中");
                return tasks.Contains(task);
            }
        }

        public void Display()
        {
            if (tasks.Count <= 0)
            {
                Console.WriteLine("你都没任务啊!!!!!!!");
                return ;
            }
            else
            {
                Console.WriteLine("任务有:");
                for (int i = 0; i < tasks.Count; i++)
                {
                    Console.WriteLine(tasks[i]);
                }
            }

        }

    }

    public abstract class Monster
    {
        public static List<Monster> monsters1;
        static Monster()
        {
            monsters1 = new List<Monster>();
        }
        public Monster()
        {
            monsters1.Add(this);
        }
        public abstract void Attack();
 
    }

  
    public class Boss : Monster
    {
        public override void Attack()
        {
            Console.WriteLine("Boss Attack");
        }
    }
    public class Goblin : Monster
    {
        public override void Attack()
        {
            Console.WriteLine("Goblin Attack");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> ints = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            ints.RemoveAt(5);
            for (int i = 0; i < ints.Count; i++)
            {
                Console.WriteLine(ints[i]);
            }

            List<Monster> monsters = new List<Monster>();
            Goblin goblin = new Goblin();
            Boss boss = new Boss();
            Goblin goblin2 = new Goblin();
            Monster.monsters1[0].Attack();

            Monster.monsters1[1].Attack();
            Console.WriteLine(Monster.monsters1.Count);

            TaskManager taskManager = new TaskManager();
            taskManager.Add("a1");
            taskManager.Add("b21");
            taskManager.Add("b211");

            Console.WriteLine(taskManager.Find("a1"));
            Console.WriteLine(taskManager.Find("a2"));

            taskManager.Remove("asd");
            taskManager.Remove("b21");

            taskManager.Display();


            /*        Random r = new Random();
                    int K = 0;

                    for (int j = 0; j <10; j++) {
                        K = r.Next(0, 2);
                        if (K==0)
                        {
                            monsters.Add(new Boss());
                        }
                        else
                        {
                            monsters.Add(new Goblin());
                        }
                        monsters[j].Attack();
                    }*/

            /*     foreach (Monster monster in monsters)
                 {
                     if (monster is Goblin)
                     {
                        monster.Attack();
                     }
                 }*/

        }
    }
}
