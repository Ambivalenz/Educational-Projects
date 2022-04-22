using System.Collections;
using System.Text;

namespace LibraryDynamicArray;

public class DynamicArray<T> : IEnumerable<T>, IEnumerable
{
    /// <summary>
    /// Array of elements.
    /// </summary>
    private T[] _myArray;

    /// <summary>
    /// The initial capacity in the array.
    /// </summary>
    private const int DefaultCapacity = 8;

    /// <summary>
    /// The size of the array.
    /// </summary>
    public int Length;

    /// <summary>
    /// The capacity of the array.
    /// </summary>
    public int Capacity;

    /// <summary>
    /// Creates an array with the default length.
    /// </summary>
    public DynamicArray()
        : this(DefaultCapacity)
    {
    }

    /// <summary>
    /// Creates an array with the length specified by the user.
    /// </summary>
    /// <param name="capacity"> The length of the array. </param>
    public DynamicArray(int capacity)
    {
        if (capacity < 0)
        {
            throw new ArgumentOutOfRangeException("The length of the array cannot be negative!");
        }

        _myArray = new T[capacity];
        Capacity = capacity;
        Length = 0;
    }

    /// <summary>
    /// Creates an array based on the passed collection.
    /// </summary>
    /// <param name="collection"> Collection. </param>
    public DynamicArray(IEnumerable<T> collection)
    {
        _myArray = new T[Capacity];
        AddRange(collection);
    }

    /// <summary>
    /// Adds collection values to the end of the array.
    /// </summary>
    /// <param name="collection"> Collection. </param>
    public void AddRange(IEnumerable<T> collection)
    {
        if (collection == null)
        {
            throw new ArgumentNullException("The collection cannot be empty!");
        }

        var arr = collection.ToArray();

        if (Length + arr.Length >= Capacity)
        {
            IncreaseCapacity(Length + arr.Length + 1);
        }

        Array.Copy(arr, 0, _myArray, Length, arr.Length);
        Length += arr.Length;
    }

    /// <summary>
    /// Adds a single value to the end of the array.
    /// </summary>
    /// <param name="value"> Value to add. </param>
    public void Add(T value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("The value cannot be empty!");
        }

        AddRange(new T[] {value});
    }

    /// <summary>
    /// Deletes the specified item from the collection.
    /// </summary>
    /// <param name="value"> The item to delete. </param>
    /// <returns> True - deletion is successful. False - deletion failed. </returns>
    public bool Remove(T value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("The element cannot be empty!");
        }

        var index = Array.IndexOf(_myArray, value);
        Length--;

        if (index < Length)
        {
            Array.Copy(_myArray, index + 1, _myArray, index, Length - index);
            _myArray[Length] = default(T);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Adds an element to any position in the array.
    /// </summary>
    /// <param name="value"> Element. </param>
    /// <param name="index"> Index in the array. </param>
    /// <returns> True - deletion is successful. False - deletion failed. </returns>
    public bool Insert(T value, int index)
    {
        if (value == null)
        {
            throw new ArgumentNullException("The element cannot be empty!");
        }

        if ((index <= 0) || (index > Length))
        {
            throw new ArgumentOutOfRangeException("The index is outside the bounds of the array!");
        }

        if (Length == _myArray.Length)
        {
            IncreaseCapacity(Length + 1);
        }

        try
        {
            for (var i = 0; i > index; i++)
            {
                _myArray[i] = _myArray[i - 1];
            }

            Capacity++;
            _myArray[index] = value;
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    /// <summary>
    /// Checks the equality of types.
    /// </summary>
    /// <param name="obj"> Object to compare. </param>
    /// <returns> The result of the comparison. </returns>
    public override bool Equals(object obj)
    {
        return Equals(obj as DynamicArray<T>);
    }

    /// <summary>
    /// Compares an instance of a class with another array.
    /// </summary>
    /// <param name="array"></param>
    /// <returns> The result of the comparison. </returns>
    public bool Equals(DynamicArray<T> array)
    {
        if (array == null || _myArray == null)
        {
            return false;
        }

        if (Length != array.Length)
        {
            return false;
        }

        for (var i = 0; i < Length; i++)
        {
            if (!_myArray[i]!.Equals(array._myArray[i]))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Overriding the array method to a string.
    /// </summary>
    /// <returns> Returns an array as a string. </returns>
    public override string ToString()
    {
        var str = new StringBuilder();

        for (var i = 0; i < Length; i++)
        {
            str.Append($"{_myArray[i]} ");
        }

        return str.ToString();
    }

    public IEnumerator GetEnumerator()
    {
        return _myArray.GetEnumerator();
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return ((IEnumerable<T>) _myArray).GetEnumerator();
    }

    /// <summary>
    /// Getting an element by index in an array.
    /// </summary>
    /// <param name="index"> Index. </param>
    /// <returns> An array element. </returns>
    public T this[int index]
    {
        get
        {
            if (!IsIndex(index))
            {
                throw new ArgumentOutOfRangeException("The index is out of range!");
            }

            return _myArray[index];
        }
        set
        {
            if (!IsIndex(index))
            {
                throw new ArgumentOutOfRangeException("The index is out of range!");
            }

            _myArray[index] = value;
        }
    }

    /// <summary>
    /// Increasing the size of the array.
    /// </summary>
    /// <param name="min"> Minimum value. </param>
    private void IncreaseCapacity(int min)
    {
        var newCapacity = _myArray.Length == 0
            ? DefaultCapacity
            : _myArray.Length * 2;

        if ((uint) newCapacity > int.MaxValue)
        {
            newCapacity = int.MaxValue;
        }

        if (newCapacity < min)
        {
            newCapacity = min;
        }

        Array.Resize(ref _myArray, newCapacity);
    }

    /// <summary>
    /// Checking whether the index is within the bounds of the array.
    /// </summary>
    /// <param name="index"> Index.</param>
    /// <returns> True - if the index is included. False - not included. </returns>
    private bool IsIndex(int index)
    {
        return (uint) index < (uint) Length;
    }
}