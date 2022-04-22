using LibraryCollections;

namespace CollectionsDevConsoleApp;

internal static class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        try
        {
            FrequencyCount();
            DynamicArray();
            GC.Collect();
        }
        catch (ArgumentException exc)
        {
            Console.WriteLine(exc.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    /// <summary>
    /// A test for counting words in the text.
    /// </summary>
    private static void FrequencyCount()
    {
        var sonnet = "Let those who are in favour with their stars" +
                     "Of public honour and proud titles boast," +
                     "Whilst I, whom fortune of such triumph bars" +
                     "Unlook'd for joy in that I honour most." +
                     "Great princes' favourites their fair leaves spread" +
                     "But as the marigold at the sun's eye," +
                     "And in themselves their pride lies buried," +
                     "For at a frown they in their glory die." +
                     "The painful warrior famoused for fight," +
                     "After a thousand victories once foiled," +
                     "Is from the book of honour razed quite," +
                     "And all the rest forgot for which he toiled:" +
                     "Then happy I, that love and am beloved," +
                     "Where I may not remove nor be removed.";

        var words = FrequencyWords.GetFrequencyWords(sonnet);

        Console.WriteLine("Frequency of words: ");
        foreach (var word in words)
        {
            Console.WriteLine($"{word.Key} - {word.Count()}");
        }
    }

    /// <summary>
    /// A test for a dynamic array.
    /// </summary>
    private static void DynamicArray()
    {
        var arr = new MyDynamicArray<int>(new int[] {0, 1, 2, 3, 4, 5});

        Console.WriteLine("Array: ");
        PrintArray(arr);

        Console.WriteLine("Adding a number 60: ");
        arr.Add(60);
        PrintArray(arr);

        Console.WriteLine("Adding to the end of the array: ");
        arr.AddRange(new int[] {70, 80, 90});
        PrintArray(arr);

        Console.WriteLine("Deleting an item with an index '0': ");
        arr.Remove(0);
        PrintArray(arr);

        Console.WriteLine("Adding element 20 with an index 1: ");
        arr.Insert(20, 1);
        PrintArray(arr);

        Console.WriteLine("Changing an element: ");
        arr[2] = 11;
        PrintArray(arr);

        var one = new MyDynamicArray<int>(new int[] {1, 2, 3});
        var two = new MyDynamicArray<int>(new int[] {1, 2, 3});
        var list = new List<int>(new int[] {1, 2, 3});

        Console.WriteLine("Comparing two instances of a class UnusualDynamicArray: " +
                          $"{one.Equals(two)}");

        Console.WriteLine("Comparing two instances of a class UnusualDynamicArray и List: " +
                          $"{one.Equals(list)}");
    }

    /// <summary>
    /// Outputs an array to the console.
    /// </summary>
    /// <param name="array"> Array. </param>
    private static void PrintArray(MyDynamicArray<int> array)
    {
        Console.WriteLine(array.ToString());
    }
}