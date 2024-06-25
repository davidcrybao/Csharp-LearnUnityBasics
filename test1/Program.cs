// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

bool isWallGenerated = false;
while (true)
{
    if (!isWallGenerated)
    {
        Console.SetCursorPosition(0, 0);
        for (int i = 0; i < 20; i++)
        {
            Console.WriteLine();
            for (int j = 0; j < 20; j++)
            {
                if (j == 0 || j == 19)
                {
                    Console.Write("■");
                }
                else
                {
                    if (i == 0 || i == 20 - 1 || i == 20 - 3)
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
}
