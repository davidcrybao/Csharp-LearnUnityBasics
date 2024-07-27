namespace _9._08多线程
{
    public enum MoveDir
    {
        Up, Right, Down, Left
    }

    public class Cube
    {
        private Position position;
        private MoveDir moveDir;

        public Cube(int x, int y, MoveDir moveDir)
        {
            this.position = new Position(x, y);
            this.moveDir = moveDir;
        }

        public void Draw()
        {
            Console.SetCursorPosition(position.x, position.y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("■");
        }

        public void Clear()
        {
            Console.SetCursorPosition(position.x, position.y);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("  ");
        }

        public void Move()
        {
            switch (moveDir)
            {
                case MoveDir.Up:
                    position.y -= 1;
                    break;

                case MoveDir.Down:
                    position.y += 1;
                    break;

                case MoveDir.Left:
                    position.x -= 2;
                    break;

                case MoveDir.Right:
                    position.x += 2;
                    break;
            }
        }

        public void ChangeDir(MoveDir moveDir)
        {
            this.moveDir = moveDir;
        }
    }

    public struct Position
    {
        public int x;
        public int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    internal class Program
    {

        private static bool isRunning = true;
        private static Cube cube;
        static int counter = 0;
        static object lockObj = new object();
        private static void Main(string[] args)
        {
            /*          cube = new Cube(5, 5, MoveDir.Right);
                      cube.Draw();
                      isRunning = false;
                      *//*thread.Abort();
                      thread = null;*//*
                      Thread thread1 = new Thread(TestThread);
                      thread1.Start();
                      thread1.IsBackground = true;

                      Thread thread3 = new Thread(DoWork);
                      Thread thread2 = new Thread(DoWork);

                      thread3.Start();
                      thread2.Start();
                      while (true)
                      {

                          Thread.Sleep(1000);
                          cube.Clear();
                          cube.Move();
                          cube.Draw();
                      }*/


            Thread thread1 = new Thread(Increment);
            Thread thread2 = new Thread(Increment);
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"最终计数器的值: {counter}");

        }
        static void DoWork()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"线程ID: {Thread.CurrentThread.ManagedThreadId}, 计数: {i}");
                Thread.Sleep(1000); // 休眠1秒
            }
        }

        static void Increment()
        {
            for (int i = 0; i < 1000; i++)
            {
                lock (lockObj)
                {
                  
                    Console.WriteLine($"计数器的值: {counter}");
                    counter++;
                }
            }
        }
        private static void TestThread()
        {
            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.W:
                        cube.ChangeDir(MoveDir.Up);
                        break;

                    case ConsoleKey.S:
                        cube.ChangeDir(MoveDir.Down);
                        break;

                    case ConsoleKey.A:
                        cube.ChangeDir(MoveDir.Left);
                        break;

                    case ConsoleKey.D:
                        cube.ChangeDir(MoveDir.Right);
                        break;
                }
            }

        }
    }
}
