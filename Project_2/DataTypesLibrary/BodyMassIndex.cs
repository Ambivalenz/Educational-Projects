namespace DataTypesLibrary;

/// <summary>
/// Determines the body mass index.
/// </summary>
public static class BodyMassIndex
{
    /// <summary>
    /// Calculates the body mass index.
    /// </summary>
    /// <param name="weight"> Weight is a positive number. </param>
    /// <param name="height"> Growth is a positive number. </param>
    /// <returns> Returns the body mass index. </returns>
    public static double CalculateMassIndex(double weight, double height)
    {
        const int metersToCentimeters = 100;

        if (weight <= 0)
        {
            throw new ArgumentException($"Incorrect weight value entered - {weight}!");
        }

        if (height <= 0)
        {
            throw new ArgumentException($"Incorrect growth value has been entered - {height}!");
        }

        var heightToCm = height / metersToCentimeters;
        return weight / (heightToCm * heightToCm);
    }

    /// <summary>
    /// BMI compliance information.
    /// </summary>
    /// <param name="value"> A positive number is the BMI parameter. </param>
    /// <returns> Returns a string with information. </returns>
    public static string DescriptionResultBmi(double value)
    {
        switch (value)
        {
            case <= 18.5:
                return "Lack of body weight.\n" +
                       "Insufficient body weight can have a bad effect on health.\n";
            case > 18.5 and < 24.9:
                return "Normal body weight.\n" +
                       "Continue to stick to your diet and exercise regime . activity.\n";
            case >= 25 and <= 29.9:
                return "Excess body weight.\n" +
                       " It is necessary to reduce the weight. Move more and reduce the caloric intake.\n";
            case > 30 and <= 35:
                return "Fatness.\n" +
                       " It is necessary to normalize body weight as soon as possible.\n";
            default:
                return "Fatness. You need to contact a specialist.\n";
        }
    }
}