using Microsoft.VisualBasic;
using System.Collections;

namespace _2.stack
{
    class TextEdiot
    {
        Stack<string> strings = new Stack<string>();
        string currentText ="";

        public TextEdiot(Stack<string> strings, string currentText)
        {
            this.strings = strings;
            this.currentText = currentText;
        }
        public TextEdiot()
        {
        }

        public void Add(string text)
        {
            strings.Push(text);
            currentText += text;
            Console.WriteLine(currentText);
        }

        public void Undo()
        {
            if (strings.Count>0)
            {
                currentText = strings.Pop();
                Console.WriteLine(currentText);
            }
            else
            {
                Console.Write("当前没有可撤销的文本");
            }
        }
    }
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

        static void ReverString(string text)
        {
            Stack stack = new Stack();
            for (int i = 0; i < text.Length; i++)
            {
                stack.Push(text[i]);
            }

            while (stack.Count>0)
            {
                Console.Write(stack.Pop());
            }
        
        }
        static void Main(string[] args)
        {
            StackCalculate(10u);
            ReverString("k2ad215");
        }
    }
}
