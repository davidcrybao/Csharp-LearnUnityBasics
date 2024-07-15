using System.Collections;
using System.Runtime.CompilerServices;

namespace C_进阶学习
{
    public class Item
    {
        public Item(string name, int price)
        {
            this.name = name;
            this.price = price;
        }

        public string name { get; private set; }
        public int price { get; private set; }
    }
    public class PackBag
    {
        ArrayList items =new ArrayList();
        private int money;

        public PackBag(int money)
        {
            this.money = money;
        }

        public void Buy(Item item)
        {
            if (money >= item.price) 
            {
                items.Add(item);
                money -= item.price;
                Console.WriteLine("你花费了{0}购买了物品{1}",item.price,item.name);
                Console.Write("目前的余额是{0}",money);
            }
            else
            {
                Console.Write("Yoou don't hav eenough money ");
            }
           
        }
        public void Sell(Item item)
        {
            if (items.Contains(item))
            {
                money += item.price;
                Console.WriteLine("你出售了物品{1},获得了{0}块钱", item.price, item.name);
                items.Remove(item);
                Console.Write("目前的余额是{0}", money);

            }
            else
            {
                Console.WriteLine("没有物品可以一sell");
                return;
            }       
        }
        public void Sell(string name)
        {
            foreach (Item item in items)
            {
                if (item.name == name)
                {
                    money += item.price;
                    Console.WriteLine("你出售了物品{1},获得了{0}块钱", item.price, item.name);
                    items.Remove(item);
                    Console.Write("目前的余额是{0}", money);
                    return;
                }
            }
            Console.WriteLine("没有找到该物品{0}", name);
        }

        public void Show()
        {
            Console.WriteLine("你目前拥有这些物品:");
               foreach (Item item in items)
            {
                Console.Write(item.name+" ");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Item n1 = new Item("n1",10);
            Item n2 = new Item("n2", 5);
            PackBag packBag = new PackBag(20);
            packBag.Buy(n1);
            packBag.Buy(n2);
            packBag.Show();
            packBag.Sell("n21");
            packBag.Sell(n1);
            packBag.Sell(n1);

        }
    }
}
