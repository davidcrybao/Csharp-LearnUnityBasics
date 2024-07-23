using System.Reflection;

namespace _9._11关键类Assembly和Activator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly= Assembly.LoadFile(@"C:\Users\david\source\repos\davidcrybao\c-sharp-\C#进阶学习\0.01Type-PlayerClass\bin\Debug\net8.0\0.01Type-PlayerClass.dll");

            //Assembly.LoadFrom(" 路径");
            Type player = assembly.GetType("_0._01Type_PlayerClass.Player");
            Type[] types= assembly.GetTypes();
            foreach (var item in types)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("asdsaaaaaaaaaa");
            MemberInfo[] memberInfos = player.GetMethods();
            foreach (var item in memberInfos)
            {
                Console.WriteLine(item);

            }
            Console.WriteLine("***********************");


            ConstructorInfo[] constructorInfos = player.GetConstructors();
            foreach (var item in constructorInfos)
            {
                Console.WriteLine(item);

            }


            Console.WriteLine("***********************");


            FieldInfo[] fields = player.GetFields();
            foreach (var item in fields)
            {
                Console.WriteLine(item);

            }

            object playerObj = Activator.CreateInstance(player, 5, 10, "wo");
            MethodInfo draw = player.GetMethod("Draw");    
            MethodInfo clear = player.GetMethod("Clear");

            draw.Invoke(playerObj, null); 
            Console.ReadKey();
            clear.Invoke(playerObj, null);

        }
    }
}
