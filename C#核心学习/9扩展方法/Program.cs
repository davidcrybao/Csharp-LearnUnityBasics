namespace _9扩展方法
{
    public static class StringExtension
    {
        public static bool IsNull(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
        public static void WordCount(this string str)
        {
            int count = 0;
            for (int i = 0; i < str.ToCharArray().Length; i++)
            {
                count++;
            }
            Console.WriteLine(count);

        }
        public static string Reverse(this string str)
        {
            return new string(str.ToCharArray().Reverse().ToArray());


        }

    }
    public static class IntExtension
    {
        public static bool IsPositive(this int num)
        {
            return num > 0;
        }
        public static int GetSquare(this int num)
        {
            return num * num;
        }
    }

    class Player
    {
        string name;
        int attack;
        int defence;
        public void Attack()
        {

        }
    }
    static class PlayerExtension
    {
        public static void KillSelf(this Player player)
        {
            Console.WriteLine("KILL SM");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string te = "";
            Console.WriteLine(te.IsNull());
            int number = -5;
            int number2 = 5;
            number.IsPositive();
            number2.IsPositive();
            Console.WriteLine(number.IsPositive() + "  " + number2.IsPositive());
            te = "111";
            te.WordCount();
            Player player = new Player();
            player.KillSelf();
        }
    }

}
