using System;
using System.Collections.Generic;
using System.Threading;

class FallingRocks
{
    struct Rocks
    {
        public int x;
        public int y;
        public char c;
        public ConsoleColor color;
    }


    static void PrintOnPosition(int x, int y, char c,
        ConsoleColor color = ConsoleColor.Yellow)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(c);
    }


    static void Main()
    {
        int playfieldWidth = 10;
        
        Console.WriteLine();

        // Set console width ane height
        Console.BufferHeight = Console.WindowHeight = 30;
        Console.BufferWidth = Console.WindowWidth = 50;

        // Create player
        Rocks player = new Rocks();
        player.x = 2;
        player.y = Console.WindowHeight - 1;
        player.c = '@';
        player.color = ConsoleColor.Cyan;
        
        // Rocks
        Random rendomGenerator = new Random();
        List<Rocks> rocks = new List<Rocks>();
        ///////// START ////// START ////// START////// START
        while (true)
        {
            
            // Rock
            Rocks newRock = new Rocks();
            newRock.color = ConsoleColor.Red;
            newRock.x = rendomGenerator.Next(0, playfieldWidth);
            newRock.y = 0;
            newRock.c = '#';
            rocks.Add(newRock);

            // Move player (key pressed)
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
                
                    
                

                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (player.x - 1 >= 0)
                    {
                        player.x -= 1;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (player.x + 1 < playfieldWidth)
                    {
                        player.x += 1;
                    }
                }
            }

            // Move rocks
            

            // Check if rocks are hitting player


            // Clear playfield
            Console.Clear();

            // Redraw playfield
            PrintOnPosition(player.x, player.y, player.c, player.color);
            foreach (Rocks rock in rocks)
            {
                PrintOnPosition(rock.x, rock.y, rock.c, rock.color);
            }

            // Draw info





            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.SetCursorPosition(10, i);
                Console.Write("|");
            }
            

            // Slow down program
            Thread.Sleep(100);

        }







    }
}

