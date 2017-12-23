using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeganBodybuilder
{
    public class Program
    {
        static void Main()
        {
            //var maxFoodWeight = int.Parse(Console.ReadLine());
            //var n = int.Parse(Console.ReadLine());
            //var foods = new List<Food>();

            //for (int i = 0; i < n; i++)
            //{
            //    var input = Console.ReadLine().Split(' ');
            //    var food = new Food(input[0], int.Parse(input[1]), int.Parse(input[2]));
            //    foods.Add(food);
            //}

            //foods.Sort();

            //var currentWeight = 0;

            //var currentProteins = 0;
            //var maxProteins = 0;

            //var results = new List<Food>();

            //for (int i = 0; i < foods.Count; i++)
            //{
            //    if (foods[i].Weight > maxFoodWeight)
            //    {
            //        continue;
            //    }

            //    results.Add(foods[i]);
            //    currentWeight = foods[i].Weight;
            //    currentProteins = foods[i].Protein;

            //    for (int j = i + 1; j < foods.Count; j++)
            //    {
            //        if ((currentWeight + foods[j].Weight) > maxFoodWeight)
            //        {
            //            continue;
            //        }

            //        results.Add(foods[j]);
            //        currentWeight += foods[j].Weight;
            //        currentProteins += foods[j].Protein;

            //    }

            //    if (maxProteins < currentProteins)
            //    {
            //        maxProteins = currentProteins;
            //    }
            //    else
            //    {
            //        results.Clear();
            //    }

            //    currentProteins = 0;
            //    currentWeight = 0;
            //}

            //Console.WriteLine(results.Count);
            //for (int i = 0; i < results.Count; i++)
            //{
            //    Console.WriteLine(results[i].Name);
            //}
        }
    }



    class Knapsack
    {
        double bestValue;
        bool[] bestItems;
        double[] itemValues;
        double[] itemWeights;
        double weightLimit;

        void SolveRecursive(bool[] chosen, int depth, double currentWeight, double currentValue, double remainingValue)
        {
            if (currentWeight > weightLimit) return;
            if (currentValue + remainingValue < bestValue) return;
            if (depth == chosen.Length)
            {
                bestValue = currentValue;
                System.Array.Copy(chosen, bestItems, chosen.Length);
                return;
            }
            remainingValue -= itemValues[depth];
            chosen[depth] = false;
            SolveRecursive(chosen, depth + 1, currentWeight, currentValue, remainingValue);
            chosen[depth] = true;
            currentWeight += itemWeights[depth];
            currentValue += itemValues[depth];
            SolveRecursive(chosen, depth + 1, currentWeight, currentValue, remainingValue);
        }

        public bool[] Solve()
        {
            var chosen = new bool[itemWeights.Length];
            bestItems = new bool[itemWeights.Length];
            bestValue = 0.0;
            double totalValue = 0.0;
            foreach (var v in itemValues) totalValue += v;
            SolveRecursive(chosen, 0, 0.0, 0.0, totalValue);
            return bestItems;
        }
    }


    //class Food : IComparable<Food>
    //{
    //    public string Name;
    //    public int Weight;
    //    public int Protein;

    //    public Food(string name, int weight, int protein)
    //    {
    //        this.Name = name;
    //        this.Weight = weight;
    //        this.Protein = protein;
    //    }

    //    public int CompareTo(Food other)
    //    {
    //        var res = other.Weight.CompareTo(this.Weight);
    //        if (res== 0)
    //        {
    //            res = other.Protein.CompareTo(this.Protein);
    //        }

    //        return res;
    //    }
    //}
}
