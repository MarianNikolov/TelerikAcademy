using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace PlayerRanking
{
    public class Startup
    {
        static void Main()
        {
            Ranklist ranklist = new Ranklist();
            StringBuilder result = new StringBuilder();

            string input = Console.ReadLine();
            Command command = Command.Parse(input);

            while (command.Name != "end")
            {
                switch (command.Name)
                {
                    case "add":
                        Player currentPlayer = Player.Parse(command.Parameters);
                        ranklist.AddPlayer(currentPlayer);
                        result.AppendLine(string.Format("Added player {0} to position {1}", currentPlayer.Name, currentPlayer.Position));
                        break;

                    case "find":
                        string type = command.Parameters[0];
                        IEnumerable<Player> topFifePlayersByType;

                        try
                        {
                            topFifePlayersByType = ranklist.FindTopFivePlayersByType(type);
                        }
                        catch (InvalidOperationException)
                        {
                            result.AppendLine(string.Format("Type {0}: ", type));
                            break;
                        }

                        result.AppendLine(string.Format("Type {0}: {1}", type, string.Join("; ", topFifePlayersByType)));
                        break;

                    case "ranklist":
                        int startPosition = int.Parse(command.Parameters[0]);
                        int endPosition = int.Parse(command.Parameters[1]);

                        var topPlayersInRanklist = ranklist.GetRanklistOnRange(startPosition, endPosition)
                            .Select(p => new { Position = startPosition++, Player = p }).ToList();

                        result.AppendLine(string.Join("; ", topPlayersInRanklist.Select(p => string.Format("{0}. {1}", p.Position, p.Player))));
                        break;
                }

                input = Console.ReadLine();
                command = Command.Parse(input);
            }

            Console.WriteLine(result.ToString().Trim());
        }
    }

    public class Ranklist
    {
        private readonly BigList<Player> ranklist;
        private readonly IDictionary<string, SortedSet<Player>> playersByType;

        public Ranklist()
        {
            this.ranklist = new BigList<Player>();
            this.playersByType = new Dictionary<string, SortedSet<Player>>();
        }

        public void AddPlayer(Player player)
        {
            this.ranklist.Insert(player.Position - 1, player);

            if (!playersByType.ContainsKey(player.Type))
            {
                playersByType[player.Type] = new SortedSet<Player>();
            }

            playersByType[player.Type].Add(player);
        }

        public IEnumerable<Player> FindTopFivePlayersByType(string type)
        {
            if (!this.playersByType.ContainsKey(type))
            {
                throw new InvalidOperationException();
            }

            return this.playersByType[type].Take(5);
        }

        public IEnumerable<Player> GetRanklistOnRange(int startPosition, int endPosition)
        {
            return this.ranklist.GetRange(startPosition - 1, endPosition - startPosition + 1);
        }
    }

    public class Player : IComparable<Player>
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Age { get; set; }
        public int Position { get; set; }

        public static Player Parse(IList<string> splitedInput)
        {
            return new Player
            {
                Name = splitedInput[0],
                Type = splitedInput[1],
                Age = int.Parse(splitedInput[2]),
                Position = int.Parse(splitedInput[3])
            };
        }

        public int CompareTo(Player other)
        {
            int result = this.Name.CompareTo(other.Name);

            if (result == 0)
            {
                result = other.Age.CompareTo(this.Age);
            }

            return result;
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Age);
        }
    }

    public class Command
    {
        public string Name { get; private set; }

        public IList<string> Parameters { get; private set; }

        public static Command Parse(string input)
        {
            string[] splitedInput = input.Split(' ');

            var splitedInputParameters = new List<string>();
            for (int i = 1; i < splitedInput.Length; i++)
            {
                splitedInputParameters.Add(splitedInput[i]);
            }

            return new Command
            {
                Name = splitedInput[0],
                Parameters = splitedInputParameters
            };
        }
    }
}