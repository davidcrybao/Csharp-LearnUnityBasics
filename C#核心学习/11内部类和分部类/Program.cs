namespace _11内部类和分部类
{
    public partial class Student
    {
        public string Name { get; set; }
        public void Display()
        {
            Console.WriteLine(Name);
        }
    }
    public class OuterClass
    {
        public string name = "5";

        public class InnerClass
        {

            public void Talk()
            {

            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Student tom = new Student();
            tom.Age = 18;
            tom.Name = "Tom";


        }
    }
}
