namespace _7._0静态成员
{
    class UniqueP
    {
        public static UniqueP Instance = new UniqueP();
        private UniqueP()
        {

        }
        static public void Talk()
        {
            Console.WriteLine("IM P[PPP");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            UniqueP.Talk();
        }
    }
}
