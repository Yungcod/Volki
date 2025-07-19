using System;

class Calculator
{
    static void Main()
    {
        Console.WriteLine("+-*/ Calculator +-*/");
        
        while (true)
        {
            try
            {
                Console.Write("\nEnter first number: ");
                double num1 = Convert.ToDouble(Console.ReadLine());
                
                Console.Write("Enter operation (+, -, *, /): ");
                string operation = Console.ReadLine();
                
                Console.Write("Enter second number: ");
                double num2 = Convert.ToDouble(Console.ReadLine());
                
                double result = Calculate(num1, num2, operation);
                Console.WriteLine($"Result: {result}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Entered invalid number!");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (ArithmeticException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Undefined error: {ex.Message}");
            }
            
            Console.Write("\n Continue? (y/n): ");
            if (Console.ReadLine().ToLower() != "y")
                break;
        }
    }
    
    static double Calculate(double a, double b, string op)
    {
        if (string.IsNullOrWhiteSpace(op))
            throw new ArgumentException("Operation cannot be null or whitespace.");
            
        switch (op.Trim())
        {
            case "+":
                return a + b;
            case "-":
                return a - b;
            case "*":
                return a * b;
            case "/":
                if (b == 0)
                    throw new DivideByZeroException("Division by zero, forbidden operation!!!!");
                if (double.IsInfinity(a) || double.IsNaN(a))
                    throw new ArithmeticException("Incorrect number!");
                return a / b;
            default:
                throw new ArgumentException($"Unsupported operation '{op}'! use only: +, -, *, /");
        }
    }
}