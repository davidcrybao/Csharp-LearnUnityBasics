using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace 成员变量和访问修饰符
{
    public class Person
    {
        public string name;
        public int age;

        public float height;
        public string homeAddress;

        public Person(string name, int age, float height, string homeAddress)
        {
            this.name = name;
            this.age = age;
            this.height = height;
            this.homeAddress = homeAddress;
        }
        public Person()
        { }

        public void Speak()
        {
            Console.WriteLine("你好,我是{0},我今年{1}岁了,{2}米高,家庭地址是{3}", name, age, height, homeAddress);
        }
    }

    public class Student
    {
        public string name;
        public int number;
        public int age;
        public Student deskMate;

        public Student(string name, int number, int age)
        {
            this.name = name;
            this.number = number;
            this.age = age;
        }

        public void Study()
        {
            Console.WriteLine("{0}开始学习了", name);
        }
    }

    public class Classes
    {
        public Student[] students;
        public string className;
        public int totalTeacherNumber;

        public Classes(Student[] students, string className, int totalTeacherNumber)
        {
            this.students = students;
            this.className = className;
            this.totalTeacherNumber = totalTeacherNumber;
        }
    }

    public class Book
    {
        private string title;
        private string author;

        public void SetTitle(string title)
        {
            this.title = title;
        }

        public void SetAuthor(string author)
        {
            this.author = author;
        }
    }

    public class Employee
    {
        protected string Name;
        protected int Salary;
    }

    public class Manager : Employee
    {
        protected string Department;

        public Manager(string name, int salary, string department)
        {
            Salary = salary;
            Name = name;
            Department = department;
        }

        public void Speak()
        {
            Console.WriteLine("大家好,我是{0},薪水为{1},我隶属于{2}", Name, Salary, Department);
        }
    }

    public class BankAccount
    {
        internal int AccountNumber;
        internal int Balance;

        public BankAccount(int accountNumber, int balance)
        {
            AccountNumber = accountNumber;
            Balance = balance;
        }

        public void Deposit(int number)
        {
            Balance += number;
            Console.WriteLine("你为卡号为{0}存了{1},现在的余额为{2}", AccountNumber, number, Balance);
        }

        public void Withdraw(int number)
        {
            if (Balance - number < 0)
            {
                Console.WriteLine("余额不足");
                return;
            }
            Balance -= number;
            Console.WriteLine("你从卡号为{0}取了{1},现在的余额为{2}", AccountNumber, number, Balance);
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            /*Person bob = new Person();
            bob.Name = "Bob";
            bob.Age = 18;

            Person tyler = new Person();
            tyler.Name = "Tyler";
            tyler.Age = 25;

            bob.Speak();
            tyler.Speak();

            Book newBook = new Book();
            newBook.SetAuthor("Tylor");
            newBook.SetTitle("Games of day");

            Manager steven = new Manager("Steven", 3500, "Advertisement");
            steven.Speak();
            BankAccount bankAccount = new BankAccount(45654564, 520);
            bankAccount.Withdraw(600);
            bankAccount.Withdraw(500);
            bankAccount.Deposit(50);*/

            Person p = new Person();

            Student wang = new Student("王潇洒", 2005641, 15);

            Student xiao = new Student("小手术", 2003641, 14);
            wang.deskMate = xiao;
            xiao.deskMate = wang;
            xiao.age = 88;
            Console.WriteLine(wang.deskMate.age);


            Student[] students = [wang, xiao];

            Classes topClass = new Classes(students, "TOP", 5);
        }
    }
}
