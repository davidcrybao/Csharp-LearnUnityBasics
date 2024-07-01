using System.Numerics;

namespace 函数重载
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CompareNumbers(2, 3);
            CompareNumbers(20.5f, 3.8f);
            CompareNumbers(20.888, 32.58);
        }

        static void CompareNumbers(int a, int b)
        {

            Console.Write("较大的数值是{0}", a > b ? a : b);
        }

        static void CompareNumbers(float a, float b)
        {

            Console.Write("较大的数值是{0}", a > b ? a : b);
        }
        static void CompareNumbers(double a, double b)
        {

            Console.Write("较大的数值是{0}", a > b ? a : b);
        }
        static void CompareNumberArray(params int[] numbers)
        {

            if (numbers.Length == 0)
            {
                Console.Write("输入无效, 请重新输入");
            }
            int max = numbers[0];
            for (int i = 0; i < numbers.Length; i++)
            {
                if (max < numbers[i])
                {
                    max = numbers[i];
                }
            }
            Console.WriteLine("最大的数值是{0}", max);

        }

        static void CompareNumberArray(params float[] numbers)
        {

            if (numbers.Length == 0)
            {
                Console.Write("输入无效, 请重新输入");
            }
            float max = numbers[0];
            for (int i = 0; i < numbers.Length; i++)
            {
                if (max < numbers[i])
                {
                    max = numbers[i];
                }
            }
            Console.WriteLine("最大的数值是{0}", max);

        }
        static void CompareNumberArray(params double[] numbers)
        {

            if (numbers.Length == 0)
            {
                Console.Write("输入无效, 请重新输入");
            }
            double max = numbers[0];
            for (int i = 0; i < numbers.Length; i++)
            {
                if (max < numbers[i])
                {
                    max = numbers[i];
                }
            }
            Console.WriteLine("最大的数值是{0}", max);

        }



    }
}
