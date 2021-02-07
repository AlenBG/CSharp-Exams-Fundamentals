using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.RegularExpressions;

namespace final_exam_prep1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"([:*])(\1)(?<word>[A-Z][a-z]{2,})(\1)(\1)";
            int threshold = 1;
            MatchCollection matches = Regex.Matches(input, pattern);

            for (int i = 0; i < input.Length; i++)
            {
                if((int)input[i] >= 48 && (int)input[i] <= 57)
                {
                    string num = input[i].ToString();
                    int n = int.Parse(num);
                    threshold *= n;
                }
            }
            Console.WriteLine($"Cool threshold: {threshold}");
            Console.WriteLine($"{matches.Count} emojis found in the text. The cool ones are:");
            foreach (Match word in matches)
            {
                var word1 = word.Groups["word"].Value;
                int sum = 0;
                for (int i = 0; i < word1.Length; i++)
                {
                    sum += (int)word1[i];
                }
                if(sum > threshold)
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}
