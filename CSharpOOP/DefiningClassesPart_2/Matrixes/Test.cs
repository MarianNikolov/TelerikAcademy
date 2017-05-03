namespace Matrixes
{
    using Models;
    using System;

    public class Test
    {

        static void Main()
        {
            // Problem 8. Matrix 
            // and
            // Problem 9. Matrix indexer
            int row = 3;
            var col = 3;
            var matrix1 = new Matrix<int>(row, col);

            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    matrix1[r, c] = r + c + 2;
                }
            }

            row = 3;
            col = 3;
            var matrix2 = new Matrix<int>(row, col);

            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    matrix2[r, c] = r + c;
                }
            }

            Console.WriteLine(matrix1);
            Console.WriteLine(matrix2);
            Console.WriteLine();

            // Problem 10. Matrix operations
            Console.WriteLine(matrix1 + matrix2);
            Console.WriteLine(matrix1 - matrix2);
            // Console.WriteLine(matrix1 * matrix2);

            if (matrix2)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
            Console.WriteLine();


            // Problem 11. Version attribute
            Type type = typeof(Matrix<int>);
            object[] attr = type.GetCustomAttributes(false);
            foreach (var item in attr)
            {
                Console.WriteLine(item);
            }

        }
    }
}
