using System;

// Console.Write("What is the magic number? ");
Random generateRamdom = new();

int magicNumber = generateRamdom.Next(1, 100);


int guess = -1; // Initialize guess


while (guess != magicNumber)
{
    Console.Write("What is your guess? ");
    guess = int.Parse(Console.ReadLine());
    if (magicNumber > guess)
    {
        Console.WriteLine("Try higher number");
    }
    else if (magicNumber < guess)
    {
        Console.WriteLine("Try lower number");
    }
    else
    {
        Console.WriteLine("Congratulations! You guessed it!");
    }
}
