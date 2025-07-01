using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        String userName = PromptUserName();
        int userNumber = PromptUserNumber();

        int SquaredNumber = SquareNumber(userNumber);

        DisplayResult(userName, SquaredNumber);
    }


    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static String PromptUserName()
    {
        Console.Write("Please enter your name: ");
        String name = Console.ReadLine();

        return name;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());

        return number;
    }

    static int SquareNumber(int number)
    {
        int square = number * number;

        return square;
    }

    static void DisplayResult(String name, int square)
    {
         Console.WriteLine($"{name}, the square of your number is {square}");
    }
}