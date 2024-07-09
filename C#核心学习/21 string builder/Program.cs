
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace _21_string_builder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //StringBuilder
            //stringBuilder是动态容量,所以我们只有在超出他容量的时候,他才会去扩容,相对stirng每一次改动都要在一个新的地址上


            string text = Console.ReadLine();
            StringBuilder textInput = new StringBuilder(text);
            Console.WriteLine(textInput.Replace(" ", "_"));
            Reverse(text);
        }
        static void Reverse(string text)
        {

            StringBuilder textInput = new StringBuilder(text);
            for (int i = 0; i < textInput.Length / 2; i++)
            {
                char temp = textInput[i];
                textInput[i] = textInput[textInput.Length - 1 - i];
                textInput[textInput.Length - 1 - i] = temp;
            }
            Console.WriteLine(textInput);
        }
    }
}
