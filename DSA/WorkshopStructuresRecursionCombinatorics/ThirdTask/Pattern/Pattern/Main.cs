using System;
using System.Text;

namespace Pattern
{
    public class MainClass
    {
        public static void Main()
        {
            StringBuilder currentFigure = new StringBuilder();
            currentFigure.Append("urd");

            var input = int.Parse(Console.ReadLine());

            for (int i = 1; i < input ; i++)
            {
                StringBuilder leftRotated = RotateLeft(currentFigure);
                StringBuilder rightRoteted = RotateRight(currentFigure);

                StringBuilder currentResult = currentFigure;
                currentFigure = new StringBuilder();
                currentFigure.Append(leftRotated.ToString());
                currentFigure.Append("u");
                currentFigure.Append(currentResult.ToString());
                currentFigure.Append("r");
                currentFigure.Append(currentResult.ToString());
                currentFigure.Append("d");
                currentFigure.Append(rightRoteted.ToString());
            }

            Console.WriteLine(currentFigure.ToString());

            // comment before submitting
            //Svg.WriteToFile("output.svg", currentFigure.ToString());
        }

        private static StringBuilder RotateLeft(StringBuilder currentFigure)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < currentFigure.Length; i++)
            {
                switch (currentFigure[i])
                {
                    case 'r':
                        result.Append("u"); break;
                    case 'u':                           // r = u
                        result.Append("r"); break;      // u = r
                    case 'l':                           // l = d
                        result.Append("d"); break;      // d = l
                    case 'd':                           //
                        result.Append("l"); break;      //
                    default:
                        throw new ArgumentException("aaaaaaaaaaaaa");
                        break;
                }
            }

            return result;
        }

        private static StringBuilder RotateRight(StringBuilder currentFigure)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < currentFigure.Length; i++)
            {
                switch (currentFigure[i])
                {
                    case 'r':
                        result.Append("d"); break;      // r = d
                    case 'u':                           // u = l
                        result.Append("l"); break;      // l = u
                    case 'l':                           // d = r
                        result.Append("u"); break;      // 
                    case 'd':                           // 
                        result.Append("r"); break;      // 
                    default:
                        throw new ArgumentException("aaaaaaaaaaaaa");
                        break;
                }
            }

            return result;
        }

    }
}

// 1 urd

// 2 rul-u-urd-r-urd-d-ldr 

// 3 urd-r-rul-u-rul-l-dlu u    - 2
//   rul-u-urd-r-urd-d-ldr r    - 1
//   rul-u-urd-r-urd-d-ldr d 
//   dlu-l-ldr-d-ldr-r-urd

// 4 rul-u-urd-r-urd-d-ldr r
//   urd-r-rul-u-rul-l-dlu u
//   urd-r-rul-u-rul-l-dlu u


// NOtes 

// first figure  four figure

// r = u        r = d 
// u = r        u = l
// l = d        l = u
// d = l        d = r

// rul-u-urd-r-urd-d-ldr --> 2 rotate to left  
// urdrrulurulldluuruluurdrurddldrrruluurdrurddldrddlulldrdldrrurd
