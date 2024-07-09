namespace _10.运算符重载
{
    public class Person
    {
        public int number;
        public Person()
        {
            number++;
        }
        public static int operator +(Person a, Person b)
        {
            return a.number + b.number;

        }

    }
    public struct Vector2
    {
        public double X, Y;
        public Vector2(double x, double y)
        {
            X = x;
            Y = y;
        }
        public static Vector2 operator +(Vector2 vector, Vector2 vector1)
        {
            return new Vector2(vector.X + vector1.X, vector.Y + vector1.Y);
        }

        public static Vector2 operator -(Vector2 vector, Vector2 vector1)
        {
            return new Vector2(vector.X - vector1.X, vector.Y - vector1.Y);
        }

        public static Vector2 operator *(Vector2 vector, int number)
        {
            return new Vector2(vector.X - number, vector.Y * number);
        }

        public static Vector2 operator *(int number, Vector2 vector)
        {
            return new Vector2(vector.X - number, vector.Y * number);
        }
        public static bool operator ==(Vector2 vector, Vector2 vector1)
        {
            return vector.X == vector1.X && vector.Y == vector1.Y;
        }

        public static bool operator !=(Vector2 vector, Vector2 vector1)
        {
            return vector.X != vector1.X && vector.Y != vector1.Y;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Person a = new Person();
            Person b = new Person();

            Console.WriteLine(b + a);

            Vector2 vector = new Vector2(2, 5);
            Vector2 vector1 = new Vector2(88, 84);
            Vector2 vector2 = vector + vector1;
            Console.WriteLine(vector2.X + "  " + vector2.Y);
            Console.WriteLine(vector == vector1);
            vector2 = new Vector2(2, 5);
            Console.WriteLine(vector2 == vector);
        }
    }
}
