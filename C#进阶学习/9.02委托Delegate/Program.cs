using System;
using System.Runtime.CompilerServices;

namespace _9._02委托Delegate
{
    internal class Program
    {
        public delegate void Func1();

        public delegate void Func2(string text);

        public delegate void CookAndEat(ref int cookTimes);

        private static int cookTimes = 0;
        private static int monsterKills = 0;

        private static void Main(string[] args)
        {
            Action MonsterDie;
            Func1 func = Talk;
            Func2 func2 = Talk;
            func();
            Console.WriteLine("***********");
            func2("阿萨德");

            CookAndEat cookAndEat = Cook;
            cookAndEat += Eat;
            cookAndEat(ref cookTimes);
            cookAndEat(ref cookTimes);
            cookAndEat(ref cookTimes);

            cookAndEat(ref cookTimes);


            Monster monster = new Monster();
            Warrior warrior = new Warrior();
            Achievement achievement = new Achievement();
            monster.action += warrior.KillAMonster;
            monster.action += achievement.KillAMonster;

            monster.MonsterDie(monster);monster.MonsterDie(monster);


        }

      

        private static void AddMoney()
        {
            Console.WriteLine("玩家金钱+10");
        }

        private static void Talk()
        {
            Console.WriteLine("Fuck you ");
        }

        private static void Talk(string text)
        {
            Console.WriteLine(text);
        }

        private static void Cook(ref int cookTimes)
        {
            if (cookTimes < 3)
            {
                cookTimes++;
            }
            else
            {
                Console.WriteLine("饭已经做好了");
            }
        }

        private static void Eat(ref int cookTimes)
        {
            if (cookTimes >= 3)
            {
                Console.WriteLine("正在吃饭");
            }
            else
            {
                Console.WriteLine("请耐心等待,还需要烹饪{0}次", 3 - cookTimes);
            }
        }
    }

    public class Monster
    {
        public  int worth = 10;
        public Action<Monster> action;
        public void MonsterDie(Monster m)
        {
            if (action != null)
            {
                Console.WriteLine("怪兽死亡了");
            }
            else
            {
                Console.WriteLine("怪兽已经死亡了,请停止当前行为");
            }

            action?.Invoke(this);
            action = null;
          
        }
    }

    public class Warrior
    {
        private int currentMoney = 0;
        public void KillAMonster(Monster m)
        {
            currentMoney += m.worth;
            Console.WriteLine("恭喜你完成击杀怪物,当前金钱{0}", currentMoney);

        }
    }
    public class Achievement
    {
        private int totalMonsterKilled = 0;
        public void KillAMonster(Monster m)
        {
            totalMonsterKilled++;
            Console.WriteLine("完成击杀怪物,已经击杀了{0}个怪兽", totalMonsterKilled);
        }

    }
}