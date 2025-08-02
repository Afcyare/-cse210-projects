using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment1 = new Assignment("samuel Bennet", "Multiplication");
        // Console.WriteLine(assignment1.GetSummary());

        MathAssignment mathAssignment1 = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");

        // System.Console.WriteLine(mathAssignment1.GetSummary());
        // System.Console.WriteLine(mathAssignment1.GetHomeworkList());

        WritingAssignment writingAssignment = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        System.Console.WriteLine(writingAssignment.GetSummary());
        System.Console.WriteLine(writingAssignment.GetWritingInformation());
    }        
}