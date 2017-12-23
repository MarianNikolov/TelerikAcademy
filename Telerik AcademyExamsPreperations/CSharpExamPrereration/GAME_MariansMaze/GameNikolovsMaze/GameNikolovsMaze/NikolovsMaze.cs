using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GameNikolovsMaze
{
    class NikolovsMaze
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.Clear();
            string[] maze = new string[]
            {
                "███████████████",
                "█   █       █  ",
                "██ ████ █████ █",
                "██   █     ██ █",
                "█    ███      █",
                "█ ██     ██ ███",
                "█ █████████████"
            };



            int playerX = 1;
            int playerY = 6;
            char palyer = '☻';
            char wallSymbol = '█';
            int escapeX = 14;
            int escapeY = 1;
            Stopwatch timer = new Stopwatch();
            timer.Start();
            while (playerX != escapeX || playerY != escapeY)
            {
                // print maze
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(string.Join(Environment.NewLine, maze));

                // print the player
                Console.SetCursorPosition(playerX, playerY);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(palyer);

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (maze[playerY - 1][playerX] != wallSymbol)
                        {
                            playerY--;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (maze[playerY + 1][playerX] != wallSymbol)
                        {
                            playerY++;
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        if (maze[playerY][playerX - 1] != wallSymbol)
                        {
                            playerX--;
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        if (maze[playerY][playerX + 1] != wallSymbol)
                        {
                            playerX++;
                        }
                        break;
                    default: break;
                }

                char playerOnSymbol = maze[playerY][playerX];

                if (timer.Elapsed.Seconds > 10)
                {
                    break;
                }
            }
            timer.Stop();
            Console.Clear();
            Console.SetCursorPosition(15, 3);
            string massege = timer.Elapsed.Seconds < 10 ? "Congratulations SOFI, you escape from Nikolov's Maze" : "You losses, be faster next time!";
            Console.WriteLine(massege);
            Console.SetCursorPosition(15, 5);
            Console.WriteLine("Your did it for {0} seconds", timer.Elapsed.Seconds);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.SetCursorPosition(15, 10);

        }
    }
}
