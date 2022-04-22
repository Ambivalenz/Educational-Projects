namespace ConsoleOOPApp;

public struct Coordinate
{
    /// <summary>
    /// The X-axis coordinate.
    /// </summary>
    public double X
    {
        get => _x;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentNullException(nameof(value),
                    $"The X coordinate cannot be less than or equal to zero!");
            }

            _x = value;
        }
    }

    /// <summary>
    /// Y-axis coordinate.
    /// </summary>
    public double Y
    {
        get => _y;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentNullException(nameof(value),
                    "The Y coordinate cannot be less than or equal to zero!");
            }

            _y = value;
        }
    }

    /// <summary>
    /// The X coordinate.
    /// </summary>
    private double _x;

    /// <summary>
    /// The Y coordinate.
    /// </summary>
    private double _y;
}