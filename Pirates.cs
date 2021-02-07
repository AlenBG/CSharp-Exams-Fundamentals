using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace final_exam_prep1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> towns = new Dictionary<string, List<int>>();
            string input = Console.ReadLine();
            while (input != "Sail")
            {
                var command = input.Split("||");

                string name = command[0];
                int population = int.Parse(command[1]);
                int gold = int.Parse(command[2]);

                if (towns.ContainsKey(name))
                {
                    towns[name][0] += population;
                    towns[name][1] += gold;
                }
                else
                {
                    towns.Add(name, new List<int> { population, gold });
                }
                input = Console.ReadLine();
            }


            string input2 = Console.ReadLine();
            while(input2 != "End")
            {
                var command = input2.Split("=>");
                if(command[0] == "Plunder")
                {
                    string town = command[1];
                    int people = int.Parse(command[2]);
                    int gold = int.Parse(command[3]);
                    if (towns[town][0] > 0 && towns[town][1] > 0)
                    {
                        towns[town][0] -= people;
                        towns[town][1] -= gold;
                        Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");
                    }
                    if (towns[town][0] <= 0 || towns[town][1] <= 0)
                    {
                        towns.Remove(town);
                        Console.WriteLine($"{town} has been wiped off the map!");
                    }
                }
                else
                {
                    string town = command[1];
                    int gold = int.Parse(command[2]);
                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                    else
                    {
                        towns[town][1] += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {towns[town][1]} gold.");
                    }
                }
                
                input2 = Console.ReadLine();
            }
            if (towns.Count == 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {towns.Count} wealthy settlements to go to:");
                var sortedTowns = towns.OrderByDescending(x => x.Value[1]).ThenBy(key => key);
                foreach (var item in sortedTowns)
                {
                    Console.WriteLine($"{item.Key} -> Population: {item.Value[0]} citizens, Gold: {item.Value[1]} kg");
                }
            }
        }
    }
}
