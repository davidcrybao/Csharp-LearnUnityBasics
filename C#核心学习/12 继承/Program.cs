namespace _12_继承
{
    public class Vehicle
    {
        public int Speed { get; }

        public void Drive()
        {
            Console.WriteLine("I'm driving my speed is {0}", Speed);
        }

    }
    public class Car : Vehicle
    {

        public void Horn()
        {
            Console.WriteLine("Horning ! Move now!");
        }

    }


    public class Bike : Vehicle
    {


        public void EnergyCost()
        {

            Console.WriteLine("You are driving now ,this time will cost you 256kj");
        }
    }
    public class Person
    {
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; }
        public string LastName { get; }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
    }
    public class Student : Person
    {

        public uint Grade;

        public Student(string firstName, string lastName, uint grade) : base(firstName, lastName)
        {
            Grade = grade;
        }

        public void Study()
        {
            Console.Write("Hello my name is {0}, I'm studying now ,my grade is {1}", GetFullName(), Grade);
        }
    }


    public class Shape
    {

        public virtual void CalculateArea()
        {

        }
    }
    public class Rectangle : Shape
    {
        public uint Width;
        public uint Height;

        public Rectangle(uint width, uint height)
        {
            Width = width;
            Height = height;
        }

        public override void CalculateArea()
        {
            Console.WriteLine("The area is {0}", Width * Height);
        }
    }
    public class Circle : Shape
    {
        public float length;

        public override void CalculateArea()
        {
            Console.WriteLine("The area is {0}", 3.1415f * length * length);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Student jack = new Student("Jack", "C", 52);
            Console.WriteLine(jack.FirstName + jack.LastName);
            jack.Study();
        }
    }
}
