namespace _5.成员属性
{
    public class Person
    {
        public string Name { get; private set; }

        public int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }
    }

    public class Student
    {
        public string Name { get; }
        public uint age;
        public uint unityScore;
        public uint cSharpScore;
        public bool IsMale { get; }
        public uint Age
        {
            get { return age; }
            set
            {
                if (value <= 150 && value >= 0)
                {
                    age = value;
                }
                else
                {
                    age = 18;
                    Console.WriteLine("{0}请重新输入,你输入的年龄无效,需要在0-150岁之间,给你重新设置为18岁了", Name);
                }

            }
        }


        public uint UnityScore
        {
            get { return unityScore; }
            set
            {
                if (value <= 100 && value >= 0)
                {
                    unityScore = value;
                }
                else
                {
                    unityScore = 0;
                    Console.WriteLine("{0}请重新输入,你输入的unityScore成绩无效,成绩必须是0-100,给你设置为0分了", Name);
                }

            }
        }

        public uint CSharpScore
        {
            get { return cSharpScore; }
            set
            {
                if (value <= 100 && value >= 0)
                {
                    cSharpScore = value;
                }
                else
                {
                    cSharpScore = 5;
                    Console.WriteLine("{0}请重新输入,你输入的cSharpScore成绩无效,成绩必须是0-100,给你设置为5分了", Name);
                }

            }
        }



        public Student(string name, uint age, uint unityScore, uint cSharpScore, bool isMale)
        {
            Name = name;
            Age = age;
            UnityScore = unityScore;
            CSharpScore = cSharpScore;
            IsMale = isMale;
        }
        public Student()
        { }

        public void Speak()
        {

            Console.WriteLine("你好我是{3},我今年{4}岁了,我是{0}的,我的平均分和总分分别是:{1},{2}", IsMale ? "男" : "女", (UnityScore + CSharpScore) / 2, UnityScore + CSharpScore, Name, Age);
        }




    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Student tom = new Student("tom", 25, 56, 78, false);
            Student tom2 = new Student("TomJunior", 1225, 506, 128, false);
            tom.Speak();
            tom2.Speak();
        }
    }
}
