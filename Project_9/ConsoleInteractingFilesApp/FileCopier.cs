namespace ConsoleInteractingFilesApp;

public sealed class FileCopier
{
    #region Events about the start, progress, and completion of copying.

    /// <summary>
    /// Start of copying.
    /// </summary>
    public event EventHandler<EventArgs> CopyStarted;

    /// <summary>
    /// Calling the copy start event.
    /// </summary>
    private void OnCopyStarted()
    {
        CopyStarted?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// Completion of the copy.
    /// </summary>
    public event EventHandler<EventArgs> CopyFinished;

    /// <summary>
    /// Calling the copy completion event.
    /// </summary>
    private void OnCopyFinished()
    {
        CopyFinished?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// Copy progress.
    /// </summary>
    public event EventHandler<double> CopyProgress;

    /// <summary>
    /// Calling the copy progress event.
    /// </summary>
    /// <param name="progress"> Progress as a percentage. </param>
    private void OnCopyProgress(double progress)
    {
        CopyProgress?.Invoke(this, progress);
    }

    #endregion

    #region Methods of copying and writing data to a file.

    /// <summary>
    /// Byte-by-byte copying from one file to another.
    /// </summary>
    /// <param name="filePath"> The path of the original file. </param>
    /// <param name="replaceFile"> Destination file path. </param>
    /// <param name="blockSize"> Block Size. </param>
    public void CopyFile(string filePath, string replaceFile, int blockSize)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            throw new ArgumentNullException(nameof(filePath), "The file name cannot be empty!");
        }

        if (string.IsNullOrEmpty(replaceFile))
        {
            throw new ArgumentNullException(nameof(replaceFile), "The file name cannot be empty!");
        }

        if (blockSize < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(blockSize), "The value is incorrect!");
        }

        OnCopyStarted();

        var bufferCount = 0;

        using (var stream = new FileStream(filePath, FileMode.OpenOrCreate))
        using (var reader = new BinaryReader(stream))
        using (var destination = new FileStream(replaceFile, FileMode.OpenOrCreate))
        using (var writer = new BinaryWriter(destination))
        {
            destination.SetLength(0);

            while (reader.PeekChar() != -1)
            {
                var buffer = reader.ReadBytes(blockSize);
                writer.Write(buffer);

                OnCopyProgress((stream.Length + bufferCount * blockSize) / 10);
                bufferCount++;
            }
        }

        OnCopyFinished();
    }

    /// <summary>
    /// Writing information to a file.
    /// </summary>
    /// <param name="path"> The file path. </param>
    /// <param name="buffer"> The value to be written in bytes. </param>
    /// <param name="count"> The number of recorded values. </param>
    public void Write(string path, byte[] buffer, int count)
    {
        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentNullException(nameof(path), "The path cannot be empty!");
        }

        if (buffer == null)
        {
            throw new ArgumentNullException(nameof(buffer), "The value cannot be empty!");
        }

        if (count < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(count), "The number cannot be negative!");
        }

        using var stream = new FileStream(path, FileMode.OpenOrCreate);
        stream.Write(buffer, 0, count);
    }

    /// <summary>
    /// Writing data to the end of the file.
    /// </summary>
    /// <param name="path"> File path. </param>
    /// <param name="buffer"> Data for recording. </param>
    public void WriteEnd(string path, string buffer)
    {
        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentNullException(nameof(path), "The path cannot be empty!");
        }

        if (!File.Exists(path))
        {
            throw new FileNotFoundException("The file was not found!", nameof(path));
        }

        if (string.IsNullOrEmpty(buffer))
        {
            throw new ArgumentNullException(nameof(buffer), "The value cannot be empty!");
        }

        using var writer = new StreamWriter(path, true);
        writer.Write(buffer);
    }

    #endregion
}