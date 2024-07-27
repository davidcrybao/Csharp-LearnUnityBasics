using System.Reflection;

namespace _9._12特性Attribute
{
    public class Test
    {
        [Obsolete("tHIS IS OLD")]
        public static void OldSpeak()
        {
            Console.Write("ASDAS");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
           // Test.OldSpeak();
            Assembly assembly = Assembly.LoadFile(@"C:\Users\david\source\repos\davidcrybao\c-sharp-\C#进阶学习\0.01Type-PlayerClass\bin\Debug\net8.0\0.01Type-PlayerClass.dll");
            Type[] types=assembly.GetTypes();
            foreach (var item in types)
            {
                Console.WriteLine(item);
            }
            Type playerType = assembly.GetType("_0._01Type_PlayerClass.PlayerAttritube");
            Type attritube = assembly.GetType("_0._01Type_PlayerClass.MyCustomAttribute");
            object playerObj = Activator.CreateInstance(playerType);
            Console.WriteLine(playerObj);
            Console.WriteLine("---------------------");
            FieldInfo[] fieldInfos= playerType.GetFields();
            foreach (var item in fieldInfos)
            {
                Console.WriteLine(item);

            }
            FieldInfo name = playerType.GetField("name");

            Console.WriteLine(name.GetValue(playerObj));
            Console.WriteLine(name.GetCustomAttribute(attritube));
            if (name.GetCustomAttribute(attritube)!=null)
            {
                Console.WriteLine("非法操作，随意修改name成员");
            }
            else
            {
                name.SetValue(playerObj, "Mydog");
            }
            Console.WriteLine(name.GetValue(playerObj));

        }
    }
}
