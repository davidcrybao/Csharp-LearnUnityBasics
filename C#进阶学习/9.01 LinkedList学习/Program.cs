namespace _9._01_LinkedList学习
{
    public static class LinkedListExtension
    {
        public static void Reverse(this LinkedList<int> ints)
        {
            LinkedList<int> tmepList = new LinkedList<int>();
            foreach (var item in ints)
            {
                tmepList.AddFirst(item);
            }
            ints.Clear();
            foreach (var item in tmepList)
            {
                ints.AddLast(item);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            LinkedList<int> ints = new LinkedList<int>();
            
            Random r = new Random();
            while (ints.Count<10)
            {
                ints.AddLast(r.Next(0, 100));
            }

            foreach (var item in ints)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("****************************");
            LinkedListNode<int> current = ints.Last;
            while (current!=null)
            {
                Console.WriteLine(current.Value);
                current = current.Previous;
            }

            Console.WriteLine("1****************************");
            ints.Reverse();
            foreach (var item in ints)
            {
                Console.WriteLine(item);
            }
        }
    }
}
