namespace _9._15值和引用类型的加强学习
{
    public interface ITestValue
    {
        public int Value { get; set; }
    }
    public struct TestStruct : ITestValue
    {
        int value;

        public TestStruct(int value)
        {
            this.value = value;
        }

        public int Value { get => value; set => this.value=value; }

    }
    internal class Program
    {
        static int c = 5;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //代码快
            {
                int b = 5;
                Console.WriteLine(c+1);
            }
            Console.WriteLine(c);
            //   Console.WriteLine(b); //报错
            /*
             * 命名空间namespace{}
             * 类Class 接口interface 结构体struct
             * 函数void/T/ 属性  所以请 运算符重载 也可以有类接口结构体
             * 这些里面的,和条件分支,循环
             * 
             * */
            Console.WriteLine("-----------------------------");
            ITestValue testValue=new TestStruct(8);
            Console.WriteLine(testValue.Value);
            ITestValue testValue2 = testValue;
            testValue2.Value = 5;
            Console.WriteLine(testValue.Value);            Console.WriteLine(testValue2.Value);
            

        }
    }
}
