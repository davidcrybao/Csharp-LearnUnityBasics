using System.Collections.Specialized;
using System.Reflection;

namespace _9._10反射和关键类TYPE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Object obj = new object();
            int x = 5;
            Type type = x.GetType();
            Console.WriteLine(type.Name);
            Console.WriteLine(type);
            type = typeof(string);
            Console.WriteLine(type.Name);
            Console.WriteLine(type);

            type = Type.GetType("_9._10反射和关键类TYPE.Test");
            Console.WriteLine(type.Name);
            Console.WriteLine(type);
            MemberInfo[] memberInfo = type.GetMembers();
            foreach (var item in memberInfo)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("=============");
            FieldInfo[] fieldInfos = type.GetFields();
            foreach (var item in fieldInfos)
            {
                Console.WriteLine(item);
            }
            FieldInfo fieldInfo = type.GetField("count");

            Console.WriteLine(fieldInfo);
            Test test = new Test();
            Console.WriteLine(fieldInfo.GetValue(test));
            fieldInfo.SetValue(test, 50);
            Console.WriteLine(fieldInfo.GetValue(test));
            Type strType = Type.GetType("System.String");

            MethodInfo method = strType.GetMethod("Substring",new Type[] { typeof(int),typeof(int)});
            string str = "hellLo1234i56789110000000s world";
            object result =method.Invoke(str, new object[] { 3, 7 });
            Console.WriteLine(result);

        }
    }

    public class Test
    { 
        private int index;
        public int count;

        public Test(int index)
        {
            this.index = index;
        } 
        public Test(int count,int index):this(index)
        {
            this.count = count;
        }

        public Test()
        {
            index = 5;
            count = 10;
        }
        public void TestFunction()
        {
            Console.Write("asdasd");
        }
    }
}
