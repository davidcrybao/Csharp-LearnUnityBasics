namespace _9._06_list排序
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> ints = new List<int> { 1, 2, 23, 23, 2, 32, 32, 3, 2 };

            foreach (int item in ints)
            {
                Console.Write(item + "/ ");
            }

            ints.Sort();

            Console.WriteLine();
            foreach (int item in ints)
            {
                Console.Write(item + "/ ");
            }
        }
    }
}
