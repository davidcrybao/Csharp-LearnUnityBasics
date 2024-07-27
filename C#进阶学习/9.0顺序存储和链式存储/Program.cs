using System.Collections;
using System;

namespace _9._0顺序存储和链式存储
{
    public class DoubleLinkedNode<T>
    {
        public DoubleLinkedNode<T> nextNode;
        public DoubleLinkedNode<T> lastNode;
        public T value;

        public DoubleLinkedNode(T value)
        {
            this.value = value;
        }
    }

    public class DLinkedList<T>
    {
        public DoubleLinkedNode<T> head;
        public DoubleLinkedNode<T> last;
        public int count;

        public DLinkedList()
        {
            count = 0;
        }

        public void Add(T value)
        {
            DoubleLinkedNode<T> node = new DoubleLinkedNode<T>(value);
            if (head == null)
            {
                head = node;
                last = node;
            }
            else
            {
                //我想复杂了，在首届点为空的情况下，那么我们只有一个节点
                last.nextNode = node;  // 将当前最后一个节点的nextNode指向新节点
                node.lastNode = last;  // 将新节点的lastNode指向当前的最后一个节点
                last = node;           // 更新last指向新节点
            }
            count++;
        }

        public void Remove(T value)
        {
            if (head == null)
            {
                Console.WriteLine("没有节点可以移除");
                return;
            }
            DoubleLinkedNode<T> current = head;
            if (current.value.Equals(value))
            {
                // 如果要删除的是头节点
                head = current.nextNode;
                if (head != null)
                {
                    head.lastNode = null;
                }
                else
                {
                    last = null;
                }
                count--;
                return;
            }

            while (current != null)
            {
                if (current.value.Equals(value))
                {
                    if (current.nextNode == null)
                    {
                        // 如果要删除的是尾节点
                        last = current.lastNode;
                        last.nextNode = null;
                    }
                    else
                    {
                        // 如果要删除的是中间节点
                        current.lastNode.nextNode = current.nextNode;
                        current.nextNode.lastNode = current.lastNode;
                    }
                    count--;
                    return;
                }
                current = current.nextNode;
            }

            Console.WriteLine("未找到要删除的节点");
        }

        public void RemoveAt(int index)
        {
            int temp = 0;
            if (head == null || index >= count)
            {
                Console.WriteLine("没有节点可以移除");
                return;
            }

            DoubleLinkedNode<T> current = head;
            if (index == 0)
            {
                // 如果要删除的是头节点
                head = current.nextNode;
                if (head != null)
                {
                    head.lastNode = null;
                }
                else
                {
                    last = null;
                }
                count--;
                return;
            }

            while (current != null && temp < index)
            {
                current = current.nextNode;
                temp++;
            }

            if (current == null)
            {
                Console.WriteLine("未找到要删除的节点");
                return;
            }

            //如果删除的是尾节点
            if (current.nextNode == null)
            {
                last = current.lastNode;
                last.nextNode = null;
            }
            //中间节点的删除
            else
            {
                current.lastNode.nextNode = current.nextNode;
                current.nextNode.lastNode = current.lastNode;
            }
            count--;
        }

        public void PrintAllNode()
        {
            DoubleLinkedNode<T> current = head;
            while (current != null)
            {
                Console.WriteLine(current.value.ToString());
                current = current.nextNode;
            }
        }

        public void PrintAllNodeReverse()
        {
            DoubleLinkedNode<T> current = last;
            while (current != null)
            {
                Console.WriteLine(current.value.ToString());
                current = current.lastNode;
            }
        }
    }

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
                if (head == null)
                {
                    last = null;
                }
                return;
            }

            LinkedNode<T> current = head;
            LinkedNode<T> previous = null;

            while (current != null && !current.value.Equals(node))
            {
                previous = current;
                current = current.nextNode;
            }
            if (current != null)
            {
                //如果当前已经是最后一个节点,就是最后一个节点的值等于我们的node
                if (current == last)
                {
                    //改变链表里面的最后一个
                    last = previous;
                }
                //正常逻辑 都要修改 前一个节点等于我们的现在节点的下一个节点 切割
                previous.nextNode = current.nextNode;
            }
            else
            {
                Console.WriteLine("未找到要删除的节点。");
            }
        }

        public void PrintList()
        {
            LinkedNode<T> current = head;
            while (current != null)
            {
                Console.WriteLine(current.value);
                current = current.nextNode;
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

            LinkedList<int> list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            Console.WriteLine("链表中的元素：");
            list.PrintList();

            list.Remove(3);
            Console.WriteLine("删除值为 3 的节点后链表中的元素：");
            list.PrintList();

            list.Remove(1);
            Console.WriteLine("删除值为 1 的节点后链表中的元素：");
            list.PrintList();
        }
    }
}