using System.Text;

namespace LibraryDelegates;

public sealed class SortingArbitraryArray
{
    #region Events and delegates.

    /// <summary>
    /// Array sorting start event.
    /// </summary>
    public event EventHandler<EventArgs> SortStart;

    /// <summary>
    /// End of array sorting event.
    /// </summary>
    public event Action SortFinish;

    #endregion

    #region Events of the beginning and end of array sorting.

    /// <summary>
    /// Calling the array sorting start event.
    /// </summary>
    private void OnSortStart()
    {
        SortStart?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// Calling the end of array sorting event.
    /// </summary>
    private void OnSortFinish()
    {
        SortFinish?.Invoke();
    }

    #endregion

    #region Methods for working with an array.

    /// <summary>
    /// Sorting the array.
    /// </summary>
    /// <param name="array"> Array..</param>
    /// <param name="correlate"> Comparison of two elements. </param>
    /// <returns> Sorted array. </returns>
    public T[] SortArray<T>(T[] array, Func<T, T, bool> correlate)
    {
        if (array == null)
        {
            throw new ArgumentNullException($"The array - {array} cannot be empty!");
        }

        if (correlate == null)
        {
            throw new ArgumentNullException($"The delegate - {correlate} cannot be empty!");
        }

        OnSortStart();

        for (var i = 0; i < array.Length; i++)
        {
            for (var j = 0; i < array.Length; i++)
            {
                if (correlate(array[j], array[j + 1]))
                {
                    Swap(ref array[j], ref array[j + 1]);
                }
            }
        }

        OnSortFinish();

        return array;
    }

    /// <summary>
    /// Swaps the elements.
    /// </summary>
    /// <param name="firstElement">The first element.</param>
    /// <param name="lastElement">The last element.</param>
    private static void Swap<T>(ref T firstElement, ref T lastElement)
    {
        (firstElement, lastElement) = (lastElement, firstElement);
    }

    /// <summary>
    /// Forms an array in a string representation.
    /// </summary>
    /// <typeparam name="T"> Type..</typeparam>
    /// <param name="array"> Array.</param>
    /// <returns> Array as a string. </returns>
    public static string PrintArray<T>(T[] array)
    {
        if (array == null)
        {
            throw new ArgumentNullException($"The array - {array} cannot be empty!");
        }

        var str = new StringBuilder();

        for (var i = 0; i < array.Length; i++)
        {
            str.Append($"{i} ");
        }

        return str.ToString();
    }

    #endregion
}