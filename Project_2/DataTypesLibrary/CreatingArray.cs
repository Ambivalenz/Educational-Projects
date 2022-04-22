namespace DataTypesLibrary;

/// <summary>
/// Working with an array.
/// </summary>
public static class CreatingArray
{
    private static int[]? _array;

    /// <summary>
    /// Generates an array of random elements.
    /// </summary>
    /// <param name="length"> The length of the array. </param>
    /// <param name="minValue"> The minimum value in the array. </param>
    /// <param name="maxValue"> The maximum value in the array. </param>
    public static void GenerateRandomElements(int length, int minValue, int maxValue)
    {
        var rand = new Random();

        if (length <= 0)
        {
            throw new ArgumentNullException($"An empty array - {length} cannot be entered!");
        }

        _array = new int[length];

        for (var i = 0; i < _array.Length; i++)
        {
            _array[i] = rand.Next(minValue, maxValue);
        }
    }

    /// <summary>
    /// Searches for the minimum element in the array.
    /// </summary>
    /// <returns> Returns the minimum element. </returns>
    private static int SearchMinElement()
    {
        var minNumber = _array[0];

        return _array.Prepend(minNumber).Min();
    }

    /// <summary>
    /// Searches for the maximum element in the array.
    /// </summary>
    /// <returns> Returns the maximum element. </returns>
    private static int SearchMaxElement()
    {
        var maxNumber = _array[0];

        return _array.Prepend(maxNumber).Max();
    }

    /// <summary>
    /// Sorts the array.
    /// </summary>
    /// <returns> Returns a sorted array. </returns>
    public static int[]? Sort()
    {
        for (var i = 0; i < _array.Length; i++)
        {
            for (var j = 0; j < _array.Length - i - 1; j++)
            {
                if (_array[j] > _array[j + 1])
                {
                    Update(ref _array[j], ref _array[j + 1]);
                }
            }
        }

        return _array;
    }

    /// <summary>
    /// Swaps array elements.
    /// </summary>
    /// <param name="firstElement"> The first element. </param>
    /// <param name="lastElement"> The last element. </param>
    private static void Update(ref int firstElement, ref int lastElement)
    {
        (firstElement, lastElement) = (lastElement, firstElement);
    }

    /// <summary>
    /// Output information about the array to the console.
    /// </summary>
    public static void Print()
    {
        Console.Write("Array: ");
        foreach (var t in _array)
        {
            Console.Write($"{t} ");
        }

        Console.WriteLine($"\nMaximum element in the array: {SearchMaxElement()}\n" +
                          $"Minimum element in the array: {SearchMinElement()}\n");
    }
}