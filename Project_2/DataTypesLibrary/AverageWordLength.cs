namespace DataTypesLibrary;

/// <summary>
/// Counting the average length of words.
/// </summary>
public static class AverageWordLength
{
    /// <summary>
    /// Calculates the average length of a word in a string.
    /// </summary>
    /// <param name="text"> The argument is text. </param>
    /// <returns> Returns the average value of the word length. </returns>
    public static double GetMediumWord(string? text)
    {
        if (string.IsNullOrEmpty(text))
        {
            throw new ArgumentNullException(nameof(text), "An empty string cannot be entered!");
        }

        var amount = 0.0;
        var punctuationMarks = new List<char>();

        foreach (var str in text)
        {
            if (char.IsLetter(str))
            {
                amount++;
            }

            if (char.IsPunctuation(str))
            {
                punctuationMarks.Add(str);
            }
        }

        return amount / text.Split(punctuationMarks.ToArray()).Length;
    }
}