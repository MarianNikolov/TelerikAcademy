using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_Labyrinth
{
    public class Maze
    {
        private const string StartingCellSymbol = "*";
        private const string WallCellSymbol = "x";
        private const string InaccessibleCellSymbol = "u";

        private readonly int[,] maze;

        public Maze(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.maze = new int[this.Rows, this.Cols];
        }

        public int Rows { get; set; }

        public int Cols { get; set; }

        public Coordinates StartingCell { get; set; }

        public int this[int row, int col]
        {
            get
            {
                return this.maze[row, col];
            }
            set
            {
                this.maze[row, col] = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            for (int row = 0; row < this.Cols; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    var symbol = this.GetSymbol(this.maze[row, col]);

                    result.AppendFormat("{0,4}", symbol);
                }

                result.AppendLine();
            }

            return result.ToString();
        }
        
        private string GetSymbol(int symbol)
        {
            switch (symbol)
            {
                case 0:
                    return InaccessibleCellSymbol;
                case -1:
                    return WallCellSymbol;
                case 1:
                    return StartingCellSymbol;
                default:
                    return (symbol - 1).ToString();
            }
        }
    }
}
