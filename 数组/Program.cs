using System.Collections;

namespace 数组
{
    internal class Program
    {
        /*        基础练习题目
声明一个包含10个整数的数组，并为其赋值，然后输出所有元素。
编写一个程序，计算并输出数组元素的平均值。
进阶练习题目
声明一个包含10个整数的数组，编写一个程序，找出并输出数组中所有偶数。
编写一个程序，对一个包含10个整数的数组进行排序（从小到大）。*/
        static void Main(string[] args)
        {
            #region 练习题
            /*
                        int[] numbers = { 1, 2, 3, 4, 5 };
                        int[] index = { 1, 35, 88, 4, 5, 6, 12, 8, 9, 10 };
                        for (int i = 0; i < index.Length; i++)
                        {
                            Console.WriteLine(index[i]);
                        }
                        CalculateAverageArray(index);

                        FindAllEvenInArray(index);
                        ResortArrayLowerToHigher(index);
                    }
                    private static void CalculateAverageArray(int[] array)
                    {
                        int sum = 0;
                        for (int i = 0; i < array.Length; i++)
                        {
                            sum += array[i];
                        }

                        Console.WriteLine("数组总共有{0}个数,平均数是{1}", array.Length, (float)sum / array.Length);

                    }

                    private static void FindAllEvenInArray(int[] array)
                    {
                        int count = 0;
                        for (int i = 0; i < array.Length; i++)
                        {
                            if (array[i] % 2 == 0)
                            {
                                count++;
                                Console.WriteLine("偶数:" + array[i]);
                            }

                        }

                        Console.WriteLine("总共偶数数量是{0}", count);

                    }

                    private static void ResortArrayLowerToHigher(int[] array)
                    {
                        for (int i = 0; i < array.Length - 1; i++)
                        {

                            for (int j = 0; j < array.Length - i - 1; j++)
                            {
                                if (array[j] > array[j + 1])
                                {
                                    int temp = array[j];
                                    array[j] = array[j + 1];
                                    array[j + 1] = temp;

                                }
                            }



                        }
                        Console.WriteLine("重新排序之后");
                        for (int i = 0; i < array.Length; i++)
                        {
                            Console.Write("  " + array[i]);
                        }

                    }
            */
            #endregion

            #region 练习题2
            /*int[] arrayList1 = new int[100];
            for (int i = 0; i < arrayList1.Length; i++)
            {
                arrayList1[i] = i;
                Console.WriteLine(arrayList1[i]);
            }

            int[] arrayList2 = { 2, 5, 7, 6, 11, 35 };
            int[] arrayList2operate = new int[arrayList2.Length];

            for (int i = 0; i < arrayList2.Length; i++)
            {
                arrayList2operate[i] = arrayList2[i] * 2;
                Console.WriteLine(arrayList2operate[i]);
            }

            int[] arraylist3 = new int[10];
            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                arraylist3[i] = random.Next(0, 101);
                Console.WriteLine(arraylist3[i]);
            }

            Console.WriteLine("***********************************");
            int[] arrayList4 = { 2, 5, 6, 7, 8, 52, 41, 32, 41, 88 };

            for (int i = 0; i < arrayList4.Length / 2; i++)
            {
                int temp = arrayList4[i];
                arrayList4[i] = arrayList4[arrayList4.Length - i - 1];
                arrayList4[arrayList4.Length - i - 1] = temp;
            }

            for (int i = 0; i < arrayList4.Length; i++)
            {
                Console.WriteLine(arrayList4[i]);
            }
*/
            /*    int[] arrayList5 = { 0, -5, 6, 7, 8, -52, 41, 32, 41, -88 };

                for (int i = 0; i < arrayList5.Length; i++)
                {
                    if (arrayList5[i] == 0)
                    {
                        continue;
                    }
                    if (arrayList5[i] > 0)
                    {
                        arrayList5[i]++;
                    }
                    else
                    {
                        arrayList5[i]--;
                    }
                }


                for (int i = 0; i < arrayList5.Length; i++)
                {
                    Console.WriteLine(arrayList5[i]);
                }


                int[] arrayList6 = new int[10];
                int max = 0;
                int min = 100;
                int sum = 0;
                for (int i = 0; i < arrayList6.Length; i++)
                {
                    arrayList6[i] = int.Parse(Console.ReadLine());
                    sum += arrayList6[i];
                    if (arrayList6[i] > max)
                    {
                        max = arrayList6[i];
                    }

                    if (arrayList6[i] < min)
                    {
                        min = arrayList6[i];
                    }
                }

                Console.WriteLine("最高和最低分分贝是{0}{1},平均分是{2}", max, min, sum / arrayList6.Length);*/

            string[] arrayText = new string[25];
            for (int i = 0; i < arrayText.Length; i++)
            {
                if (i % 2 == 0)
                {
                    arrayText[i] = "■";
                }
                else
                {
                    arrayText[i] = "□";
                }


            }
            for (int i = 0; i < arrayText.Length; i++)
            {
                Console.Write(arrayText[i]);
                if ((i + 1) % 5 == 0 && i > 0)
                {
                    Console.WriteLine();
                }
            }


            #endregion
        }
    }
}
