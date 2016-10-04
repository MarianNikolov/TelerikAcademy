using System;
using System.Collections.Generic;

namespace RefactorApplication1
{
    public class Mine
    {
        public class PointsInGame
        {
            string name;
            int points;

            public string Name
            {
                get
                {
                    return this.name;
                }
                set
                {
                    name = value;
                }
            }

            public int Points
            {
                get
                {
                    return this.points;
                }
                set
                {
                    points = value;
                }
            }

            public PointsInGame() { }

            public PointsInGame(string name, int points)
            {
                this.name = name;
                this.points = points;
            }
        }

        static void Main()
        {
            string command = string.Empty;
            char[,] field = createField();
            char[,] bombs = setBombs();
            int counter = 0;
            bool endGame = false;
            List<PointsInGame> winers = new List<PointsInGame>(6);
            int rows = 0;
            int cols = 0;
            bool firstFlag = true; 
            const int max = 35;
            bool secondFlag = false;  

            do
            {
                if (firstFlag)
                {
                    Console.WriteLine("GAME “Mine”.\n" +
                    " Commands:\n 'top' - shows ranking,\n 'restart' - start new game,\n 'exit' - exit from game!\n");
                    DrawField(field);
                    firstFlag = false;
                }

                Console.Write("Enter row and col: ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out rows) 
                        && int.TryParse(command[2].ToString(), out cols) 
                        && rows <= field.GetLength(0) 
                        && cols <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        Ranking(winers);
                        break;
                    case "restart":
                        field = createField();
                        bombs = setBombs();
                        DrawField(field);  
                        endGame = false;
                        firstFlag = false; 
                        break;
                    case "exit":
                        Console.WriteLine("bye, bye, bye!");
                        break;
                    case "turn":
                        if (bombs[rows, cols] != '*')
                        {
                            if (bombs[rows, cols] == '-')
                            {
                                YourTurn(field, bombs, rows, cols);
                                counter++;
                            }

                            if (max == counter)
                            {
                                secondFlag = true;
                            }
                            else
                            {
                                DrawField(field);
                            }
                        }
                        else
                        {
                            endGame = true;
                        }
                        break;
                    default:
                        Console.WriteLine("\nError! invalid command\n");
                        break;
                }

                if (endGame)
                {
                    DrawField(bombs);
                    Console.Write("\nHrrrrrr! You are dead with {0} points. " +
                        "Enter your name: ", counter);
                    string playerName = Console.ReadLine();
                    PointsInGame curentPoints = new PointsInGame(playerName, counter);
                    if (winers.Count < 5)
                    {
                        winers.Add(curentPoints);
                    }
                    else
                    {
                        for (int i = 0; i < winers.Count; i++)
                        {
                            if (winers[i].Points < curentPoints.Points)
                            {
                                winers.Insert(i, curentPoints);
                                winers.RemoveAt(winers.Count - 1);
                                break;
                            }
                        }
                    }

                    winers.Sort((PointsInGame firstWiner, PointsInGame secondWiner) 
                        => secondWiner.Name.CompareTo(firstWiner.Name));
                    winers.Sort((PointsInGame firstWiner, PointsInGame secondWiner) 
                        => secondWiner.Points.CompareTo(firstWiner.Points));
                    Ranking(winers);

                    field = createField();
                    bombs = setBombs();
                    counter = 0;
                    endGame = false;
                    firstFlag = true;
                }

                if (secondFlag)
                {
                    Console.WriteLine("\nCongratulations! You WIN.");
                    DrawField(bombs);
                    Console.WriteLine("Enter your name: ");
                    string playerName = Console.ReadLine();
                    PointsInGame point = new PointsInGame(playerName, counter); 
                    winers.Add(point);
                    Ranking(winers);
                    field = createField();
                    bombs = setBombs();
                    counter = 0;
                    secondFlag = false;
                    firstFlag = true;
                }
            }
            while (command != "exit");

            Console.WriteLine("Refactor by Marian!");
            Console.WriteLine("All rights reserved.");
            Console.Read();
        }

        private static void Ranking(List<PointsInGame> points)
        {
            Console.WriteLine("\nPoints:");
            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} position",
                        i + 1, points[i].Name, points[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("empty ranking!\n");
            }
        }

        private static void YourTurn(char[,] field,
            char[,] bombs, int row, int col)
        {
            char howManyBombs = HowManyBombs(bombs, row, col);
            bombs[row, col] = howManyBombs;
            field[row, col] = howManyBombs;
        }

        private static void DrawField(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] createField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] setBombs()
        {
            int rows = 5;
            int cols = 10;
            char[,] pleyField = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    pleyField[i, j] = '-';
                }
            }

            List<int> rlistOfIntegers = new List<int>();
            while (rlistOfIntegers.Count < 15)
            {
                Random random = new Random();
                int randomNumber = random.Next(50);
                if (!rlistOfIntegers.Contains(randomNumber))
                {
                    rlistOfIntegers.Add(randomNumber);
                }
            }

            foreach (int number in rlistOfIntegers)
            {
                int kol = (number / cols);
                int red = (number % cols);
                if (red == 0 && number != 0)
                {
                    kol--;
                    red = cols;
                }
                else
                {
                    red++;
                }

                pleyField[kol, red - 1] = '*';
            }

            return pleyField;
        }

        private static void Calculations(char[,] pole)
        {
            int col = pole.GetLength(0);
            int row = pole.GetLength(1);

            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (pole[i, j] != '*')
                    {
                        char howMany = HowManyBombs(pole, i, j);
                        pole[i, j] = howMany;
                    }
                }
            }
        }

        private static char HowManyBombs(char[,] field, int rows, int cols)
        {
            int bombsCount = 0;
            int row = field.GetLength(0);
            int col = field.GetLength(1);

            if (rows - 1 >= 0)
            {
                if (field[rows - 1, cols] == '*')
                {
                    bombsCount++;
                }
            }

            if (rows + 1 < row)
            {
                if (field[rows + 1, cols] == '*')
                {
                    bombsCount++;
                }
            }

            if (cols - 1 >= 0)
            {
                if (field[rows, cols - 1] == '*')
                {
                    bombsCount++;
                }
            }

            if (cols + 1 < col)
            {
                if (field[rows, cols + 1] == '*')
                {
                    bombsCount++;
                }
            }

            if ((rows - 1 >= 0) && (cols - 1 >= 0))
            {
                if (field[rows - 1, cols - 1] == '*')
                {
                    bombsCount++;
                }
            }

            if ((rows - 1 >= 0) && (cols + 1 < col))
            {
                if (field[rows - 1, cols + 1] == '*')
                {
                    bombsCount++;
                }
            }

            if ((rows + 1 < row) && (cols - 1 >= 0))
            {
                if (field[rows + 1, cols - 1] == '*')
                {
                    bombsCount++;
                }
            }

            if ((rows + 1 < row) && (cols + 1 < col))
            {
                if (field[rows + 1, cols + 1] == '*')
                {
                    bombsCount++;
                }
            }

            return char.Parse(bombsCount.ToString());
        }
    }
}
