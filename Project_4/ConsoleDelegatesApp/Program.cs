using LibraryDelegates;

namespace ConsoleDelegatesApp;

internal class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        try
        {
            TestSortingArray();
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
    /// A test of how array sorting works.
    /// </summary>
    private static void TestSortingArray()
    {
        var arraySorting = new SortingArbitraryArray();
        var array = new[] {2, 10, 9, 11, 25, 17, 50, 200, 121, 6};

        Console.WriteLine(SortingArbitraryArray.PrintArray(array));
        Subscribe(arraySorting);
        arraySorting.SortArray(array, (firstElement, lastElement) => firstElement < lastElement);
        UnSubscribe(arraySorting);
        Console.WriteLine(SortingArbitraryArray.PrintArray(array));
    }

    /// <summary>
    /// Subscribe to events.
    /// </summary>
    /// <typeparam name="T"> Type.</typeparam>
    /// <param name="array"> Array.</param>
    private static void Subscribe(SortingArbitraryArray array)
    {
        if (array == null)
        {
            throw new ArgumentNullException($"The array - {array} cannot be empty!");
        }

        array.SortStart += OnStartSorting;
        array.SortFinish += OnEndSorting;
    }

    /// <summary>
    /// Unsubscribe from events.
    /// </summary>
    /// <typeparam name="T"> Type.</typeparam>
    /// <param name="array"> Array.</param>
    private static void UnSubscribe(SortingArbitraryArray array)
    {
        if (array == null)
        {
            throw new ArgumentNullException($"The array - {array} cannot be empty!");
        }

        array.SortStart -= OnStartSorting;
        array.SortFinish -= OnEndSorting;
    }

    /// <summary>
    /// Notification of the beginning of array sorting.
    /// </summary>
    /// <param name="sender"> Object parameter. </param>
    /// <param name="eventArgs"> Event parameter. </param>
    private static void OnStartSorting(object sender, EventArgs eventArgs)
    {
        Console.WriteLine("Sorting of the array has started...");
    }

    /// <summary>
    /// Notification of the end of array sorting.
    /// </summary>
    private static void OnEndSorting()
    {
        Console.WriteLine("Array sorting is over!");
    }
}