using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLive
{
    public class Calculator
    {
        // Addition method
        public double Add(double numberOne, double numberTwo)
        {
            return numberOne + numberTwo;
        }

        // Subtraction method
        public double Subtract(double numberOne, double numberTwo)
        {
            return numberOne - numberTwo;
        }

        // Division method
        public double Divide(double numberOne, double numberTwo)
        {
            if (numberTwo == 0)
            {
                throw new DivideByZeroException("Division by zero is not allowed.");
            }
            return numberOne / numberTwo;
        }

        // Multiplication method
        public double Multiply(double numberOne, double numberTwo)
        {
            return numberOne * numberTwo;
        }

        // Main method for testing
        public static void Main(string[] args)
        {
            Calculator calc = new Calculator();

            Console.WriteLine("Addition: " + calc.Add(10, 5));
            Console.WriteLine("Subtraction: " + calc.Subtract(10, 5));
            Console.WriteLine("Multiplication: " + calc.Multiply(10, 5));

            try
            {
                Console.WriteLine("Division: " + calc.Divide(10, 5));
                Console.WriteLine("Division by zero: " + calc.Divide(10, 0));
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
