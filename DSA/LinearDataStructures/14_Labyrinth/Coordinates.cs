﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_Labyrinth
{
    public class Coordinates
    {
        public int Row { get; set; }

        public int Col { get; set; }

        public Coordinates(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }
    }
}
