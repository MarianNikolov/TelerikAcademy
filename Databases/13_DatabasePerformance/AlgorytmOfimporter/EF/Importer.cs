using System;
using System.Collections.Generic;
using System.Text;
namespace EF
{
    public static class Importer
    {
        private const int CountOrEntries = 10000000;
        private const string loadingStupedShits = "┐┘└┌";
        private static Random Random = new Random();
        private static PerformanceEntities connection = new PerformanceEntities();
        private static ICollection<TestTable> testingdata = new HashSet<TestTable>();
        private static string latinAlphaBet = "abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static void Genereatedata()
        {
             Point[] points = new Point[] 
             {
                 new Point { Left = 1, Top = 0 },
                 new Point { Left = 1, Top = 1 },
                 new Point { Left = 0, Top = 1 },
                 new Point { Left = 0, Top = 0 } 
             }; 

            connection.Configuration.AutoDetectChangesEnabled = false;
            connection.Configuration.ProxyCreationEnabled = false;
            connection.Configuration.ValidateOnSaveEnabled = false;
            Console.CursorVisible = false;
            
            using (connection)
            {
                int indexOfLoadShit = 0;
                bool isCleaning = false;
                int indexForCleaning = 0;
                
                TestTable tester;
                for (int i = 0; i < CountOrEntries; i++)
                {
                    tester = new TestTable
                    {
                        BirthDay = GenerateDate(),
                        Content = GenerateText((i % 90) + 10)
                    };
                    testingdata.Add(tester);

                    if (i % 2500 == 0)
                    {
                        var point = points[indexOfLoadShit];
                        Console.SetCursorPosition(point.Left, point.Top);
                        
                        if (isCleaning)
                        {
                            Console.Write(" ");
                        }
                        else
                        {
                            Console.Write(loadingStupedShits[indexOfLoadShit]);
                        }

                        indexOfLoadShit++;
                        indexForCleaning++; 
                        indexOfLoadShit = indexOfLoadShit == loadingStupedShits.Length ? 0 : indexOfLoadShit;
                        isCleaning = indexForCleaning % 4 == 0 ? !isCleaning : isCleaning;

                        connection.TestTables.AddRange(testingdata);
                        testingdata.Clear();
                        connection.SaveChanges();
                        connection.Dispose();
                        connection = new PerformanceEntities();
                    }
                }

                connection.TestTables.AddRange(testingdata);
                connection.SaveChanges();
                Console.WriteLine("\ntest data Added");
            }
        }

        private static DateTime GenerateDate()
        {
            int year = Random.Next(1997, 2020);
            int month = Random.Next(1, 13);
            int day = Random.Next(1, 28);
            int hour = Random.Next(1, 23);
            int minute = Random.Next(1, 59);
            int second = Random.Next(1, 59);
            return new DateTime(
                year,
                month,
                day,
                hour,
                minute,
                second);
        }

        private static string GenerateText(int length)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                int index = Random.Next(0, latinAlphaBet.Length);
                sb.Append(latinAlphaBet[index]);
            }

            return sb.ToString();
        }
    }
}
