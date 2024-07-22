/*#define Unity5
#define Unity2017*//*
#define Unity2020*/
#undef Unity5
namespace _9._09预处理指令
{
    internal class Program
    {
        #region main

        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        private static int Calculate(int a, int b)
        {
#if Unity5
            return a + b;
#elif Unity2017
            return a*b;
#elif Unity2020
            return a - b;
#else
            return 0;
#endif
        }

        #endregion main
    }
}