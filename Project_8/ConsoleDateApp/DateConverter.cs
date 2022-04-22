namespace ConsoleDateApp;

/// <summary>
/// Converts the date.
/// </summary>
public class DateConverter
{
    /// <summary>
    /// Converts a date from UTC to a date in local format.
    /// </summary>
    /// <param name="date"> Date. </param>
    /// <returns> Local date. </returns>
    public DateTime ConvertDate(DateTime date)
    {
        if (date.Kind == DateTimeKind.Local)
        {
            throw new ArgumentException("The date cannot be converted!", nameof(date));
        }

        return TimeZoneInfo.ConvertTimeFromUtc(date, TimeZoneInfo.Local);
    }
}