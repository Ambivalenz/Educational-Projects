using System.Configuration;
using System.Text;
using System.Text.Json;

namespace ConsoleJsonApp;

public static class JsonSerializator
{
    #region The path to the file.

    /// <summary>
    /// The path to the file is set via App Config.
    /// </summary>
    private const string? Path = "author.json"; //ConfigurationManager.AppSettings["Your_Path_To_File"];

    #endregion

    #region Serialization and deserialization methods.

    /// <summary>
    /// The process of serialization is converting an object into a Json file.
    /// </summary>
    /// <param name="author"> Information about the author. </param>
    public static string Serialize(Author author)
    {
        if (author == null)
        {
            throw new ArgumentNullException(nameof(author), "The object cannot be empty!");
        }

        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            IgnoreReadOnlyProperties = true
        };

        var authorJson = JsonSerializer.Serialize<Author>(author, options);

        Write(authorJson);

        return authorJson;
    }

    /// <summary>
    /// Writes a string to a file.
    /// </summary>
    /// <param name="author"> The string parameter. </param>
    /// <returns> True - the recording was successful. </returns>
    public static bool Write(string author)
    {
        if (string.IsNullOrEmpty(author))
        {
            throw new ArgumentNullException(nameof(author), "The object cannot be empty!");
        }

        using var writer = new StreamWriter(Path, false, Encoding.UTF8);
        writer.WriteLine(author);

        return true;
    }

    /// <summary>
    /// Reads lines from a file.
    /// </summary>
    /// <param name="author"> The string parameter. </param>
    /// <returns> Returns the read string. </returns>
    public static string Read(string author)
    {
        if (string.IsNullOrEmpty(author))
        {
            throw new ArgumentNullException($"The object - {author} cannot be empty!", nameof(author));
        }

        var authorJson = string.Empty;

        using var reader = new StreamReader(Path, false);
        authorJson = reader.ReadToEnd();

        return authorJson;
    }

    /// <summary>
    /// The deserialization process is restoring an object from a serialized file.
    /// </summary>
    /// <returns> Returns a deserialized object. </returns>
    public static Author Deserialize(string author)
    {
        if (author == null)
        {
            throw new ArgumentNullException($"The object - {author} cannot be empty!", nameof(author));
        }

        Read(author);
        return JsonSerializer.Deserialize<Author>(author);
    }

    #endregion
}