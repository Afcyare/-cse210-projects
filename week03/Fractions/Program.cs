using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction1 = new Fraction();
        System.Console.WriteLine(fraction1.GetFractionString());
        System.Console.WriteLine(fraction1.GetDecimalValue());

        Fraction fraction2 = new Fraction(5);
        System.Console.WriteLine(fraction2.GetFractionString());
        System.Console.WriteLine(fraction2.GetDecimalValue());

        Fraction fraction3 = new Fraction(3, 4);
        System.Console.WriteLine(fraction3.GetFractionString());
        System.Console.WriteLine(fraction3.GetDecimalValue());

        Fraction fraction4 = new Fraction(1, 3);
        System.Console.WriteLine(fraction4.GetFractionString());
        System.Console.WriteLine(fraction4.GetDecimalValue());
    }
}