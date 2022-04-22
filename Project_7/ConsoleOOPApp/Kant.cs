namespace ConsoleOOPApp;

public class Kant : Philosopher
{
    #region Property.

    /// <summary>
    /// Constructor for initializing properties. Inherited from Philosopher.
    /// </summary>
    /// <param name="name"> Name. </param>
    public Kant()
        : base(name: "Kant")
    {
    }

    #endregion

    #region Overriding a method from an inheritor class.

    /// <summary>
    /// Redefinition of the method of the philosophical school.
    /// </summary>
    /// <returns> Returns information about the affiliation. </returns>
    public override string PhilosophicalSchool()
    {
        return "The founder of German classical philosophy.\n" +
               "Is the ideological inspirer of the philosophical school of neo-Kantianism.\n";
    }

    #endregion
}