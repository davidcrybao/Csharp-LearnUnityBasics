namespace 递归函数
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string iof = "5的阶乘是{0}";
            Console.Write(iof.Length);
            Console.WriteLine("5的阶乘是{0}", Factorial(5));

            Console.WriteLine(ReverseString("123456"));
            Console.WriteLine(ReverseString2("54321"));
            WriteNumbers(200);

            Console.WriteLine();
            Console.WriteLine(TerminalPlus(10));
            Console.WriteLine();


            Console.WriteLine(CutHalf(10));
            Console.WriteLine();
            Fun5(1);
        }

        static float CutHalf(int day)
        {
            if (day <= 0)
            {
                return 50;
            }
            else
            {
                return CutHalf(day - 1) / 2; ;
            }
        }
        //Cut half第二种写法

        static void Fun4(float length, int day)
        {
            length /= 2;
            if (day >= 10)
            {
                Console.WriteLine("帝释天砍后柱子长为{0}米", length);
                return;
            }

            day++;
            Fun4(length, day);

        }

        static int TerminalPlus(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
            else
            {
                return n + TerminalPlus(n - 1); ;
            }
        }

        static int Factorial(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1); ;
            }
        }
        static string ReverseString(string text)
        {
            int length = text.Length;
            if (length <= 1)
            {
                return text;
            }
            else
            {
                return text[length - 1].ToString() + ReverseString(text.Substring(0, length - 1));
            }
        }
        static string ReverseString2(string s)
        {
            if (s.Length <= 1) // 基线条件
            {
                return s;
            }
            else // 递归条件
            {
                return ReverseString2(s.Substring(1)) + s[0];
            }
        }

        static void WriteNumbers(int n)
        {

            if (n <= 0)
            {
                Console.Write(n + " ");
                return;
            }
            else
            {

                WriteNumbers(n - 1);
                Console.Write(n + " ");
            }
        }
        //WriteNumbers ge更新
        static bool Fun5(int num)
        {
            Console.WriteLine(num);
            return num == 200 || Fun5(num + 1);
        }
    }
}
