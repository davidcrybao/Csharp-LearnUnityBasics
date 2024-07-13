namespace _16_多态
{
    public class Duck
    {
        public virtual void Speak()
        {
            Console.WriteLine("gagaga");
        }
    }

    public class WoodenDuck : Duck
    {
        public override void Speak()
        {
            Console.WriteLine("qiqiqiqi");
        }
    }

    public class PlasticDuck : Duck
    {
        public override void Speak()
        {
            Console.WriteLine("jijiji");
        }
    }

    public class Shape
    {
        public void Draw()
        {
            Console.WriteLine("shape");
        }
    }
    public class Circle : Shape
    { }
    public class Rectangle : Shape
    {

    }


    public class Vehicle
    {
        public virtual void StartEngine()
        {
            Console.WriteLine("Vehicle engine started!");
        }
    }
    public class Car : Vehicle
    {
        public override void StartEngine()
        {
            Console.WriteLine("Car engine started");
        }
    }
    public abstract class Weapon
    {
        public abstract void Use();
    }
    public class Sword : Weapon
    {
        public override void Use()
        {
            Console.WriteLine("Use sword");
        }
    }
    public class Bow : Weapon
    {
        public override void Use()
        {
            Console.WriteLine("Use Bow");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Shape circle = new Circle();
            Shape rectangle = new Rectangle();
            (circle as Circle).Draw();
            rectangle.Draw();
            //虽然结果一样,需要仔细查看

            Weapon bow = new Bow();
            Weapon sword = new Sword();
            bow.Use();
            sword.Use();
        }
    }
}
