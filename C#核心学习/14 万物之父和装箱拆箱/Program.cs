namespace _14_万物之父和装箱拆箱
{
    public class Person { }
    internal class Program
    {
        static void Main(string[] args)
        {
            object nunmber = 1;
            int number = (int)nunmber;

            object str = "1sadsad";
            string text = str as string;
            //string text=str.ToString();

            object arr = new int[10];
            int[] intArray = (int[])arr;

            object person = new Person();
            Person david = (Person)person;
        }
    }
}
