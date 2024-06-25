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

            while (true)
            {
                height = 25;
                bool isWallGenerated = false;
                if (!isWallGenerated)
                {
                    Console.SetCursorPosition(0, 0);
                    for (int i = 0; i < height + 7; i++)
                    {
                        Console.WriteLine();
                        for (int j = 0; j < height; j++)
                        {
                            if (j == 0 || j == height - 1)
                            {
                                Console.Write("■");
                            }
                            else
                            {
                                if (i == 0 || i == height + 2 || i == height + 6)
                                {
                                    Console.Write("■");
                                }
                                else
                                {
                                    Console.Write("  ");
                                }

                            }
                        }

                    }
                }
                isWallGenerated = true;

                Console.WriteLine("fuck you ");

            }

            break;
        case 2:
            break;
    }
}



int GetCharCount(string text)
{
    int count = 0;
    foreach (Char c in text)
    {
        count++;
    }
    return width / 2 - count;
}
