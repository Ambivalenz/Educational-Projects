namespace ConsoleOOPApp;

public sealed class Round
{
    /// <summary>
    /// The coordinate of the center of the circle.
    /// </summary>
    public Coordinate Center { get; }

    /// <summary>
    /// The circumference of the circle.
    /// </summary>
    public double Length { get; }

    /// <summary>
    /// The area of the circle.
    /// </summary>
    public double Square { get; }

    /// <summary>
    /// The radius of the circle.
    /// </summary>
    public double Radius
    {
        get => _radius;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentNullException("The radius cannot be less than or equal to zero!", nameof(value));
            }

            _radius = value;
        }
    }

    /// <summary>
    /// The radius of the circle.
    /// </summary>
    private double _radius;

    /// <summary>
    /// Constructor of a class with initialization of properties.
    /// </summary>
    /// <param name="center"> The center of the circle. </param>
    /// <param name="radius"> The radius of the circle.</param>
    public Round(Coordinate center, double radius)
    {
        Center = center;
        Radius = radius;

        Length = ComputeLength();
        Square = ComputeSquare();

        OnComputeFinish();
    }

    /// <summary>
    /// Calculates the length of the circumscribed circle.
    /// </summary>
    /// <returns> Rounded number to 3 decimal places. </returns>
    private double ComputeLength()
    {
        return Math.Round(Math.PI * 2 * Radius, 3);
    }

    /// <summary>
    /// Calculates the area of a circle.
    /// </summary>
    /// <returns> Rounded number to 3 decimal places. </returns>
    private double ComputeSquare()
    {
        return Math.Round(Math.PI * Math.Pow(Radius, 2), 3);
    }

    /// <summary>
    /// The event of the end of the calculation of the properties of the circle (length, area).
    /// </summary>
    public event EventHandler<EventArgs> ComputeFinish;

    /// <summary>
    /// Calling the end of the calculation event.
    /// </summary>
    private void OnComputeFinish()
    {
        ComputeFinish?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// Overriding the toString method.
    /// </summary>
    /// <returns> Returns the properties of the circle. </returns>
    public override string ToString()
    {
        return $"The coordinates of the center are equal: {Center.X}, {Center.Y}\n" +
               $"Circumference length: {Length}\n" +
               $"The area of the circle: {Square}\n" +
               $"Circle radius: {Radius}\n";
    }
}