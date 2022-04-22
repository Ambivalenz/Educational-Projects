namespace ConsoleDateApp;

internal static class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        try
        {
            var dateUtc = new DateConverter();
            var date = DateTime.UtcNow;
            Console.WriteLine($"Current date in UTC format: {date}");

            var convertDate = dateUtc.ConvertDate(date);
            Console.WriteLine($"Current date in local time format: {convertDate}");

            var input = dateUtc.ConvertDate(ParseDate());
            Console.WriteLine(input);

            ExceptionTest(int.Parse(Console.ReadLine() ?? string.Empty));
        }
        catch (Exception? ex)
        {
            GetException(ex);
        }
    }

    /// <summary>
    /// A recursive method for calling an error.
    /// </summary>
    /// <param name="ex"> Error. </param>
    private static void GetException(Exception? ex)
    {
        while (ex != null)
        {
            Console.WriteLine(ex.Message);
            ex = ex.InnerException;
        }
    }

    /// <summary>
    /// Calling a division by zero error.
    /// </summary>
    /// <param name="number"> Number. </param>
    private static void ExceptionTest(int number)
    {
        try
        {
            var getException = number / 0;
        }
        catch (DivideByZeroException ex)
        {
            throw new DivideByZeroException("It is impossible to divide by zero!", ex);
        }
    }

    /// <summary>
    /// We get the date from the user's console input.
    /// </summary>
    /// <returns> Date. </returns>
    private static DateTime ParseDate()
    {
        while (true)
        {
            Console.WriteLine("Enter the date: ");
            if (DateTime.TryParse(Console.ReadLine(), out var date))
            {
                return date;
            }
        }
    }
}