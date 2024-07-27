namespace _5._0泛型使用
{
    internal class Program
    {

        public class ArrayList<T>
        {
            public T[] arrayList;
            private int count;
            public ArrayList()
            {
                count = 0;
                arrayList = new T[16];
            }

            public void Add(T value)
            {
                if (count>=Capacity)
                {
                    T[] temp = new T[Capacity * 2];
                    for (int i = 0; i < Capacity; i++)
                    {
                        temp[i] = arrayList[i];
                    }

                    arrayList = temp;

                }
                arrayList[count] = value;
                count++;

            }

            public void Remove(T value)
            {
                int index = -1;
                for (int i = 0; i < Capacity; i++)
                {
                    if (arrayList[i].Equals(value))
                    {
                        index = i;
                        //最后一个设置为默认值 而不是这个
                        //arrayList[i] = default(T);
                        break;
                    }
                }
                if (index!=-1)
                {
                    for (int i = index; i < Capacity - 1; i++)
                    {
                        arrayList[i] = arrayList[i + 1];
                    }
                    arrayList[count - 1] = default(T);
                    count--; 
                }

            }

            public void RemoveAt(int index)
            {
                if (index < 0 || index >= count)
                {
                    Console.WriteLine("输入不合法");
                    return;
                }

                if (index != -1)
                {
                    for (int i = index; i < Capacity - 1; i++)
                    {
                        arrayList[i] = arrayList[i + 1];
                    }
                    arrayList[count - 1] = default(T);
                    count--;
                }
            }

            public T this[int index]
            {
                get {
                    if (index<0||index >=count)
                    {
                        Console.WriteLine("输入不合法");
                        return default(T);
                    }
                    return arrayList[index];
                }
                set {
                    if (index < 0 || index >= count)
                    {
                        return ;
                    }
                    arrayList[index] = value;

                }
            }
            public int Count { get { return count; } }
            public int Capacity { get { return arrayList.Length; } }
        }
        public class GenericBox<T>
        {
            private T content;

            public GenericBox(T content)
            {
                this.content = content;
            }
            public T GetContent()
            {
                return content;
            }
        }
        public static void JudgeType<T>(T t)
        {
            if (typeof(T)==typeof(string))
            {
                Console.WriteLine("this is string");
                return;
            }

            if (typeof(T) == typeof(Int32))
            {
                Console.WriteLine("this is 32 int");
                return;
            }
            if (typeof(T) == typeof(float))
            {
                Console.WriteLine("this is 32 float");
                return;
            }
            if (typeof(T) == typeof(char))
            {
                Console.WriteLine("this is char");
                return;
            }
            Console.WriteLine("Other type");

        }

        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
        static void Main(string[] args)
        {
            JudgeType<double>(5.5f);
            int x = 2, y = 3;
            Swap<int>(ref x, ref y);
            Console.Write(x +""+ y);

        }

        static void FindMax<T>()
        { 
        
        }
    }
}
