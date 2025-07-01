using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter grade percentage: ");
        int grade = int.Parse(Console.ReadLine());
        String letter = "";
        String sign = "";

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";

        }
        else
        {
            letter = "F";
        }

        if (letter != "F" && grade >= 60)
        {
            int lastDigit = grade % 10;

            if (lastDigit >= 7)
            {
                sign = "+";
            }

            else if (lastDigit < 3)
            {
                sign = "-";
            }
            else
            {
                sign = "";
            }

            if (letter == "A" && grade >= 97)
            {
                sign = "";
            }
            else if (letter == "A"  && grade < 93)
            {
                sign = "-";
            }
        }

        Console.WriteLine($"Your grade is: {letter}{sign}");
         
          if (grade >= 70)
        {
            Console.WriteLine("Congratulations you passed!");
        }
        else
        {
            Console.WriteLine("Better luck next time!");
        }
    }
}