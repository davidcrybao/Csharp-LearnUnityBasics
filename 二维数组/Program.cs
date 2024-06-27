using System.Collections.Specialized;

namespace 二维数组
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*int[,] oneTothousands = new int[100, 100];
            int count = 0;
            for (int i = 0; i < oneTothousands.GetLength(0); i++)
            {
                for (int j = 0; j < oneTothousands.GetLength(1); j++)
                {
                    count++;
                    oneTothousands[i, j] = count;
                }
            }
          */

            /*  #region 题目2

              Random random = new Random();
              int[,] ints2 = new int[4, 4];


              for (int i = 0; i < ints2.GetLength(0); i++)
              {
                  for (int j = 0; j < ints2.GetLength(1); j++)
                  {
                      ints2[i, j] = random.Next(1, 101);
                  }
              }

              for (int i = 0; i < ints2.GetLength(0); i++)
              {
                  Console.WriteLine();
                  for (int j = 0; j < ints2.GetLength(1); j++)
                  {
                      if (j > 1 && i < 2)
                      {
                          ints2[i, j] = 0;
                      }
                      Console.Write("  " + ints2[i, j]);
                  }
              }

              #endregion
  */
            /*#region 题目3

            Random random = new Random();
            int[,] ints2 = new int[3, 3];


            for (int i = 0; i < ints2.GetLength(0); i++)
            {
                for (int j = 0; j < ints2.GetLength(1); j++)
                {
                    ints2[i, j] = random.Next(1, 11);
                }
            }

            for (int i = 0; i < ints2.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < ints2.GetLength(1); j++)
                {
                    Console.Write("  " + ints2[i, j]);
                }
            }

            int sum1 = 0;
            int sum2 = 0;
            int rows = ints2.GetLength(0);
            int cols = ints2.GetLength(1);

            for (int i = 0; i < ints2.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < ints2.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        sum1 += ints2[i, j];
                    }
                    if (i + ints2.GetLength(1) - 1 - j == 2)
                    {
                        sum2 += ints2[i, ints2.GetLength(1) - 1 - j];
                    }

                }
            }

             // 计算主对角线元素之和
            for (int i = 0; i < rows; i++)
            {
                sum1 += ints2[i, i];
            }

            // 计算副对角线元素之和
            for (int i = 0; i < rows; i++)
            {
                sum2 += ints2[i, cols - 1 - i];
            }

            Console.WriteLine("主对角线元素之和: " + sum1);
            Console.WriteLine("副对角线元素之和: " + sum2);
            Console.WriteLine("左边对角线和{0}右边对角线的和{1}", sum1, sum2);


            #endregion*/
            /*
                        #region 题目4 最大数组

                        Random random = new Random();
                        int[,] ints2 = new int[5, 5];

                        int max = 0;
                        int[,] position = new int[2, 1];
                        for (int i = 0; i < ints2.GetLength(0); i++)
                        {
                            for (int j = 0; j < ints2.GetLength(1); j++)
                            {
                                ints2[i, j] = random.Next(1, 501);
                            }
                        }

                        for (int i = 0; i < ints2.GetLength(0); i++)
                        {
                            Console.WriteLine();
                            for (int j = 0; j < ints2.GetLength(1); j++)
                            {

                                if (max < ints2[i, j])
                                {
                                    max = ints2[i, j];
                                    position[0, 0] = i;
                                    position[1, 0] = j;
                                }
                                Console.Write("  " + ints2[i, j]);
                            }
                        }
            //可以用两个变量maxI,maxJ来完成.
                        Console.WriteLine("最大数值是{0},他所在的位置是第{1}行, {2}列", max, position[0, 0], position[1, 0]);
                        #endregion*/

            #region 题目5 

            Random random = new Random();
            int[,] ints5 = new int[3, 3];
            int[] rows = new int[ints5.GetLength(0)];
            int[] cols = new int[ints5.GetLength(1)];


            for (int i = 0; i < ints5.GetLength(0); i++)
            {
                for (int j = 0; j < ints5.GetLength(1); j++)
                {
                    ints5[i, j] = random.Next(0, 2);
                }
            }


            for (int i = 0; i < ints5.GetLength(0); i++)
            {
                for (int j = 0; j < ints5.GetLength(1); j++)
                {

                    //判断行与列,如果有1就标注该行/列为1
                    if (ints5[i, j] == 1)
                    {
                        rows[i] = 1;
                        cols[j] = 1;
                    }
                    Console.Write("  " + ints5[i, j]);

                }
                Console.WriteLine();
            }





            //打印行与列
            for (int i = 0; i < rows.Length; i++)
            {
                Console.WriteLine(rows[i]);
            }
            Console.WriteLine("************");
            for (int i = 0; i < cols.Length; i++)
            {
                Console.WriteLine(cols[i]);
            }


            for (int i = 0; i < ints5.GetLength(0); i++)
            {
                if (rows[i] == 1)
                {
                    for (int j = 0; j < ints5.GetLength(1); j++)
                    {
                        ints5[i, j] = 1;
                    }
                }

            }

            for (int i = 0; i < ints5.GetLength(1); i++)
            {
                if (cols[i] == 1)
                {
                    for (int j = 0; j < ints5.GetLength(0); j++)
                    {
                        ints5[j, i] = 1;
                    }
                }

            }

            //重新打印
            Console.WriteLine("重新打印");
            for (int i = 0; i < ints5.GetLength(0); i++)
            {
                for (int j = 0; j < ints5.GetLength(1); j++)
                {

                    Console.Write("  " + ints5[i, j]);

                }
                Console.WriteLine();
            }


            #endregion












        }


    }
}
