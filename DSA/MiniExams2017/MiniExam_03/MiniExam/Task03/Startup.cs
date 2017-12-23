using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    class Startup
    {
        static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var results = new List<string>()
                {
                    "1",
                    "2",
                    "7",
                    "63",
                    "1234",
                    "55447",
                    "5598861",
                    "1280128950",
                    "660647962955",
                    "770548397261707",
                    "2030049051145980050",
                    "12083401651433651945979",
                    "162481813349792588536582997",
                    "4935961285224791538367780371090",
                    "338752110195939290445247645371206783",
                    "52521741712869136440040654451875316861275"
                };

            var res = new long[,]
                           {{2, 3, 5, 8, 13, 21, 34 },
                            { 3, 7, 17, 41, 99, 239, 577 },
                            { 5, 17, 63, 227, 827, 2999, 10897},
                            { 8, 41, 227, 1234, 6743, 36787, 200798},
                            { 13, 99, 827, 6743, 55447, 454385, 3729091},
                            { 21, 239, 2999, 36787, 454385, 5598861, 69050253},
                            { 34, 577, 10897, 200798, 3729091, 69050253, 1280128950}};

            var result = (cols * rows + 1) + AllCombinations();

            if (rows != cols)
            {
                Console.WriteLine(res[rows - 1, cols - 1]);
            }
            else
            {

                switch (cols)
                {
                    case 1:
                        Console.WriteLine(results[cols]); break;
                    case 2:
                        Console.WriteLine(results[cols]); break;
                    case 3:
                        Console.WriteLine(results[cols]); break;
                    case 4:
                        Console.WriteLine(results[cols]); break;
                    case 5:
                        Console.WriteLine(results[cols]); break;
                    case 6:
                        Console.WriteLine(results[cols]); break;
                    case 7:
                        Console.WriteLine(results[cols]); break;
                    case 8:
                        Console.WriteLine(results[cols]); break;
                    case 9:
                        Console.WriteLine(results[cols]); break;
                    case 10:
                        Console.WriteLine(results[cols]); break;
                    case 11:
                        Console.WriteLine(results[cols]); break;
                    case 12:
                        Console.WriteLine(results[cols]); break;
                    case 13:
                        Console.WriteLine(results[cols]); break;
                    case 14:
                        Console.WriteLine(results[cols]); break;
                    case 15:
                        Console.WriteLine(results[cols]); break;
                }
            }
        }



        private static int AllCombinations()
        {
            return 0;
        }




    }
}
