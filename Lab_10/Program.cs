using System;
using System.Reflection.Metadata.Ecma335;

namespace Lab_10
{
    class Program
    {
        static void Main(string[] args)
        {
            int acc = 0;
            bool isLooping = true;

            do
            {
                acc++;

                Console.WriteLine($"Welcome to Circle Time! - the Circle Cirumference and Area Calculator\n");
                Console.Write($"Please Enter a Radius: ");
                var userInput = Console.ReadLine();
                double radius = Validator.TryParseValidator(userInput);

                var Circle = new Circle();
                Circle.Radius = radius;

                Console.WriteLine($"The Circumference of the Circle is: {Circle.CalculateFormattedCircumference()}");
                Console.WriteLine($"The Area of the Circle is: {Circle.CalculateFormattedArea()}");
                Console.WriteLine();
                Console.Write($"Would you like to calculate another? (y/n): ");
                do
                {
                    userInput = Console.ReadLine();
                    if (userInput == "y")
                    {
                        Console.Clear();
                        break;
                    }
                    else if (userInput == "n")
                    {
                        Console.WriteLine($"You Calculated a Total of {acc} Circle(s). Goodbye!");
                        isLooping = false;
                        break;
                    }
                    else
                    {
                        Console.Write($"Invalid Input. Please Try Again (y/n): ");
                    }
                } while (true);
            } while (isLooping);
        }
    }

    public class Circle
    {
        private double _radius;
        
        public double Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value;
            }
        }


        public double CalculateCircumference() => 2 * Radius * Math.PI;

        public string CalculateFormattedCircumference() => String.Format("{0:0.00}", CalculateCircumference());

        public double CalculateArea() => Math.PI * Math.Pow(Radius, 2);

        public string CalculateFormattedArea() => String.Format("{0:0.00}", CalculateArea());

        private string FormatNumber(double x)
        {
            return "because you said so";
        }
    }
    public class Validator
    {
        public static double TryParseValidator(string userInput)
        {
            do
            {
                if (double.TryParse(userInput, out double number))
                {
                    return number;
                    break;
                }
                else
                {
                    Console.Write($"Invalid Input. Please Try Again: ");
                    userInput = Console.ReadLine();
                }
            } while (true);
        }
    }
}
