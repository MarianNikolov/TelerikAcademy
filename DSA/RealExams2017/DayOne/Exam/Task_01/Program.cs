using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_01
{
    class Program
    {
        static void Main()
        {
            //var input = Console.ReadLine()
            //    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .ToList();

            ////var n = int.Parse(Console.ReadLine()).Split().Select;


            //for (int i = 0; i < input[0]; i++)
            //{
            //    Console.ReadLine();
            //}

            //Console.WriteLine(-1);


            var set = new SortedSet<int>();
            set.Add(5);
            set.Add(3);
            set.Add(1);
            set.Add(8);



            var a = set.ElementAt(set.Count - 1);
            var d = set.ElementAt(0);
            var s = set.ElementAt(1);
        }
    }
}



    //class Startup
    //{
    //    static void Main()
    //    {
    //        Ranklist ranklist = new Ranklist();
    //        StringBuilder result = new StringBuilder();

    //        string input = Console.ReadLine();
    //        Command command = Command.Parse(input);

    //        while (command.Name != "end")
    //        {
    //            switch (command.Name)
    //            {
    //                case "":
    //                    Player currentPlayer = Player.Parse(command.Parameters);
                        
    //                    result.AppendLine(string.Format(""));
    //                    break;

    //                case "":


    //                    result.AppendLine(string.Format(""));
    //                    break;

    //                case "":


    //                    result.AppendLine(string.Format(""));
    //                    break;
    //            }

    //            input = Console.ReadLine();
    //            command = Command.Parse(input);
    //        }

    //        Console.WriteLine(result.ToString().Trim());
    //    }
    //}

    //public class Ranklist
    //{
    //    private readonly BigList<Player> ranklist;
    //    private readonly IDictionary<string, SortedSet<Player>> playersByType;

    //    public Ranklist()
    //    {
    //        this.ranklist = new BigList<Player>();
    //        this.playersByType = new Dictionary<string, SortedSet<Player>>();
    //    }

        
    //}

    //public class Player : IComparable<Player>
    //{
    //    public string Name { get; set; }
    //    public string Type { get; set; }
    //    public int Age { get; set; }
    //    public int Position { get; set; }

    //    public static Player Parse(IList<string> splitedInput)
    //    {
    //        return new Player
    //        {
    //            Name = splitedInput[0],
    //            Type = splitedInput[1],
    //            Age = int.Parse(splitedInput[2]),
    //            Position = int.Parse(splitedInput[3])
    //        };
    //    }

    //    public int CompareTo(Player other)
    //    {
    //        int result = this.Name.CompareTo(other.Name);

    //        if (result == 0)
    //        {
    //            result = other.Age.CompareTo(this.Age);
    //        }

    //        return result;
    //    }

    //    public override string ToString()
    //    {
    //        return string.Format("{0}({1})", this.Name, this.Age);
    //    }
    //}

    //public class Command
    //{
    //    public string Name { get; private set; }

    //    public IList<string> Parameters { get; private set; }

    //    public static Command Parse(string input)
    //    {
    //        string[] splitedInput = input.Split(' ');

    //        var splitedInputParameters = new List<string>();
    //        for (int i = 1; i < splitedInput.Length; i++)
    //        {
    //            splitedInputParameters.Add(splitedInput[i]);
    //        }

    //        return new Command
    //        {
    //            Name = splitedInput[0],
    //            Parameters = splitedInputParameters
    //        };
    //    }
    //}
