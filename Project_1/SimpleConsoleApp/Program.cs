using FunctionalLibrary;

namespace SimpleConsoleApp;

internal static class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        Console.WriteLine(
            "Menu Options:\n" +
            "1. /square - Draw a square.\n" +
            "2. /number - Increase the number (from 1 to N).\n" +
            "3. /exit - Exit the program.");

        while (true)
        {
            try
            {
                var input = Console.ReadLine();
                switch (input)
                {
                    case "/square":
                        Console.WriteLine(GeometricShapes.CreateSquare(ParseNumber()));
                        break;

                    case "/number":
                        Console.WriteLine(AlgorithmicOperations.GenerateSequence(ParseNumber()));
                        break;

                    case "/exit":
                        return;

                    default:
                        Console.WriteLine($"The {input} command was not found! Try again...");
                        break;
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }

    /// <summary>
    /// Converting a number from string to int.
    /// </summary>
    /// <returns> The entered value as a number. </returns>
    static int ParseNumber()
    {
        var output = 0;
        while (true)
        {
            Console.WriteLine("Enter an integer: ");
            var value = Console.ReadLine();

            if (int.TryParse(value, out output))
            {
                break;
            }
        }

        return output;
    }
}