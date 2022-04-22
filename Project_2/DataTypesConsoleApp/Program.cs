using DataTypesLibrary;

namespace DataTypesConsoleApp;

internal static class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        try
        {
            Bmi();
            GarbageCollector();

            People();
            GarbageCollector();

            Array();
            GarbageCollector();

            TextLength();
            GarbageCollector();
        }
        catch (ArgumentException exc)
        {
            Console.WriteLine(exc.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    /// <summary>
    /// Reads user input and outputs the BMI result.
    /// </summary>
    private static void Bmi()
    {
        Console.WriteLine("Enter the weight (in kg.): ");
        var textWeight = double.Parse(Console.ReadLine() ?? string.Empty);
        Console.WriteLine("Enter the height (in cm.): ");
        var textHeight = double.Parse(Console.ReadLine() ?? string.Empty);
        var bmi = BodyMassIndex.CalculateMassIndex(textWeight, textHeight);
        Console.WriteLine($"The BMI result is: {bmi}.\n" +
                          BodyMassIndex.DescriptionResultBmi(bmi));
    }

    /// <summary>
    /// Reads user input and outputs information about the person.
    /// </summary>
    private static void People()
    {
        Console.WriteLine("Enter your name: ");
        var name = Console.ReadLine();
        Console.WriteLine("Enter your age: ");
        var age = ParseNumber();
        var people = new User(name, age);
        people.PrintInformation();
    }

    /// <summary>
    /// Reads user input and outputs an array, the maximum and minimum element in the array.
    /// </summary>
    private static void Array()
    {
        Console.WriteLine("Enter the length of the array: ");
        var length = ParseNumber();
        Console.WriteLine("Enter the minimum element in the array: ");
        var min = ParseNumber();
        Console.WriteLine("Enter the maximum element in the array: ");
        var max = ParseNumber();
        CreatingArray.GenerateRandomElements(length, min, max);
        CreatingArray.Sort();
        CreatingArray.Print();
    }

    /// <summary>
    /// Reads the entered string and outputs the average length.
    /// </summary>
    private static void TextLength()
    {
        Console.WriteLine("Enter the line: ");
        var text = Console.ReadLine();
        Console.WriteLine("The average length of a word in a line is: " +
                          $"{AverageWordLength.GetMediumWord(text)}");
    }

    /// <summary>
    /// Information about the occupied memory before and after GC cleanup.
    /// </summary>
    private static void GarbageCollector()
    {
        Console.WriteLine("\nMemory size before garbage collection: " +
                          $"{GC.GetTotalMemory(false)}");

        GC.Collect();

        Console.WriteLine("Memory size after garbage collection: " +
                          $"{GC.GetTotalMemory(false)}\n");
    }

    /// <summary>
    /// Converting a number from string to int.
    /// </summary>
    /// <returns></returns>
    private static int ParseNumber()
    {
        var output = 0;
        while (true)
        {
            var value = Console.ReadLine();
            if (int.TryParse(value, out output))
            {
                break;
            }
        }

        return output;
    }
}