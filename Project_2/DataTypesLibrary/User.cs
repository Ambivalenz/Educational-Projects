namespace DataTypesLibrary;

/// <summary>
/// Working with user data.
/// </summary>
public struct User
{
    /// <summary>
    /// Name.
    /// </summary>
    private string? Name { get; set; }

    /// <summary>
    /// Age.
    /// </summary>
    private int Age { get; set; }

    /// <summary>
    /// Constructor for the user.
    /// </summary>
    /// <param name="name"> Name. </param>
    /// <param name="age"> Age. </param>
    public User(string? name = "Undefined", int age = 1)
    {
        Name = name;
        Age = age;
    }

    /// <summary>
    /// Displays information about the user.
    /// </summary>
    public void PrintInformation()
    {
        Console.WriteLine($"Name: {Name}. Age: {Age}");
    }
}