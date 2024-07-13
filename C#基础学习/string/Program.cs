
internal class Program
{
    static void Main(string[] args)
    {
        int[] array1 = { 1, 2, 33, 45, 564, 545, -1 };
        int c = 0;
        CompareNumbers(ref c, 5, 6);
        Console.WriteLine(c);


        Console.WriteLine(CheckLeapYear(2006));
    }

    static int CompareNumbers(ref int c, int a, int b)
    {
        c = 5;
        int bigger = a > b ? a : b;
        return bigger;
    }


    static int[] CircleAndPerimeter(int a)
    {
        int circle = (int)(a * a * Math.PI);
        int Perimeter = (int)(2 * a * Math.PI);
        return new int[] { circle, Perimeter };
    }

    static void CompareNumbers(int[] a)
    {
        int sum = 0;
        int max = a[0];
        int min = a[0];
        for (int i = 0; i < a.Length; i++)
        {
            sum += a[i];
            if (max < a[i])
            {
                max = a[i];
            }

            if (min > a[i])
            {
                min = a[i];
            }

        }
        Console.WriteLine("总和是{0},最大值是{1},最小值是{2},平均值是{3}", sum, max, min, sum / a.Length);
    }
    static bool CheckLeapYear(int year)
    {
        if (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0))
        {
            return true;
        }

        return false;
    }
}
