using System.Reflection.Metadata.Ecma335;

namespace _9._06_list排序
{
    public class Item : IComparable<Item>
    {
        private int itemID;

        public int ItemID
        { get { return itemID; } }

        public Item(int itemID)
        {
            this.itemID = itemID;
        }

        public int CompareTo(Item? other)
        {
            if (this.itemID > other.itemID)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            /*#region 排序的学习

            List<int> ints = new List<int> { 1, 2, 23, 23, 2, 32, 32, 3, 2 };

            foreach (int item in ints)
            {
                Console.Write(item + "/ ");
            }

            ints.Sort();

            Console.WriteLine();
            foreach (int item in ints)
            {
                Console.Write(item + "/ ");
            }
            Console.WriteLine();
            List<Item> items = new List<Item> { new Item(32) };
            items.Add(new Item(1)); items.Add(new Item(88)); items.Add(new Item(5)); items.Add(new Item(24)); items.Add(new Item(11));

            foreach (var item in items)
            {
                Console.WriteLine(item.ItemID);
            }

            items.Sort();
            Console.WriteLine("重新打印");
            foreach (var item in items)
            {
                Console.WriteLine(item.ItemID);
            }

            items.Sort(ReveseSort);
            Console.WriteLine("反向排序");

            foreach (var item in items)
            {
                Console.WriteLine(item.ItemID);
            }

            items.Sort(

                delegate (Item a, Item b)
            {
                if (a.ItemID > b.ItemID)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }

            );

            foreach (var item in items)
            {
                Console.WriteLine(item.ItemID);
            }

            items.Sort(( a, b) => { return a.ItemID > b.ItemID ? -1 : 1; } );
            Console.WriteLine("````````最后的逆向排序");

            foreach (var item in items)
            {
                Console.WriteLine(item.ItemID);
            }

            #endregion*/

            Random r = new Random();
            List<Monster> monsters = new List<Monster>();

            for (int i = 0; i < 10; i++)
            {
                monsters.Add(new Monster(r.Next(0,200), r.Next(50, 400), r.Next(20, 150)) );
            }
            foreach (var monster in monsters)
            {
                Console.WriteLine(monster);
            }
            /*   #region 旧的monster代码

               foreach (Monster monster in monsters)
               {
                   Console.WriteLine("怪兽排序,目前的是攻击{0},防御{1},生命{2}", monster.Attack, monster.Defence, monster.Health);
               }

               Console.WriteLine("-------------------------------------------");
               monsters.Sort(AttackSort);
               foreach (Monster monster in monsters)
               {
                   Console.WriteLine("怪兽排序,目前的是攻击{0},防御{1},生命{2}", monster.Attack, monster.Defence, monster.Health);
               }

               monsters.Sort();
               Console.WriteLine("-------------------------------------------");
               foreach (Monster monster in monsters)
               {
                   Console.WriteLine("怪兽排序,目前的是攻击{0},防御{1},生命{2}", monster.Attack, monster.Defence, monster.Health);
               }

               monsters.Sort(delegate (Monster a, Monster b)
               {
                   if (a.Defence > b.Defence)
                   {
                       return 1;
                   }
                   else
                   {
                       return -1;
                   }
               }
               );
               Console.WriteLine("-------------------------------------------");
               foreach (Monster monster in monsters)
               {
                   Console.WriteLine("怪兽排序,目前的是攻击{0},防御{1},生命{2}", monster.Attack, monster.Defence, monster.Health);
               }

               #endregion*/
            Monster.sortChoice = int.Parse(Console.ReadLine());
            if (Monster.sortChoice == 4)
            {
                monsters.Reverse();
            }
            else
            {
                monsters.Sort(MonsterSort);
            }

            foreach (var monster in monsters)
            {
                Console.WriteLine(monster);
            }

            List<Items> items = new List<Items>
            {
                new Items(1,4,"顶尖武器"),new Items(1,2,"普通武器"),new Items(1,3,"精品武器2"),new Items(1,3,"精品武器2"),
                 new Items(2,2,"精品普通护甲"), new Items(2,1,"普通护甲"),new Items(2,3,"精品护甲"),new Items(2,4,"顶尖护甲"),
                   new Items(3,4,"超级鞋子"),new Items(3,1,"普通鞋"),new Items(3,1,"普通鞋子"),
            };

            foreach (var item in items)
            {
                Console.WriteLine("这把武器是{2},类型为{0},质量:{1}", item.type, item.quality, item. name);
            }

            Console.WriteLine("===================");
            items.Sort();
            foreach (var item in items)
            {
                Console.WriteLine("这把武器是{2},类型为{0},质量:{1}", item.type, item.quality, item.name);
            }
            Dictionary<int, string> keyValuePairs = new Dictionary<int, string>();
            keyValuePairs.Add(1, "sad2");


            List<KeyValuePair<int, string>> dList = new List<KeyValuePair<int, string>>();
            foreach (KeyValuePair<int, string> item in keyValuePairs)
            {
                dList.Add(item);
            }
            dList.Sort((a,b)=> {
                return a.Key > b.Key ? 1 : -1;      
            });
        }

        /// <summary>
        /// 1:sort by attack,2,sort by health,3 sort by defence;
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int MonsterSort(Monster a,Monster b)
        {
            switch (Monster.sortChoice)
            {
                case 1:
                    return a.Attack>b.Attack?1:-1; 
                case 2:
                    return a.Health>b.Health ? 1:-1;
                case 3:
                    return a.Defence>b.Defence ? 1:-1;
                default:
                    return 0;
            }
        }
        private static int ReveseSort(Item a, Item b)
        {
            if (a.ItemID > b.ItemID)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }

        private static int AttackSort(Monster a, Monster b)
        {
            if (a.Attack > b.Attack)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }

    public class DictionarySort<T, K>:IComparable<DictionarySort<T, K>> where T : IComparable<T> where K:IComparable<K>
    {
        public T key;
        public K value;

        public DictionarySort(T key, K value)
        {
            this.key = key;
            this.value = value;
        }

        public int CompareTo(DictionarySort<T, K>? other)
        {
            if (other==null)
            {
                return 1;
            }

            return key.CompareTo(other.key);
        }
    }
    public class Monster : IComparable<Monster>
    {
        public static int sortChoice = 1;
        private int health;
        private int defence;
        private int attack;

        public Monster(int health, int defence, int attack)
        {
            this.health = health;
            this.defence = defence;
            this.attack = attack;
        }
        public override string ToString()
        {
            return string.Format("怪兽排序,目前的是攻击{0},防御{1},生命{2}", Attack, Defence, Health);
        }

        public int Health { get => health; }
        public int Defence { get => defence; }
        public int Attack { get => attack; }

        public int CompareTo(Monster? other)
        {
            if (health > other.Health)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }

    public class Items : IComparable<Items>
    {
        public int type;
        public int quality;
        public string name;

        public Items(int type, int quality, string name)
        {
            this.type = type;
            this.quality = quality;
            this.name = name;
        }

        public int CompareTo(Items? other)
        {
            if (type > other.type)
            {
                return 1;
            }
            else if (type == other.type)
            {
                if (quality > other.quality)
                {
                    return 1;
                }
                else if (quality == other.quality)
                {
                    if (name.CompareTo(other.name) > 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        public int ItemSort(Items a,Items b)
        {
            if (a.type!=b.type)
            {
                return a.type > b.type ? 1 : -1;
            }
            else if (a.quality!=b.quality)
            {
                return a.quality > b.quality ? 1 : -1;
            }
            else
            {
                return a.name.Length > b.name.Length ? 1 : -1;
            }
        
        }

        public override string ToString()
        {
            return string.Format("当前物品是{0},所属的类型是{1},物品的品质为{2}", name, type, quality);
        }

    }
}