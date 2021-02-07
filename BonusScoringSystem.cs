using System;

namespace Mid_exam_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double countStudents = double.Parse(Console.ReadLine());
            double countLectures = double.Parse(Console.ReadLine());
            double initialBonus = double.Parse(Console.ReadLine());
            double sum = 0;
            for (int i = 0; i < countStudents; i++)
            {
                double num = double.Parse(Console.ReadLine());
                if(num > sum)
                {
                    sum = num;
                }
            }
            double maxBonusPoints = Math.Ceiling((sum *1.0 / countLectures) * (5 + initialBonus));
            Console.WriteLine($"Max Bonus: {maxBonusPoints}.");
            Console.WriteLine($"The student has attended {sum} lectures.");
        }
    }
}
