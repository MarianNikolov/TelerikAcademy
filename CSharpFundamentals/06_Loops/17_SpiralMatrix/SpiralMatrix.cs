using System;

class SpiralMatrix
{
    static void Main()
    {

        int n = int.Parse(Console.ReadLine());
        int[,] array = new int[n, n];
        int currentRow = 0;
        int currentCol = 0;
        
        string direction = "right";
        
        
        for (int i = 0; i < n * n; i++)
        {
            switch (direction)
            {
                case "right":

                    if (currentCol == n || array[currentRow, currentCol] != 0)
                    {
                        direction = "down";
                        currentCol--;
                        currentRow++;
                        if (i < n * n - 1)
                        {
                            i--;
                        }
                        else
                        {
                            array[currentRow, currentCol] = i + 1;
                        }
                    }
                    
                    else
                    {
                        array[currentRow, currentCol] = i + 1;
                        currentCol++;
                    }
                    break;
                case "down":
                    if (currentRow == n || array[currentRow, currentCol] != 0)
                    {
                        direction = "left";
                        currentCol--;
                        currentRow--;
                        if (i < n * n - 1)
                        {
                            i--;
                        }
                        else
                        {
                            array[currentRow, currentCol] = i + 1;
                        }
                    }
                    else
                    {
                        array[currentRow, currentCol] = i + 1;
                        currentRow++;
                    }
                    break;
                case "left":
                    
                    if (currentCol < 0 || array[currentRow, currentCol] != 0)
                    {
                        direction = "up";
                        currentRow--;
                        currentCol++;
                        if (i < n * n - 1)
                        {
                            i--;
                        }
                        else
                        {
                            array[currentRow, currentCol] = i + 1;
                        }
                    }
                    
                    else
                    {
                        array[currentRow, currentCol] = i + 1;
                        currentCol--;
                    }
                    break;
                
                case "up":
                    if (currentRow < 1 || array[currentRow, currentCol] != 0)
                    {
                        direction = "right";
                        currentCol++;
                        currentRow++;
                        if (i < n * n - 1)
                        {
                            i--;
                        }
                        else
                        {
                            array[currentRow, currentCol] = i + 1;
                        }
                    }
                    
                    else
                    {
                        array[currentRow, currentCol] = i + 1;
                        currentRow--;
                    }
                    break;
            }
        }

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                Console.Write(array[row, col].ToString() + " ");
            }
            Console.WriteLine();
        }



    }
}

