namespace 变长参数
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Test(1, 5, 6, 9, 8, 55, 62, 22);

            GetEvenOrOdd(1, 5, 6, 9, 8, 55, 62, 22);
            Test(5);

        }

        static int Test(int number = 6)
        {
            return number;
        }
        static void Test(params int[] ints)
        {
            int sum = 0;
            for (int i = 0; i < ints.Length; i++)
            {
                sum += ints[i];
            }

            Console.WriteLine("这几个数字的综合是{0},平均值是:{1}", sum, sum / ints.Length);

        }

        static void GetEvenOrOdd(params int[] ints)
        {
            int sumEven = 0;
            int sumOdd = 0;
            for (int i = 0; i < ints.Length; i++)
            {
                if (ints[i] % 2 == 0)
                {
                    sumEven += ints[i];
                }
                else
                {
                    sumOdd += ints[i];
                }
            }

            Console.WriteLine("偶数的总和是{0},奇数的总和是:{1}", sumEven, sumOdd);

        }
    }

}
