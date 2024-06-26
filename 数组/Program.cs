namespace 数组
{
    internal class Program
    {
        /*        基础练习题目
声明一个包含10个整数的数组，并为其赋值，然后输出所有元素。
编写一个程序，计算并输出数组元素的平均值。
进阶练习题目
声明一个包含10个整数的数组，编写一个程序，找出并输出数组中所有偶数。
编写一个程序，对一个包含10个整数的数组进行排序（从小到大）。*/
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            int[] index = { 1, 35, 88, 4, 5, 6, 12, 8, 9, 10 };
            for (int i = 0; i < index.Length; i++)
            {
                Console.WriteLine(index[i]);
            }
            CalculateAverageArray(index);

            FindAllEvenInArray(index);
            ResortArrayLowerToHigher(index);
        }
        private static void CalculateAverageArray(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            Console.WriteLine("数组总共有{0}个数,平均数是{1}", array.Length, (float)sum / array.Length);

        }

        private static void FindAllEvenInArray(int[] array)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    count++;
                    Console.WriteLine("偶数:" + array[i]);
                }

            }

            Console.WriteLine("总共偶数数量是{0}", count);

        }

        private static void ResortArrayLowerToHigher(int[] array)
        {
            int[] tempArray = new int[array.Length];
            int max;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] < array[i])
                {
                    max = array[i];
                    tempArray[i - 1] = array[i - 1];
                    tempArray[i] = max;
                }
                else
                {
                    max = array[i - 1];
                    tempArray[i] = max;
                    tempArray[i - 1] = array[i];
                }


            }
            Console.WriteLine("重新排序之后");
            for (int i = 0; i < tempArray.Length; i++)
            {
                Console.Write("  " + tempArray[i]);
            }

        }


    }
}
