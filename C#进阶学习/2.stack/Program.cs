using System.Collections;

namespace _2.stack
{
    internal class Program
    {
        static void StackCalculate(int number)
        {
            string convert = "";
            Stack stack =new Stack();
            while (number>0)
            {
                convert = (number % 2 == 0 ? 0 : 1).ToString();
                number /= 2;
                stack.Push(convert);
            }

            while (stack.Count>0)
            {
                Console.Write(stack.Pop());
            }

          /*  do
            {
                convert += number % 2 == 0 ? 0 : 1;
                number /= 2;
            } while (number / 2 != 0);*/
            //Console.WriteLine(convert);
        }
        static void StackCalculate(uint num)
        {
            Stack stack = new Stack();
            while (true)
            {
                stack.Push(num % 2);
                num /= 2;
                if (num==1)
                {
                    stack.Push(num);
                    break;
                }
            }
            while (stack.Count>0)
            {
                Console.Write(stack.Pop());
            }
        }
        static void Main(string[] args)
        {
            StackCalculate(10u);
        }
    }
}
