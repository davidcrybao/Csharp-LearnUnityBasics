using System.Collections;
using System;

namespace _9._0顺序存储和链式存储
{
    public class LinkedNode<T>
    {
        public T value;
        public LinkedNode<T> nextNode;

        public LinkedNode(T value)
        {
            this.value = value;
        }
    }

    public class LinkedList<T>
    {
        public LinkedNode<T> head;
        public LinkedNode<T> last;

        //泛型还是要加强学习
        public void Add(T value)
        {
            LinkedNode<T> node = new LinkedNode<T>(value);
            if (head == null)
            {
                head = node;
                last = node;
            }
            else
            {
                last.nextNode = node;
                last = node;
            }
        }

        public void Remove(T node)
        {
            if (head == null)
            {
                Console.WriteLine("链表为空，无法删除。");
                return;
            }

            if (head.value.Equals(node))
            {
                head = head.nextNode;
                //
                if (head==null)
                {
                    last = null;
                }
                return;
            }
      
            LinkedNode<T> temp = last;
            while (temp.nextNode != null)
            {
                if (temp.value.Equals(node))
                {
                    
                    temp.nextNode = temp.nextNode.nextNode;
                }
                else
                {
                    temp = temp.nextNode;
                }
             
            }
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            LinkedNode<int> t1 = new LinkedNode<int>(1);
            LinkedNode<int> t2 = new LinkedNode<int>(2);
            t1.nextNode = t2;
            Console.WriteLine(t1.nextNode.value);
            
        }
    }
}