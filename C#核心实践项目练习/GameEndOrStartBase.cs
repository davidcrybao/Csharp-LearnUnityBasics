using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_核心实践项目练习
{
    internal abstract class GameEndOrStartBase : ISceneUpdate
    {
        public string title;
        public string firstOption;
        public int currentChoice;

        public void Update()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(Game.width / 2 - title.Length, 6);
            Console.Write(title);



            Console.ForegroundColor = currentChoice == 0 ? ConsoleColor.Red : ConsoleColor.White;
            Console.SetCursorPosition(Game.width / 2 - firstOption.Length, 9);
            Console.Write(firstOption);

            Console.ForegroundColor = currentChoice == 1 ? ConsoleColor.Red : ConsoleColor.White;
            Console.SetCursorPosition(Game.width / 2 - 4, 11);
            Console.Write("游戏结束");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.W:
                    currentChoice = 0;
                    break;
                case ConsoleKey.S:
                    currentChoice = 1;
                    break;
                case ConsoleKey.J:

                    Choose();
                    break;

            }


        }

        public abstract void Choose();
    }
}
