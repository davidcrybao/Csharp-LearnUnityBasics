using System.Collections;

namespace _9._13迭代器的学习
{
    public class Test : IEnumerable, IEnumerator
    {
        private int[] list;
        private int position = -1;
        public Test()
        {
            list = new int[] { 1, 2, 5, 8, 7, 4, 6 };
        }
        public object Current
        {
            get { return list[position]; }
        }

        public IEnumerator GetEnumerator()
        {
            Reset();
            return this;
        }

        public bool MoveNext()
        {
            position++;
            return position< list.Length;
        }

        public void Reset()
        {
            position = -1;
        }
    }

    public class CustomCollection<T> : IEnumerable<T>
    {
        private T[] items;
        public CustomCollection(T[] items)
        {
            this.items = items;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new CustomEumerator(items);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        private class CustomEumerator : IEnumerator<T>
        {
            private T[] items;


            private int _position = -1;

             public CustomEumerator(T[] items)
            {
                this.items = items;
            }

            public T Current
            {
                get
                {
                    if (_position<0||_position>=items.Length)
                    {
                        throw new InvalidOperationException();
                    }
                    return items[_position];
                }
            }
            object IEnumerator.Current => Current;


            public void Dispose()
            {
                //throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                _position++;
                return _position < items.Length;
            }

            public void Reset()
            {
               _position = -1;
            }
        }

    }

    public class Ienumerator:IEnumerable,IEnumerator
    {
        private int[] ints;
        private int _position;

        public Ienumerator()
        {
            ints = new int[] { 1, 8, 9, 22, 3, 2, 1, 5, 6, 1, 3, 7, 8 };
            _position = -1;
        }

        public object Current
        {
            get {
                if (_position<0||_position>ints.Length)
                {
                    Console.WriteLine("FK");
                }
                return ints[_position];
            }
        }

        public IEnumerator GetEnumerator()
        {
            Reset();
            return this;
        }
/*        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < ints.Length; i++)
            {
                yield return ints[i];
            }
        }*/

        public bool MoveNext()
        {
            _position++;
            return _position < ints.Length;
        }

        public void Reset()
        {
            _position = -1;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
        /*    Test test = new Test();
            foreach (var item in test)
            {
                Console.WriteLine(item);
            }

            var customItems = new CustomCollection<int>(new int[] { 1, 2, 3, 4, 5 });
            foreach (var item in customItems)
            {
                Console.WriteLine(item);
            }
*/
            var Ienumerator = new Ienumerator();
            foreach (var item in Ienumerator)
            {
                Console.WriteLine(item);
            }
        }
    }
}
