using System.Text;

namespace ConsoleLinq;

internal static class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        try
        {
            // For correct reading of the file encoding.
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            TestExercise("kinopoisk250.csv");
            Console.ReadLine();
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

    #region Methods for collections with linq and lambda expressions.

    /// <summary>
    /// Linq queries.
    /// </summary>
    /// <param name="file"> The file name.</param>
    private static void TestExercise(string file)
    {
        if (string.IsNullOrEmpty(file))
        {
            throw new ArgumentNullException(nameof(file), $"The {file} object cannot be empty!");
        }

        // We select films by year and group them in descending order by rating (the first 50).
        var list = File.ReadAllLines(file, Encoding.GetEncoding(1251))
            .Skip(1)
            .Select(line => Movie.ParseMovieCsv(line))
            .Where(year => year.YearOfProduction > 1950)
            .OrderByDescending(year => year.RatingBall)
            .Take(50)
            .ToList();

        // We select films by country and bring them to the collection.
        IEnumerable<Movie> list2 = File.ReadAllLines(file, Encoding.GetEncoding(1251))
            .Skip(1)
            .Select(Movie.ParseMovieCsv)
            .Distinct()
            .OrderBy(movie => movie.Country == "СССР");

        ForEach(list2, movie => Console.WriteLine($"{movie.Name}, {movie.Country}, {movie.Director}"));

        #region Application of SQL-Like syntax.

        // We apply a filter by country and group by rating in descending order.
        var filtered = from movie in list
            where movie.Country == "Германия"
            orderby movie.RatingBall descending
            select movie;

        ForEach(filtered, movie => Console.WriteLine($"{movie.Name}, {movie.Country}, {movie.RatingBall}"));

        // We apply a filter by director and year of release, then select the rating, name and year of release.
        var lastMovie = from movie in list
            where movie.YearOfProduction > 1980
                  && movie.Director == "Дэвид Финчер"
            select new
            {
                movie.Rating,
                movie.Name,
                movie.YearOfProduction
            };

        ForEach(lastMovie, movie => Console.WriteLine($"{movie.Name}, {movie.YearOfProduction}"));

        #endregion

        Print(list);
    }

    /// <summary>
    /// Statistics output to the screen.
    /// </summary>
    /// <param name="list"> Collection.</param>
    private static void Print(List<Movie> list)
    {
        if (list == null)
        {
            throw new ArgumentNullException(nameof(list), $"The object {list} cannot be empty!");
        }

        Console.WriteLine($"The highest rating in TOP 50: {list.Max(x => x.RatingBall)}");
        Console.WriteLine($"The lowest rating in TOP 50: {list.Min(x => x.RatingBall)}");
        Console.WriteLine($"The average rating in TOP 50: {list.Average(x => x.RatingBall)}\n");

        Console.WriteLine(list.First(movie => movie.Country == "США"));
        Console.WriteLine(list.First(movie => movie.Name == "Престиж"));
        Console.WriteLine(list.Last(movie => movie.Country == "США"));
    }

    /// <summary>
    /// The ForEach extension method for lambda expressions.
    /// </summary>
    /// <typeparam name="T"> Type. </typeparam>
    /// <param name="source"> Collection. </param>
    /// <param name="action"> Delegate. </param>
    private static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source), $"The object {source} cannot be empty!");
        }

        foreach (var item in source)
        {
            action(item);
        }
    }

    #endregion
}