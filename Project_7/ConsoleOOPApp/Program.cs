namespace ConsoleOOPApp;

internal static class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        try
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            UsingRound();

            User();
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

    #region Testing the created classes.

    /// <summary>
    /// Testing the Round class.
    /// </summary>
    private static void UsingRound()
    {
        try
        {
            Console.WriteLine("Enter the coordinates of the center:");

            var round = new Round(
                center: new Coordinate
                {
                    X = ParseDouble(),
                    Y = ParseDouble()
                },
                radius: ParseDouble());

            Console.WriteLine(round);
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
    /// Testing the Employee class.
    /// </summary>
    private static void User()
    {
        try
        {
            Console.WriteLine("Enter the employee's name: ");
            var name = Console.ReadLine();

            Console.WriteLine("Enter the employee's last name: ");
            var surname = Console.ReadLine();

            Console.WriteLine("Enter the employee's patronymic: ");
            var patronymic = Console.ReadLine();

            Console.WriteLine("Enter the employee's date of birth: ");
            var birthday = ParseDate();

            Console.WriteLine("Enter the employee's age: ");
            var age = ParseInt();

            Console.WriteLine("Enter the employee's work experience: ");
            var workExperience = ParseDouble();

            Console.WriteLine("Enter the employee's position: ");
            var post = Console.ReadLine();

            var worker = new Employee(name,
                    surname,
                    patronymic,
                    birthday,
                    age,
                    workExperience,
                    post);

            Console.WriteLine(worker.ToString());
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

    #endregion

    #region Methods for converting a string to Int, Double, DateTime.

    /// <summary>
    /// Converts a number from a user input to a Double type.
    /// </summary>
    /// <returns> Returns a floating-point number. </returns>
    private static double ParseDouble()
    {
        var output = 0.0;
        while (true)
        {
            Console.WriteLine("Enter a floating point number:");
            var value = Console.ReadLine();
            if (double.TryParse(value, out output))
            {
                break;
            }
        }

        return output;
    }

    /// <summary>
    /// Converting a number to Int.
    /// </summary>
    /// <returns> Returns an integer. </returns>
    private static int ParseInt()
    {
        var output = 0;
        while (true)
        {
            Console.WriteLine("Enter an integer:");
            var value = Console.ReadLine();
            if (int.TryParse(value, out output))
            {
                break;
            }
        }

        return output;
    }

    /// <summary>
    /// Translating a line to a date.
    /// </summary>
    /// <returns> Returns the date. </returns>
    private static DateTime ParseDate()
    {
        DateTime output;
        while (true)
        {
            Console.WriteLine("Enter the date: ");
            var value = Console.ReadLine();
            if (DateTime.TryParse(value, out output))
            {
                break;
            }
        }

        return output;
    }

    #endregion
}