namespace 继承中的构造函数
{
    public class Person
    {
        public string name;

        public Person(string name)
        {
            this.name = name;
        }
    }

    public class Student : Person
    {
        private string className;

        public Student(string name) : base(name)
        {
        }
    }

    public partial class Worker
    {
        public string workType;
        public string workThings;
        private Worker[] worker;

        public Worker(string workType, string workThings)
        {
            this.workType = workType;
            this.workThings = workThings;
        }
        public Worker this[int index]
        {
            get { return worker[index]; }
            set { worker[index] = value; }
        }

        public class Programmer : Worker
        {
            public uint itLevel;

            public Programmer(string workType, string workThings, uint level) : base(workType, workThings)
            {
                itLevel = level;
            }
        }

        public class Designer : Worker
        {
            public ushort designType;

            public Designer(string workType, string workThings, ushort designType) : base(workType, workThings)
            {
                this.designType = designType;
            }
        }

        public class Artist : Worker
        {
            public string aritstName;
            public Artist(string workType, string workThings, string aritstName) : base(workType, workThings)
            {
                this.aritstName = aritstName;
            }
        }

        internal class Program
        {
            private static void Main(string[] args)
            {
                Console.WriteLine("Hello, World!");
            }
        }
    }
}
