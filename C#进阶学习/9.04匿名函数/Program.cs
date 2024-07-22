namespace _9._04匿名函数
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action action = delegate () { Console.Write("esadfasd"); };
            action();
            Func<int,int> func = GetFunc(5);

            Func<int> func2 = delegate () { return 1; };
            Console.WriteLine("-*************************:");

            Console.WriteLine(func(6));
            Console.WriteLine(func2());
        }

        static Func<int,int> GetFunc(int x)
        {                  
            return delegate(int y) { return x*y ; };
        }
    }
}
