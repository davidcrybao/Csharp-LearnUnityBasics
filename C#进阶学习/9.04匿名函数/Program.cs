namespace _9._04匿名函数
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action action = delegate () { Console.Write("esadfasd"); };
            action();
            Func<int,int> func = GetFunc(5);

            Console.WriteLine("-*************************:");

            Console.WriteLine(func(6));
        }

        static Func<int> GetFunc(int x)
        {                  
            return delegate(int y) { return x*y ; };
        }
    }
}
