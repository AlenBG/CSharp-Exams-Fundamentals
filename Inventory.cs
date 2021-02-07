using System;
using System.Collections.Generic;
using System.Linq;

namespace ex_3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string word = Console.ReadLine();
            while(word != "Craft!")
            {
                string[] command = word.Split(' ', ':');
                if(command[0] == "Collect")
                {
                    int counter = 0;
                    for (int i = 0; i < items.Count; i++)
                    {
                        if (items[i] == command[2])
                        {
                            counter++;
                        }
                        if(counter == 0)
                        {
                            items.Add(command[2]);
                            break;
                        }
                    }
                }
                else if (command[0] == "Drop")
                {
                    int counter = 0;
                    for (int i = 0; i < items.Count; i++)
                    {
                        if (items[i] == command[2])
                        {
                            counter++;
                        }
                        if (counter > 0)
                        {
                            items.Remove(command[2]);
                        }
                    }
                }
                else if (command[0] == "Combine")
                {
                    for (int i = 0; i < items.Count; i++)
                    {
                        if (items[i] == command[3])
                        {
                            items.Insert(i + 1, command[4]);
                        }
                    }
                    
                }
                else if (command[0] == "Renew")
                {
                    string item = command[2];
                    int counter = 0;
                    for (int i = 0; i < items.Count; i++)
                    {
                        if (command[2] == items[i])
                        {
                            counter++;
                        }
                        if (counter > 0)
                        {
                            items.Remove(command[2]);
                            items.Add(item);
                            break;
                        }
                    }
                }
                word = Console.ReadLine();
            }
            Console.WriteLine(String.Join(", ", items));
        }
    }
}
