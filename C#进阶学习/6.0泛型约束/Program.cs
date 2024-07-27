using System.Collections;

namespace _6._0泛型约束
{
    internal class Program
    {
        class SingletonBase<T> where T : new()
        {

            private static T _instance;
            public static T Instance
            {

                get
                {
                    if (_instance==null)
                    {
                        _instance = new T();
                    }
                    return Instance; 
                }
            }
        }

        class Cache<Tkey, TValue> where Tkey : struct where TValue : class
        {
            Tkey key;
            TValue value;
            Hashtable hashtable;

            public Cache()
            {
                hashtable = new Hashtable();
            }
            public void Add(Tkey tkey, TValue Tvalue)
            { 
                hashtable.Add(tkey, Tvalue);    
            }
        }
        class KeyValuePair<TKey, TValue> where TKey : struct
        {
            TKey key;
            TValue Value;
        
        }
        public class Parit<T1, T2> where T1 : struct 
        { 
            public T1 First { get; set; }
            public T2 Second { get; set; }
        
        }


        public  class GameManager<T>
        {
            private static GameManager<T> instance = new GameManager<T>();

            public GameManager<T> Instance
            {
                get { return instance; }
            }
            
        }

        public interface IFly { }

        public class Test<T> where T : IFly 
        {
        }
        public class Gen<T> where T:new()
        { 
        }
        public class Gen1<T> where T : class, new()
        { 
        
        }
        public class Gen2<T,K> where T : new() where K:struct
        { }
        static void Main(string[] args)
        {
            
            Console.WriteLine(GetDefault<string>("32"));
            Console.WriteLine("Hello, World!");
        }

        static T GetDefault<T>(T value) where T:class
        { 
            return default(T);
        }
    }
}
