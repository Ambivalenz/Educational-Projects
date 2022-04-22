namespace ConsoleInteractingFilesApp;

public class FileReading
{
    #region Class properties, constructor initialization.

    /// <summary>
    /// The path to the file.
    /// </summary>
    private readonly string _fileName;

    /// <summary>
    /// Constructor for reading the file.
    /// </summary>
    /// <param name="fileName"> File name. </param>
    public FileReading(string fileName)
    {
        if (string.IsNullOrEmpty(fileName))
        {
            throw new ArgumentNullException(nameof(fileName), "The file path cannot be empty!");
        }

        if (!File.Exists(fileName))
        {
            throw new FileNotFoundException("The specified file could not be found!", nameof(fileName));
        }

        _fileName = fileName;
    }

    #endregion

    #region Methods of reading information from a file.

    /// <summary>
    /// Reading data in a text representation.
    /// </summary>
    /// <returns> File data in a text representation. </returns>
    public string ReadText()
    {
        using var reader = new StreamReader(_fileName);
        return reader.ReadToEnd();
    }

    /// <summary>
    /// Reading data in byte representation.
    /// </summary>
    /// <returns> File data in byte array representation. </returns>
    public IEnumerable<byte> ReadBytes()
    {
        return File.ReadAllBytes(_fileName);
    }

    #endregion
}