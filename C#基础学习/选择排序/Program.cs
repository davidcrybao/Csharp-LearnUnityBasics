namespace 选择排序
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Random random = new Random();
            int[] array = new int[20];
            for (int i = 0; i < 20; i++)
            {
                array[i] = random.Next(0, 201);

            }

            for (int i = 0; i < 20; i++)
            {
                Console.Write(array[i] + " ");

            }
            Console.WriteLine();

            SelectionSort(array, true);

            for (int i = 0; i < 20; i++)
            {
                Console.Write(array[i] + " ");

            }
        }
        static void SelectionSort(int[] array, bool reverseOrder = false)
        {
            int n = array.Length;

            for (int i = 0; i < n; i++)
            {
                int index = i;
                for (int j = i + 1; j < n; j++)
                {
                    bool needSwap = reverseOrder ? array[j] > array[index] : array[j] < array[index];
                    if (needSwap)
                    {
                        index = j;

                    }
                }

                int temp = array[i];
                array[i] = array[index];
                array[index] = temp;

            }
        }
    }
}
