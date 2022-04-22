namespace ConsoleInteractingFilesApp;

internal static class Program
{
    /// <summary>
    /// The name of the source file.
    /// </summary>
    private const string FileName = "test.txt"; //ConfigurationManager.AppSettings["FileName"];

    /// <summary>
    /// The name of the file to record.
    /// </summary>
    private const string ReplaceFile = "modified.txt"; //ConfigurationManager.AppSettings["ReplaceFileName"];
    
    [STAThread]
    static void Main(string[] args)
    {
        var fileCopier = new FileCopier();
        byte[] numbers = {0, 16, 24, 38, 56};

        try
        {
            Subscribe(fileCopier);

            fileCopier.Write(FileName, numbers, 5);
            fileCopier.CopyFile(FileName, ReplaceFile, 10);
            fileCopier.WriteEnd(ReplaceFile, "\nexample text example text example text A12345");

            var fileReader = new FileReading(ReplaceFile);
            var buffer = fileReader.ReadText();
            var readByte = fileReader.ReadBytes();

            Console.WriteLine($"\nResult of reading from a file:\n {buffer}");
            Console.WriteLine("The result of reading from the file in bytes:");

            foreach (var read in readByte)
            {
                Console.WriteLine(read);
            }
        }
        catch (ArgumentException exc)
        {
            Console.WriteLine(exc.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            Unsubscribe(fileCopier);
        }
    }

    #region Methods of subscribing and unsubscribing from events.

    /// <summary>
    /// Subscribe to events.
    /// </summary>
    /// <param name="file"> File. </param>
    private static void Subscribe(FileCopier file)
    {
        if (file is null)
        {
            throw new ArgumentNullException(nameof(file), "The file cannot be empty!");
        }

        file.CopyStarted += CopyStarting;
        file.CopyProgress += CopyProgress;
        file.CopyFinished += CopyFinished;
    }

    /// <summary>
    /// Unsubscribe from events.
    /// </summary>
    /// <param name="file"> File. </param>
    private static void Unsubscribe(FileCopier file)
    {
        if (file is null)
        {
            throw new ArgumentNullException(nameof(file), "The file cannot be empty!");
        }

        file.CopyStarted -= CopyStarting;
        file.CopyProgress -= CopyProgress;
        file.CopyFinished -= CopyFinished;
    }

    #endregion

    #region Output event information to the console.

    /// <summary>
    /// Output information about the start of copying to the console.
    /// </summary>
    /// <param name="sender"> Object. </param>
    /// <param name="e"> Event. </param>
    private static void CopyStarting(object sender, EventArgs e)
    {
        Console.WriteLine("Copying has begun!");
    }

    /// <summary>
    /// Output information about the completion of copying to the console.
    /// </summary>
    /// <param name="sender"> Object. </param>
    /// <param name="e"> Event. </param>
    private static void CopyFinished(object sender, EventArgs e)
    {
        Console.WriteLine("Copying completed successfully!");
    }

    /// <summary>
    /// Output progress to the console.
    /// </summary>
    /// <param name="sender"> Object. </param>
    /// <param name="progress"> Progress. </param>
    private static void CopyProgress(object sender, double progress)
    {
        Console.SetCursorPosition(0, 1);
        Console.WriteLine($"Progress: {progress}%");
    }

    #endregion
}