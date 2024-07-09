

namespace _20_字符串
{
    public static class StringExtension
    {
        public static string ReverseThis(this string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);


            return new string(charArray);
        }
    }
    internal class Program
    {


        static void Main(string[] args)
        {
            string index = "Asdasdds2adssda";
            string t1 = index.Substring(6);
            Console.WriteLine(t1);
            string t2 = index.Replace("Asdasdd", "你好呀");
            Console.WriteLine(t2);


            string t3 = "1|2|3|4|5|6|7";

            string[] strs = t3.Split("|");
            t3 = "";
            for (int i = 0; i < strs.Length; i++)
            {
                t3 += int.Parse(strs[i]) + i;
                if (i != strs.Length - 1)
                {
                    t3 += "|";
                }

            }

            string t4 = string.Format(t3.Substring(2) + "|8");
            Console.WriteLine(t4);
            Console.WriteLine(t3.ReverseThis());


        }

        public static string StringReverse(string text)
        {
            return text.Reverse().ToString();

        }
    }
}
