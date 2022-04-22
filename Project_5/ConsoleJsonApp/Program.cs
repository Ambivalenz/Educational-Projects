using System.Text;

namespace ConsoleJsonApp;

internal static class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        try
        {
            var authorOne = new Author
            {
                Name = "Franz",
                Surname = "Kafka",
                AuthorAge = 50,
                Birthday = new DateTime(1924, 01, 16),
                Book = new Dictionary<int, string>()
                {
                    {1, "Castle" },
                    {2, "Process" },
                    {3, "Transformation" }
                }
            };

            var authorTwo = new Author
            {
                Name = "George",
                Surname = "Orwell",
                AuthorAge = 42,
                Birthday = new DateTime(1924, 01, 16),
                Book = new Dictionary<int, string>()
                {
                    {1, "1984" },
                    {2, "Animal Farm" }
                }
            };

            Console.WriteLine(ResultSerialize(authorOne));
            Console.WriteLine(ResultSerialize(authorTwo));

            PrintFormattedJsonText(authorOne);
            PrintFormattedJsonText(authorTwo);

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
    
    #region Application of serialization and output to the console.

    /// <summary>
    /// Serializes the object.
    /// </summary>
    /// <param name="author"> Information about the author. </param>
    /// <returns> String representation of the object. </returns>
    private static string ResultSerialize(Author author)
    {
        if (author == null)
        {
            throw new ArgumentNullException($"The object - {author} cannot be empty!", nameof(author));
        }

        var str = new StringBuilder();

        JsonSerializator.Deserialize(JsonSerializator.Serialize(author));

        str.Append("Serialization has been completed successfully!");
        str.Append(Environment.NewLine);

        return str.ToString();
    }

    /// <summary>
    /// Outputs the contents of the deserialized object to the console.
    /// </summary>
    /// <param name="author"> Information about the author. </param>
    private static void PrintFormattedJsonText(Author author)
    {
        if (author == null)
        {
            throw new ArgumentNullException($"he object - {author} cannot be empty!", nameof(author));
        }

        Console.WriteLine($"Name: {author.Name}\n" +
                          $"Surname: {author.Surname}\n" +
                          $"Age: {author.AuthorAge}\n" +
                          $"Birthday: {author.Birthday}\n" +
                          $"Books: ");

        foreach (var book in author.Book)
        {
            Console.Write($"ID books: {book.Key}. Name: {book.Value}.\n");
        }
    }

    #endregion
}

