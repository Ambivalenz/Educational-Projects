namespace ConsoleLinq;

public class Movie
{
    #region Fields and properties.

    /// <summary>
    /// Rating in the kinopoisk list.
    /// </summary>
    public int Rating { get; set; }

    /// <summary>
    /// The name of the movie.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Year of release.
    /// </summary>
    public int YearOfProduction { get; set; }

    /// <summary>
    /// Country of manufacture.
    /// </summary>
    public string Country { get; set; }

    /// <summary>
    /// Rating of the film.
    /// </summary>
    public double RatingBall { get; set; }

    /// <summary>
    /// The name of the director.
    /// </summary>
    public string Director { get; set; }

    #endregion

    #region Methods for working with the file.

    /// <summary>
    /// Overriding the toString method.
    /// </summary>
    /// <returns> String representation of class properties. </returns>
    public override string ToString()
    {
        return $"Name: {Name}, Rating: {Rating}, Year of production: {YearOfProduction}, " +
               $"Country: {Country}, RatingBall: {RatingBall}, Director: {Director}.";
    }

    /// <summary>
    /// Reading data from a file.
    /// </summary>
    /// <param name="line"> The path to the file. </param>
    /// <returns> Returns a class with the specified parameters. </returns>
    public static Movie ParseMovieCsv(string line)
    {
        var parts = line.Split(',');
        return new Movie()
        {
            Rating = int.Parse(parts[0]),
            Name = parts[1].Trim(),
            YearOfProduction = int.Parse(parts[2]),
            Country = parts[3].Trim(),
            RatingBall = double.Parse(parts[4]),
            Director = parts[5].Trim()
        };
    }

    #endregion
}