namespace _9._05lambda表达式的学习
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action action = () => { Console.WriteLine("fuck you "); };
            action();
            Action<int> action1 = (int value) => { Console.WriteLine(value); };
            action1(123);
            Action<int> action2 = (value) => { Console.WriteLine(value); };  
            action2(222);
            Action<int> action3 = (value) => Console.WriteLine(value);
            action3(333);
            Func<int> func1 = () => { return 25; };
            Console.WriteLine(func1());
            Func<int,string> func2 = (int x) => { return (x*520+"this is ").ToString(); };
            Console.WriteLine(func2(2));
            Console.WriteLine(string.Format("asdasd{0}{1}", 25, 55));
            /*  Action newAction = Test();
              newAction();*/
            Test()();
        }
        static Action Test()
        {
            Action action = () => { Console.WriteLine("测试函数功能"); };
            for (int i = 1; i < 11; i++)
            {
                int x = i;
                action +=  () =>{ Console.WriteLine(i+" "+ x); };
            }
            return action;
        }
    }
}
