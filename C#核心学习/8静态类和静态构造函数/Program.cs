namespace _8静态类和静态构造函数
{
    public static class MathC
    {
        static float Pi = 3.1414926f;
        public static float CirclePerimeter(float length)
        {
            return Pi * length * 2;
        }
        public static float CircleArea(float length)
        {
            return Pi * length * length;
        }
        public static float RectanglePerimeter(float width, float height)
        {
            return (width + height) * 2f;
        }
        public static float RectangleArea(float width, float height)
        {
            return width * height;
        }

    }

    public static class AppConfig
    {
        public static string AppName;
        public static float Version;

        public static void ShowConfig()
        {
            Console.Write(AppName + Version);
        }

        static AppConfig()
        {
            Console.Write("initialize all the information now /n" + AppName + Version);
        }
    }

    public class PlayerStats
    {

        public static int TotalPlayers { get; private set; }

        static PlayerStats()
        {
            TotalPlayers = 0;
        }
        public PlayerStats()
        {
            TotalPlayers++;
        }


    }

    public static class GlobalCounter
    {
        public static int Counter { get; private set; }
        static public void Increment(int times)
        {
            Counter += times;
        }
        static GlobalCounter()
        {
            Counter = 0;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            AppConfig.AppName = "sadsad";
            AppConfig.Version = 7.1515f;
            AppConfig.ShowConfig();
            AppConfig.AppName = "55ad";
            AppConfig.Version = 7.55f;

            AppConfig.ShowConfig();
            PlayerStats player1 = new PlayerStats();

            PlayerStats player2 = new PlayerStats();
            PlayerStats player3 = new PlayerStats();
            PlayerStats player14 = new PlayerStats();
            Console.WriteLine("现在的玩家数量是" + PlayerStats.TotalPlayers);
            GlobalCounter.Increment(1);
            GlobalCounter.Increment(1);
            GlobalCounter.Increment(4);
            Console.WriteLine(GlobalCounter.Counter);
        }
    }
}
