namespace ConsoleOOPApp;

public class User
{
    #region Свойства и поля класса.

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
    /// Surname.
    /// </summary>
    public string Surname
    {
        get => _surname;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value), "The last name cannot be empty!");
            }

            _surname = value;
        }
    }

    /// <summary>
    /// Patronymic.
    /// </summary>
    public string Patronymic
    {
        get => _patronymic;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value), "The patronymic cannot be empty!");
            }

            _patronymic = value;
        }
    }

    /// <summary>
    /// Birthday.
    /// </summary>
    public DateTime Birthday
    {
        get => _birthday;
        set
        {
            if (value.CompareTo(DateTime.UtcNow) > 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Date of birth entered incorrectly!");
            }

            _birthday = value;
        }
    }

    /// <summary>
    /// Age.
    /// </summary>
    public int Age
    {
        get => _age;
        set
        {
            if (value < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "The age value cannot be zero or negative!");
            }

            if (value > 150)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "You can't live that long! :)");
            }

            _age = value;
        }
    }

    /// <summary>
    /// Name.
    /// </summary>
    private string _name;

    /// <summary>
    /// Surname.
    /// </summary>
    private string _surname;

    /// <summary>
    /// Patronymic.
    /// </summary>
    private string _patronymic;

    /// <summary>
    /// Birthday.
    /// </summary>
    private DateTime _birthday;

    /// <summary>
    /// Age.
    /// </summary>
    private int _age;

    /// <summary>
    /// Initialization of the class.
    /// </summary>
    /// <param name="name"> Name. </param>
    /// <param name="surname"> Surname. </param>
    /// <param name="patronymic"> Patronymic. </param>
    /// <param name="birthday"> Birthday. </param>
    /// <param name="age"> Age. </param>
    protected User(string name,
        string surname,
        string patronymic,
        DateTime birthday,
        int age)
    {
        Name = name;
        Surname = surname;
        Patronymic = patronymic;
        Birthday = birthday;
        Age = age;
    }

    #endregion

    /// <summary>
    /// Overriding the toString method.
    /// </summary>
    /// <returns> Displays information about the user. </returns>
    public override string ToString()
    {
        return $"Surname - {Surname}, Name - {Name}, Patronymic - {Patronymic}\n" +
               $"Birthday - {Birthday}\n" +
               $"Age - {Age}\n";
    }
}