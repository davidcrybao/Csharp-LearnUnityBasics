namespace ref_out
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请一次输入用户名密码");
            string password = "";
            string username = "";

            username = Console.ReadLine();
            password = Console.ReadLine();

            bool result = CheckUserPass(ref username, ref password);

            Console.WriteLine("你的输入是{0},当前用户名是{1},密码是{2}", result ? "对" : "错", username, password);

        }

        static bool CheckUserPass(ref string user, ref string pwd)
        {
            Console.WriteLine("正在核对信息");
            if (user == "888")
            {
                if (pwd == "666")
                {
                    return true;
                }
                else
                {
                    pwd = "密码错误";
                }

                return false;
            }
            else
            {
                user = "用户名错误";
                return false;
            }
        }
        static void ExchangeValue(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static void FindMaxAndMin(int[] array, out int max, out int min)
        {
            max = array[0];
            min = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (max < array[i])
                {
                    max = array[i];
                }

                if (min > array[i])
                {
                    min = array[i];
                }
            }

        }

        static void ResortArray(ref int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {

                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                    }
                }

            }

        }
        static void FindArray(ref string[] array, out int length, out string text)
        {
            length = array[0].Length;
            int number = 0;
            for (int i = 0; i < array.Length; i++)
            {

                if (length < array[i].Length)
                {
                    length = array[i].Length;
                    number = i;
                }

            }

            text = array[number];

        }


    }
}
