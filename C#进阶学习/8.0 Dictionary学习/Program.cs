using System.Collections;

namespace _8._0_Dictionary学习
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
            foreach (KeyValuePair<string, int> item in keyValuePairs)
            {
            }
            string text2 = "Welcome to Unity WorldT";
          //  text = text.ToLower();
            Dictionary<char, int> times = new Dictionary<char, int>();

            for (int i = 0; i < text2.Length; i++) {
                if (!times.ContainsKey(text2[i]))
                {
                    times.Add(text2[i], 1);
                }
                else
                {
                    times[text2[i]]++;
                }
            }

            foreach (KeyValuePair<char,int> item in times)
            {
                Console.WriteLine(item.Key + "出现了" + item.Value + "次");
            }
            ConvertToChinese(025);

            string text = "this is a test this is a test this is a test";
            string[] words = text.Split(' ');

            Dictionary<string, int> frequencyDict = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (frequencyDict.ContainsKey(word))
                {
                    frequencyDict[word]++;
                }
                else
                {
                    frequencyDict[word] = 1;
                }
            }

            foreach (KeyValuePair<string, int> pair in frequencyDict)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }

        }

        private static void ConvertToChinese(int number)
        {
            Dictionary<int, string> convertChinese = new Dictionary<int, string> {
                { 1 ,"壹"},
                 { 2 ,"贰"},
                  {3 ,"叁"},
                  {4 ,"肆"},
                   {5 ,"伍"},
                  {6 ,"陆"},
                   {7 ,"柒"},
                   {8 ,"‌捌"},
                 {9 ,"‌玖"},
                {10," ‌拾" }
            };
            int temp = 0;
            string text = "";
            while (number/100>0)
            {
                temp = number / 100;
                text += convertChinese[temp];
                number = number % 100;
            }

            while (number / 10 > 0)
            {
                temp = number / 10;
                text += convertChinese[temp];
                number = number % 10;
            }
            text += convertChinese[number];
            Console.WriteLine(text);
        }
    }
}