namespace ConsoleOOPApp;

public class Employee : User
{
    #region Properties and fields of the class.

    /// <summary>
    /// The employee's work experience.
    /// </summary>
    public double WorkExperience
    {
        get => _workExperience;
        set
        {
            if (value < 0.1)
            {
                throw new ArgumentException("The value of experience is working incorrectly!", nameof(value));
            }

            _workExperience = value;
        }
    }

    /// <summary>
    /// The position of the employee.
    /// </summary>
    public string Post
    {
        get => _post;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value), $"The position value is incorrect!");
            }

            _post = value;
        }
    }

    /// <summary>
    /// Work experience.
    /// </summary>
    private double _workExperience;

    /// <summary>
    /// The position of the employee.
    /// </summary>
    private string _post;

    /// <summary>
    /// Constructor for properties.
    /// </summary>
    /// <param name="name"> Name. </param>
    /// <param name="surname"> Surname. </param>
    /// <param name="patronymic"> Patronymic. </param>
    /// <param name="birthday"> Birthday. </param>
    /// <param name="age"> Age. </param>
    /// <param name="workExperience"> Work Experience. </param>
    /// <param name="post"> Post. </param>
    public Employee(
        string name,
        string surname,
        string patronymic,
        DateTime birthday,
        int age,
        double workExperience,
        string post)
        : base(name, surname, patronymic, birthday, age)
    {
        WorkExperience = workExperience;
        Post = post;
    }

    #endregion

    /// <summary>
    /// Overriding the toString method.
    /// </summary>
    /// <returns> Returns updated information about the employee. </returns>
    public override string ToString()
    {
        return base.ToString() +
               $"Work experience - {WorkExperience}\n" +
               $"Current position - {Post}\n";
    }
}