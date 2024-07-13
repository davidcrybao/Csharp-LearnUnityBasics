using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11内部类和分部类
{
    public partial class Student
    {
        private int age;

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (age >= 0)
                {
                    age = value;
                }
                else
                {
                    Console.WriteLine("你的年龄不符合要求,设置为0了");
                    age = 0;
                }
            }


        }
        public void ShowAge()
        {
            Console.WriteLine(Age);
        }
    }
    internal class Class1
    {
    }
}
