using System;
using System.Xml;

namespace ex_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
            int health = 100;
            int bitcoin = 0;
            for (int i = 0; i < array.Length; i++)
            {
                string[] command = array[i].Split();
                int num = int.Parse(command[1]);
                if (command[0] == "potion")
                {
                    
                    if (num + health > 100)
                    {
                        Console.WriteLine($"You healed for {num - ((health + num) - 100)} hp.");
                        Console.WriteLine("Current health: 100 hp.");
                        health = 100;
                    }
                    else
                    {
                        health += num; 
                        Console.WriteLine($"You healed for {num} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                    }
                }
                else if (command[0] == "chest")
                {
                    bitcoin += num;
                    Console.WriteLine($"You found {num} bitcoins.");
                }
                else
                {
                    health -= num;
                    if(health > 0)
                    {
                        Console.WriteLine($"You slayed {command[0]}.");
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {command[0]}.");
                        Console.WriteLine($"Best room: {i + 1}");
                        return;
                    }
                }
            }
            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoin}");
            Console.WriteLine($"Health: {health}");
        }
    }
}
