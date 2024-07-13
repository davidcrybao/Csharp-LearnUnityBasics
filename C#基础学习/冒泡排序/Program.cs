namespace 冒泡排序
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Random random = new Random();
            int[] array1 = new int[20];
            int[] array2 = new int[20];
            for (int i = 0; i < 20; i++)
            {
                array1[i] = random.Next(0, 21);
                array2[i] = random.Next(0, 21);
            }
            for (int i = 0; i < 20; i++)
            {
                Console.Write(array1[i] + " ");
            }
            BubbleSort(array1, true);

            Console.WriteLine();
            // BubbleSort(array2, false);

            for (int i = 0; i < 20; i++)
            {
                Console.Write(array1[i] + " ");
            }


            /*  for (int i = 0; i < 20; i++)
              {
                  Console.Write(array2[i] + " ");
              }*/
        }

        private static void BubbleSort(int[] array, bool reverseOrder = false)
        {
            int temp = 0;
            bool swapped;

            for (int i = 0; i < array.Length; i++)
            {
                swapped = false;
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    bool needSwap = reverseOrder ? array[j] < array[j + 1] : array[j] > array[j + 1];

                    if (needSwap)
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        if (!swapped)
                        {
                            swapped = true;
                        }
                    }
                }
                //使用 return 比 break 更高效，因为它能在确定数组有序时立即终止整个排序过程，而不需要继续执行外层循环的剩余次数。
                if (!swapped)
                {
                    return;
                }
            }
        }
    }
}
