using System.Text;

namespace FunctionalLibrary;

public class GeometricShapes
{
    /// <summary>
    /// Draws a square of size N.
    /// </summary>
    /// <param name="n"> An odd and positive number at least 3. </param>
    /// <returns> Returns a string with a drawing. </returns>
    public static string CreateSquare(int n)
    {
        if (n % 2 == 0 || n < 3)
        {
            throw new ArgumentException("This number is not odd or positive (at least 3)!");
        }

        var str = new StringBuilder();
        var medium = n / 2;

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                str.Append((j == medium) && (i == medium)
                    ? " "
                    : "*");
            }

            str.Append("\n");
        }

        return str.ToString();
    }
}