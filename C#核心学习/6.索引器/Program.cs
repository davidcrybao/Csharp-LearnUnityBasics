namespace _6.索引器
{
    public class Vector2
    {
        private int x;
        private int y;
        private int[,] xy;

        public Vector2(int x, int y)
        {
            xy = new int[x, y];
        }

        public int this[int x, int y]
        {
            get { return xy[x, y]; }
            set { xy[x, y] = value; }
        }
    }

    public class Numbers
    {
        public int Count => ints.Length;
        private int[] ints;
        private int capacity;
        private int length;

        public Numbers(int x)
        {
            capacity = x;
            length = 0;
            ints = new int[capacity];
        }

        public void Add(int value)
        {
            if (length < capacity)
            {
                ints[length] = value;
                length++;
            }
            else
            {
                capacity *= 2;
                int[] temp = new int[capacity];

                for (int i = 0; i < capacity; i++)
                {
                    temp[i] = ints[i];
                }
                ints = temp;
                ints[length] = value;
                length++;
            }

        }
        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= ints.Length)
                {
                    throw new IndexOutOfRangeException("Index out of range.");
                }
                return ints[index];
            }
            set
            {
                if (index < 0 || index >= ints.Length)
                {
                    throw new IndexOutOfRangeException("Index out of range.");
                }
                ints[index] = value;
            }
        }

        public void Add(params int[] number)
        {

            if (length < capacity && capacity - length >= number.Length)
            {
                for (int i = 0; i < capacity; i++)
                {
                    ints[i + length] = number[i];
                }
                length += number.Length;
            }
            else
            {
                ExpandCapacity(number.Length);
                for (int i = 0; i < capacity; i++)
                {
                    ints[i + length] = number[i];
                }
                length += number.Length;

            }


            /*     //更新新的方法,先判断这个数组里面是不是有存放数字
             *     int[] temp = new int[number.Length + ints.Length];
                  for (int i = 0; i < ints.Length; i++)
                  {
                      temp[i] = ints[i];
                  }

                  for (int i = 0; i < number.Length; i++)
                  {
                      temp[ints.Length + i] = number[i];
                  }

                  ints = temp;*/
        }

        private void ExpandCapacity(int additionalLength)
        {
            capacity = Math.Max(capacity * 2, length + additionalLength);
            int[] temp = new int[capacity];
            Array.Copy(ints, temp, length);
            ints = temp;
        }

        public void RemoveAll(int value)
        {
            for (int i = 0; i < length; i++)
            {
                if (ints[i] == value)
                {
                    RemoveAt(i);
                    Console.WriteLine("发现一个值,位置在{0}", i);
                }
            }

            /*     int count = 0;
                 for (int i = 0; i < ints.Length; i++)
                 {
                     if (value == ints[i])
                     {
                         count++;
                     }
                 }
                 // 如果没有要删除的元素，直接返回
                 if (count == 0)
                 {
                     return;
                 }
                 int[] temp = new int[ints.Length - count];

                 count = 0;
                 for (int i = 0; i < ints.Length; i++)
                 {
                     if (value == ints[i])
                     {
                         count++;
                         continue;
                     }
                     temp[i - count] = ints[i];
                 }

                 *//* int index = 0;

                  // 复制不需要删除的元素到新数组 思路优化
                  for (int i = 0; i < ints.Length; i++)
                  {
                      if (ints[i] != value)
                      {
                          temp[index++] = ints[i];
                      }
                  }*//*

                 ints = temp;*/
        }
        public void Remove(int value)
        {
            for (int i = 0; i < length; i++)
            {
                if (ints[i] == value)
                {
                    RemoveAt(i);
                    return;
                }
            }
            Console.WriteLine("没有找到该值");

        }
        public void RemoveAt(int index)
        {
            if (index > length - 1 || index < 0)
            {
                throw new IndexOutOfRangeException("要移除的位置并未赋值");
            }
            //为什么length-1  比如数组{1,2,5} 比如length=2,可以理解为2个已经赋值
            //我们移除第0个位置的 我们只需要把这个位置后面有赋值的数值前移! ints[0]=ints[1];  - ints[1]=ints[2]; 那么这时候就要结束了,
            for (int i = index; i < length - 1; i++)
            {
                ints[i] = ints[i + 1];
            }
            length--;
            //下面的方法会让数组的大小改变,可能我们不希望这样的改变,那么就要进行另外的操作 index位置上的数值=index+1
            /*     
             *     
             *       if (index < 0 || index >= ints.Length)
            {
                throw new IndexOutOfRangeException("Index out of range.");
            }

                int[] temp = new int[ints.Length - 1];

                 for (int i = 0; i < index; i++)
                 {
                     temp[i] = ints[i];
                 }

                 for (int i = index; i < ints.Length; i++)
                 {
                     temp[i] = ints[i + 1];
                 }

                 ints = temp;
             }*/
        }

        internal class Program
        {
            private static void Main(string[] args)
            {
                Vector2 vector2 = new Vector2(1, 2);
                Console.WriteLine(vector2[0, 0]);

                vector2[0, 1] = 5;
                Console.WriteLine(vector2[0, 1]);
                int[] newArray = new int[22];
                Console.WriteLine(newArray[0]);
                Numbers numbers = new Numbers(3);
                numbers.Add(5, 8, 9, 10, 15, 10, 25);
                for (int i = 0; i < numbers.length; i++)
                {
                    Console.Write(numbers[i] + " ");
                }
                numbers.Remove(12);
                numbers.Remove(15);
                Console.WriteLine("移除15之后");
                for (int i = 0; i < numbers.length; i++)
                {
                    Console.Write(numbers[i] + " ");
                }

                numbers.RemoveAll(10);
                Console.WriteLine("移除所有10之后");
                for (int i = 0; i < numbers.length; i++)
                {
                    Console.Write(numbers[i] + " ");
                }

            }
        }
    }
}
