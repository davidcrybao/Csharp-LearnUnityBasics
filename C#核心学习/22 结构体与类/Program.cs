

namespace _22_结构体与类
{
    /*    public struct Minner
        {
            private int x = 5;
            private Minner minner;
            public Minner()
            {

            }
        }*/
    public class Car
    {
        public static int totalNumber;
        public string brand;
        public int speed;
        static Car()
        {
            totalNumber = 0;
            Console.WriteLine("初始化");
        }

        public Car(string brand, int speed)
        {
            this.brand = brand;
            this.speed = speed;
            totalNumber++;
        }

        public void Accelerate()
        {
            speed += 5;
        }

    }
    public class Hero
    {
        private Hero hero;
        ~Hero() { }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Car car = new Car("BYD", 25);
        }
    }
}
