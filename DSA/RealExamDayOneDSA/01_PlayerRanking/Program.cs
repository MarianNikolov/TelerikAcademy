using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _01_PlayerRanking
{
    public class Player : IComparable<Player>
    {
        

        public string Name { get; set; }
        public string Type { get; set; }
        public int Age { get; set; }
        public int Position { get; set; }

        public int CompareTo(Player other)
        {
            //first ordered by name in ascending order and then by age in descending order
            var result = this.Name.CompareTo(other.Name);

            if (result == 0)
            {
                result = other.Age.CompareTo(this.Age);
            }

            return result;
        }
    }

    public class Program
    {
        public static OrderedDictionary<int, Player> ranking = new OrderedDictionary<int, Player>();
        public static Dictionary<string, HashSet<Player>> types = new Dictionary<string, HashSet<Player>>();

        public static StringBuilder result = new StringBuilder();

        public static void Main()
        {
            

            while (true)
            {
                var line = Console.ReadLine();
                line.Trim();

                // END
                if (line == "end")
                {
                    break;
                }

                var currentLine = line.Split(' ');
                var currentCommand = currentLine[0];

                // Add
                if (currentCommand == "add")
                {
                    var name = currentLine[1];
                    var type = currentLine[2];
                    var age = int.Parse(currentLine[3]);
                    var position = int.Parse(currentLine[4]);

                    var currentPlayer = new Player
                    {
                        Name = name,
                        Type = type,
                        Age = age,
                        Position = position
                    };


                    //// TYPES
                    //if (!types.ContainsKey(type))
                    //{
                    //    types.Add(type, new HashSet<Player>());
                    //}

                    //types[type].Add(currentPlayer);


                    if (currentPlayer.Position <= ranking.Count)
                    {
                        for (int i = ranking.Count; i >= currentPlayer.Position; i--)
                        {
                            var tempPlayer = ranking[i];
                            ranking.Remove(tempPlayer.Position);
                            tempPlayer.Position++;
                            ranking.Add(tempPlayer.Position, tempPlayer);

                        }
                    }

                    ranking.Add(currentPlayer.Position, currentPlayer);
                    result.AppendLine(string.Format("Added player {0} to position {1}", currentPlayer.Name, currentPlayer.Position));

                    continue;
                }

                // Ranklist
                if (currentCommand == "ranklist")
                {
                    var start = int.Parse(currentLine[1]);
                    var end = int.Parse(currentLine[2]);

                    //if (start > ranking.Count - 1 || start < ranking.Count || end < ranking.Count - 1 || start < ranking.Count)
                    //{
                    //    if (ranking.Count == 0)
                    //    {
                    //        start = 0;
                    //        end = 0;
                    //    }
                    //}

                    var players = ranking.Range(start, true, end, true);

                    var currentResult = new List<string>();
                    var pos = 1;

                    foreach (var player in players)
                    {
                        currentResult.Add(string.Format("{0}. {1}({2})", player.Value.Position, player.Value.Name, player.Value.Age));
                        pos++;
                    }

                    result.AppendLine(string.Join("; ", currentResult));
                }

                // Find
                if (currentCommand == "find")
                {
                    var currentType = currentLine[1];
                    var topFive = new List<Player>();
                    var currentResult = new List<string>();

                    var currentall = types[currentType].OrderBy(o => o.Position).ToList();

                    foreach (var player in currentall)
                    {
                        if (topFive.Count >= 5)
                        {
                            break;
                        }
                        if (player.Type == currentType)
                        {
                            // ; Stamat(40); Stamat(22)
                            topFive.Add(player);
                        }
                    }

                    topFive = topFive.OrderBy(o => o.Position).ToList();

                    foreach (var player in topFive)
                    {
                        currentResult.Add(string.Format("{0}({1})", player.Name, player.Age));
                    }

                    string arrayRes = string.Join("; ", currentResult);

                    string res; 
                    if (currentResult.Count == 0)
                    {
                        res = string.Format("Type {0}: ", currentType);
                    }
                    else
                    {
                        res = string.Format("Type {0}: ", currentType) + arrayRes;
                    }

                    result.AppendLine(res);
               }
            }

            Console.WriteLine(result.ToString().Trim());
        }
    }
}
