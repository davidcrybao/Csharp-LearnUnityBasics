using System.Collections;

namespace _3.Queue学习
{
    public static class QueueExtensions
    {
    
        public static Object FindAndReturn(this Queue queue,int index)
        {
            while (queue.Count >= index)
            {
                if (queue.Count==index)
                {
                    return queue.Dequeue;
                }
                
            }
            return null;

        }
    }
    internal class Program
    {
        static void QueConsole(params string[] messages)
        {
            Queue queue = new Queue();
            int count = 0;
            foreach (var item in messages)
            {
                queue.Enqueue(item);
            }

            while (true)
            {
                count += 1;
                while (queue.Count > 0&&count>100000000)
                {
                    count = 0;
                    Console.WriteLine(queue.Dequeue());
                }
                if (queue.Count==0)
                {
                    break;

                }
            }
  
        }
        static void Main(string[] args)
        {
            Queue queue = new Queue();
            queue.Enqueue(1);
            Console.WriteLine(queue.Contains(1));
            QueConsole("ASdasdsad", "ASDasd", "ASd", "!asd", "2321", "435", "345", "4", "5311114", "534");
        }
    }
}
