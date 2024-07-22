namespace _9._07协变和逆变
{
    class Father { };
    class Son : Father { };
    internal class Program
    {
        delegate T TestOut<out T>();
        delegate void TestIn<in T>();
        delegate void TestIn2<in T>(T t);
        static void Main(string[] args)
        {
            TestOut<Son> son = delegate() { return new Son(); };
            TestOut<Father> father = son;
            Father f = father(); //实际上根据fahter=son, 返回的是一个Son;
                                 // Father father1 = new Son();
            //用父类委托装子类委托, 协变
            //用子类委托装父类委托 逆变 这两个只会在泛型接口和泛型委托内使用 

            TestIn<Father> Father = () => {  };
            TestIn<Son> Son1 = Father;
        }
    }
}
