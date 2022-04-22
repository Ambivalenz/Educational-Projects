using System.Text;

namespace FunctionalLibrary;

public static class AlgorithmicOperations
{
    /// <summary>
    /// Returns a string from 1 to N.
    /// </summary>
    /// <param name="n"> A positive number. </param>
    /// <returns> A string with numbers. </returns>
    public static string GenerateSequence(int n)
    {
        var str = new StringBuilder();
        if (n < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(n), "This number is not positive!");
        }

        for (var i = 1; i <= n; i++)
        {
            str.Append(i != n
                ? $"{i}, "
                : $"{i}");
        }

        return str.ToString();
    }
}