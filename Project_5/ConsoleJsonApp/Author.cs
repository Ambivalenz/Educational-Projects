namespace ConsoleJsonApp;

public class Author
{
    #region Fields and properties of the class.

    /// <summary>
    /// Surname.
    /// </summary>
    public string Surname { get; set; }

    /// <summary>
    /// Name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Age.
    /// </summary>
    public int AuthorAge
    {
        get => _age;

        set
        {
            if (value is < 0 or > 100)
            {
                throw new ArgumentOutOfRangeException($"The age - {_age} should be in the range from 0 to 100 years!");
            }

            _age = value;
        }
    }

    /// <summary>
    /// Age for validation.
    /// </summary>
    private int _age;

    /// <summary>
    /// Birthday.
    /// </summary>
    public DateTime Birthday { get; set; }

    /// <summary>
    /// The name of the book with a key-value pair.
    /// </summary>
    public Dictionary<int, string> Book { get; set; }

    #endregion
}