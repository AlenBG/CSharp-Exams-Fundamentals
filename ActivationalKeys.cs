using System;
using System.Linq;

namespace final_exam_prep1
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();

            string input = Console.ReadLine();
            while(input != "Generate")
            {
                var command = input.Split(">>>").ToArray();
                if (command.Contains("Contains"))
                {
                    if (key.Contains(command[1]))
                    {
                        Console.WriteLine($"{key} contains {command[1]}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                if (command.Contains("Flip"))
                {
                    string upperOrLower = command[1];
                    int firstIndex = int.Parse(command[2]);
                    int endIndex = int.Parse(command[3]);
                    if (upperOrLower == "Upper")
                    {
                        string wordToUpper = key.Substring(firstIndex, endIndex - firstIndex).ToUpper();
                        key = key.Remove(firstIndex, endIndex - firstIndex);
                        key  = key.Insert(firstIndex, wordToUpper);
                    }
                    else
                    {
                        string wordToUpper = key.Substring(firstIndex, endIndex - firstIndex).ToLower();
                        key = key.Remove(firstIndex, endIndex - firstIndex);
                        key = key.Insert(firstIndex, wordToUpper);
                    }
                    Console.WriteLine(key);
                }
                if (command.Contains("Slice"))
                {
                    int firstIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);
                    key = key.Remove(firstIndex, endIndex - firstIndex);
                    Console.WriteLine(key);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Your activation key is: {key}");
        }
    }
}
