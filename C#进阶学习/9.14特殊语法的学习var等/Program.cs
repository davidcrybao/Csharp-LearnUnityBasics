namespace _9._14特殊语法的学习var等
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //必须初始化不然会报错var i;
            var i = 5;

          //  int j = null;
            int? j = null;
            var jo = new { age = 10, money = 11 };
            string text = null;
            if (text==null)
            {
                Console.WriteLine("fuck you ");
            }
            if (text == null) Console.WriteLine("ficlk you second");

            // 方法一：定义并调用一个不接受参数的 Action
            Action action1 = () => Console.WriteLine("This is action1");
            action1?.Invoke();
               



        }
    }
}
