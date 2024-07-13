using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace 类和对象
{
    public enum Gender
    {
        Male,
        Female,
    }

    public class Person
    {
        public string name;
        int age;
        Gender gender;

        public Person(string name, int age, Gender gender)
        {
            this.name = name;
            this.age = age;
            this.gender = gender;
        }

        public void Speak()
        {
            Console.WriteLine("你好,我是{0},我今年{1}岁了,我的性别是{2}", name, age, gender);
        }
    }
    public class Animal
    {

        string name;
        int age;
        public virtual void MakeSound()
        {
            Console.WriteLine("{0}make a sound ", name);

        }
    }

    public class Dog : Animal
    {

        public override void MakeSound()
        {
            Console.WriteLine("{0}make a sound ", "Dog");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            /* Console.WriteLine("Hello, World!");
             Person wang = new Person("王", 45, Gender.Male);
             wang.Speak();
             Person person = wang;
             person = null;
             wang.Speak();*/

            Console.WriteLine("Hello, World!");
            Person wang = new Person("王", 45, Gender.Male);
            wang.Speak();
            Person person = wang;
            person.name = "王老头";

            person = new Person("黑子", 18, Gender.Female);
            wang.Speak();
            person.Speak();



        }
    }
}
