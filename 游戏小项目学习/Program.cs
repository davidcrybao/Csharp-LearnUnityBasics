// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

int currentSceneID = 1;
int height = 35;
int width = 50;
Console.SetWindowSize(width, height);
Console.SetBufferSize(width, height);
Console.CursorVisible = false;
int zPosition = 8;
int xPosition = 0;
string title = "英九公主计划";
xPosition = GetCharCount(title);
Console.SetCursorPosition(xPosition, zPosition - 3);
Console.WriteLine(title);
xPosition = GetCharCount("开始游戏");


int index = 0;


while (true)
{
    switch (currentSceneID)
    {

        case 0:

            while (true)
            {
                bool isSceneOver = false;
                Console.SetCursorPosition(xPosition, zPosition);
                Console.ForegroundColor = index == 0 ? ConsoleColor.Red : ConsoleColor.White;
                Console.WriteLine("开始游戏");
                Console.SetCursorPosition(xPosition, zPosition + 2);
                Console.ForegroundColor = index == 1 ? ConsoleColor.Red : ConsoleColor.White;
                Console.WriteLine("结束游戏");


                ConsoleKey input = Console.ReadKey(true).Key;
                switch (input)
                {
                    case ConsoleKey.W:
                        index = 0;
                        break;
                    case ConsoleKey.S:
                        index = 1;
                        break;
                    case ConsoleKey.E:

                        if (index == 0)
                        {
                            currentSceneID = 1;
                            isSceneOver = true;
                            Debug.WriteLine("开始游戏");
                        }
                        else
                        {
                            Debug.WriteLine("结束游戏");
                            Environment.Exit(0);
                        }
                        break;
                }
                if (isSceneOver)
                {
                    break;
                }
            }
            break;
        case 1:
            Console.Clear();
            Random randomPosition = new Random();
            int enemyX = randomPosition.Next(1, 24) * 2;
            int enemyY = randomPosition.Next(1, 14) * 2;
            int x = 2;
            int y = 2;
            bool generateWallAndEnemy = false;

            while (true)
            {
                if (!generateWallAndEnemy)
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    for (int i = 0; i < height; i++)
                    {
                        Console.SetCursorPosition(0, i);
                        Console.Write("■");
                        Console.SetCursorPosition(width - 2, i);
                        Console.Write("■");
                    }

                    for (int i = 0; i < width; i += 2)
                    {
                        Console.SetCursorPosition(i, 0);
                        Console.Write("■");
                        Console.SetCursorPosition(i, height - 1);
                        Console.Write("■");
                        Console.SetCursorPosition(i, height - 6);
                        Console.Write("■");
                    }
                    /*     Console.SetCursorPosition(0, 0);
                         for (int i = 0; i < height; i++)
                         {
                             Console.WriteLine("■");
                         }*/

                    Console.SetCursorPosition(enemyY, enemyY);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("◆");

                }
                generateWallAndEnemy = true;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(x, y);
                Console.Write("◆");
                ConsoleKey input = Console.ReadKey(true).Key;

                Console.SetCursorPosition(x, y);
                Console.Write("  ");


                switch (input)
                {
                    case ConsoleKey.W:
                        if (y <= 2)
                        {
                            y = 2;
                            break;
                        }
                        if (x != xPosition)
                        {
                            y--;
                        }
                        else
                        {
                            y = Math.Abs(y - enemyY) > 2 ? y - 1 : y;
                        }
                        break;
                    case ConsoleKey.S:
                        if (y >= 27)
                        {
                            y = 27;
                            break;
                        }
                        y++;
                        break;
                    case ConsoleKey.A:
                        if (x <= 2)
                        {
                            x = 2;
                            break;
                        }
                        x = x - 2;
                        break;
                    case ConsoleKey.D:
                        if (x >= 46)
                        {
                            x = 46;
                            break;
                        }
                        x = x + 2;
                        break;
                }


            }


            break;
        case 2:
            break;
    }
}


/*bool CanWalk(ConsoleKey consoleKey,int positionX,int positionY)
{

    switch (consoleKey)
    {
        case ConsoleKey.W:
            if (y <= 2)
            {
                y = 2;
                break;
            }
            y--;
            break;
        case ConsoleKey.S:
            if (y >= 27)
            {
                y = 27;
                break;
            }
            y++;
            break;
        case ConsoleKey.A:
            if (x <= 2)
            {
                x = 2;
                break;
            }
            x = x - 2;
            break;
        case ConsoleKey.D:
            if (x >= 46)
            {
                x = 46;
                break;
            }
            x = x + 2;
            break;
    }
}*/
int GetCharCount(string text)
{
    int count = 0;
    foreach (Char c in text)
    {
        count++;
    }
    return width / 2 - count;
}
