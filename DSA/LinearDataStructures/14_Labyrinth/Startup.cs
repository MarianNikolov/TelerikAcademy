using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace _14_Labyrinth
{
    // 14. (*) We are given a labyrinth of size N x N.
    // Some of its cells are empty (0) and some are full(x).
    // We can move from an empty cell to another empty cell if they share common wall.
    // Given a starting position (*) 
    // calculate and fill in the array the minimal distance from this position 
    // to any other cell in the array. Use "u" for all unreachable cells.
    // Example: https://github.com/TelerikAcademy/Data-Structures-and-Algorithms/blob/master/Topics/02.%20Linear-Data-Structures/homework/imgs/matrices.png

    public static class Startup
    {
        private const int StartCellValue = -2;
        private const int WallCellValue = -1;
        private const int EmptyCellValue = 0;

        static void Main()
        {
            // MATRIX for test
            // to copy only matrix without '/' press and hold Alt button and select matrix whit the mouse!

            //    6
            //    0 0 0 x 0 x
            //    0 x 0 x 0 x
            //    0 * x 0 x 0
            //    0 x 0 0 0 0
            //    0 0 0 x x 0
            //    0 0 0 x 0 x 

            Console.WriteLine("Copy matrix from Main() method");

            Maze maze = ReadMatrix();

            FillMazeWithPaths(maze, maze.StartingCell.Row, maze.StartingCell.Col, 1);

            Console.WriteLine(maze);
        }

        private static void FillMazeWithPaths(Maze maze, int row, int col, int step)
        {
            if (!IsInRange(row, col, maze.Rows, maze.Cols))
            {
                return;
            }

            if (maze[row, col] == WallCellValue)
            {
                return;
            }

            if (maze[row, col] != StartCellValue && maze[row, col] != EmptyCellValue && step > maze[row, col])
            {
                return;
            }

            maze[row, col] = step;

            FillMazeWithPaths(maze, row - 1, col, step + 1);
            FillMazeWithPaths(maze, row + 1, col, step + 1);
            FillMazeWithPaths(maze, row, col - 1, step + 1);
            FillMazeWithPaths(maze, row, col + 1, step + 1);
        }

        private static bool IsInRange(int row, int col, int mazeRows, int mazeCols)
        {
            var inRowRange = row >= 0 && row < mazeRows;
            var inColRange = col >= 0 && col < mazeCols;

            return inRowRange && inColRange;
        }

        private static Maze ReadMatrix()
        {
            var size = ReadOne();
            var maze = new Maze(size, size) { };

            for (int row = 0; row < size; row++)
            {
                var currentRow = ReadRow();
                if (currentRow.Length != size)
                {
                    throw new ArgumentException("Invalid columns size.");
                }

                var currentCol = currentRow.Select(
                    x =>
                    {
                        switch (x)
                        {
                            case "x":
                                return -1;
                            case "0":
                                return 0;
                            case "*":
                                return -2;
                            default:
                                throw new ArgumentException("Invalid symbol.");
                        }
                    }).ToArray();

                for (int col = 0; col < size; col++)
                {
                    if (currentCol[col] == -2)
                    {
                        maze.StartingCell = new Coordinates(row, col);
                    }

                    maze[row, col] = currentCol[col];
                }
            }

            return maze;
        }

        private static int ReadOne()
        {
            return int.Parse(Console.ReadLine());
        }

        private static string[] ReadRow()
        {
            return Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        }
    }
}
