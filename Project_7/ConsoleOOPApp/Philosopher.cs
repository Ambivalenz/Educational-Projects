namespace ConsoleOOPApp;

public abstract class Philosopher : IPhilosophicalThinking
{
    #region Properties and fields of the class.

    /// <summary>
    /// Name.
    /// </summary>
    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value), "The name cannot be empty!");
            }

            _name = value;
        }
    }

    /// <summary>
    /// Name.
    /// </summary>
    private string _name;

    /// <summary>
    /// Initialization of class properties.
    /// </summary>
    /// <param name="name"> Name. </param>
    protected Philosopher(string name)
    {
        Name = name;
    }

    #endregion

    #region Методы.

    /// <summary>
    /// Belonging to the philosophical school.
    /// </summary>
    /// <returns> Returns the philosophical school. </returns>
    public abstract string PhilosophicalSchool();

    /// <summary>
    /// Overriding the toString method.
    /// </summary>
    /// <returns> Returns the name of the philosopher. </returns>
    public override string ToString()
    {
        return $"Name - {Name}";
    }

    #endregion
}