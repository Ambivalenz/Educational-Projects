namespace LibraryCollections;

public static class FrequencyWords
{
    /// <summary>
    /// Finds the frequency of repetition of words.
    /// </summary>
    /// <param name="input"> Text.</param>
    /// <returns>List of grouped words.</returns>
    public static IGrouping<string, string>[] GetFrequencyWords(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentNullException($"The string - {input} cannot be empty!");
        }

        var words = Parse(input);
        return words.GroupBy(word => word.ToLower()).ToArray();
    }

    /// <summary>
    /// Finds the specified delimiters in the words of the specified text.
    /// </summary>
    /// <param name="text"> Text.</param>
    /// <returns> List of words.</returns>
    private static IEnumerable<string> Parse(string text)
    {
        return text.Split(new[] {' ', '.'}, StringSplitOptions.RemoveEmptyEntries);
    }
}