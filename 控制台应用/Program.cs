// See https://aka.ms/new-console-template for more information
using System.Drawing;





/*

int width = 80;
int height = 25;
int playerX = width / 2;
int playerY = height / 2;
Console.SetWindowSize(width, height);
Console.SetBufferSize(width, height);
Console.CursorVisible = false;
Console.ForegroundColor = ConsoleColor.Yellow;
Console.BackgroundColor = ConsoleColor.Red;
Console.Clear();


while (true)
{
    Console.Clear();

    Console.Write("■");

    Char keychar = Console.ReadKey(true).KeyChar;
    switch (keychar)
    {
        case 'd':
            if (playerX > width - 2) break;
            playerX++;
            break;
        case 'a':
            if (playerX < 1) break;
            playerX--;
            break;
        case 'w':
            if (playerY < 1) break;
            playerY--;
            break;
        case 's':
            if (playerY > height - 2) break;
            playerY++;
            break;
    }

    if (keychar == 'q')
    {
        Console.WriteLine("exit");
        break;
    }
}*/


int width = 80;
int height = 25;
int playerX = 0;
int playerY = 0;
Console.SetWindowSize(width, height);
Console.SetBufferSize(width, height);
Console.CursorVisible = false;
Console.ForegroundColor = ConsoleColor.Yellow;
Console.BackgroundColor = ConsoleColor.Red;
Console.Clear();

while (true)
{


    Console.SetCursorPosition(playerX, playerY);
    Console.Write("■");
    Char keychar = Console.ReadKey(true).KeyChar;

    Console.SetCursorPosition(playerX, playerY);
    Console.Write("  ");
    switch (keychar)
    {
        case 'a':
            if (playerX < 1)
            {
                playerX = width;
            }
            playerX -= 2;
            break;
        case 'd':
            if (playerX >= 78)
            {
                playerX = 0;
                break;
            }
            playerX += 2;
            break;
        case 'w':
            if (playerY <= 0)
            {
                playerY = height - 1;
                break;
            }
            playerY--;
            break;
        case 's':
            if (playerY >= 24)
            {
                playerY = 0;
                break;
            }
            playerY++;

            break;
    }

}
