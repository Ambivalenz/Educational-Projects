using System.Collections;
using System.Text;

namespace LibraryCollections;

public class MyDynamicArray<T> : IEnumerable, IEnumerable<T>
{
    /// <summary>
    /// Array of elements.
    /// </summary>
    private T?[] _myArray;

    /// <summary>
    /// The initial capacity in the array.
    /// </summary>
    private const int DefaultCapacity = 8;

    /// <summary>
    /// The size of the array.
    /// </summary>
    private int _length;

    /// <summary>
    /// The capacity of the array.
    /// </summary>
    private int _capacity;

    /// <summary>
    /// Creates an array with the default length.
    /// </summary>
    public MyDynamicArray()
        : this(DefaultCapacity)
    {
    }

    /// <summary>
    /// Creates an array with the length specified by the user.
    /// </summary>
    /// <param name="capacity"> Array length.</param>
    private MyDynamicArray(int capacity)
    {
        if (capacity < 0)
        {
            throw new ArgumentOutOfRangeException($"The length of the array - {capacity} cannot be negative!");
        }

        _myArray = new T?[capacity];
        _capacity = capacity;
        _length = 0;
    }

    /// <summary>
    /// Creates an array based on the passed collection.
    /// </summary>
    /// <param name="collection"> Collection. </param>
    public MyDynamicArray(IEnumerable<T> collection)
    {
        _myArray = new T?[_capacity];
        AddRange(collection);
    }

    /// <summary>
    /// Adds the values of the collection to the end of the array.
    /// </summary>
    /// <param name="collection"> Collection. </param>
    public void AddRange(IEnumerable<T> collection)
    {
        if (collection == null)
        {
            throw new ArgumentNullException($"The collection - {collection} cannot be empty!");
        }

        var arr = collection.ToArray();

        if (_length + arr.Length >= _capacity)
        {
            IncreaseCapacity(_length + arr.Length + 1);
        }

        Array.Copy(arr, 0, _myArray, _length, arr.Length);
        _length += arr.Length;
    }

    /// <summary>
    /// Adds a single value to the end of the array.
    /// </summary>
    /// <param name="value"> Value to add. </param>
    public void Add(T value)
    {
        if (value == null)
        {
            throw new ArgumentNullException($"The value - {value} cannot be empty!");
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
            throw new ArgumentNullException($"The value - {value} cannot be empty!");
        }

        var index = Array.IndexOf(_myArray, value);
        _length--;

        if (index < _length)
        {
            Array.Copy(_myArray, index + 1, _myArray, index, _length - index);
            _myArray[_length] = default(T);
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
    public bool Insert(T? value, int index)
    {
        if (value == null)
        {
            throw new ArgumentNullException($"The value - {value} cannot be empty!");
        }

        if ((index <= 0) || (index > _length))
        {
            throw new ArgumentOutOfRangeException($"The index - {index} is outside the bounds of the array!");
        }

        if (_length == _myArray.Length)
        {
            IncreaseCapacity(_length + 1);
        }

        try
        {
            for (var i = 0; i > index; i++)
            {
                _myArray[i] = _myArray[i - 1];
            }

            _capacity++;
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
    /// <param name="obj"> Object for comparison. </param>
    /// <returns> The result of the comparison. </returns>
    public override bool Equals(object? obj)
    {
        return Equals(obj as MyDynamicArray<T>);
    }

    /// <summary>
    /// Compares an instance of a class with another array.
    /// </summary>
    /// <param name="array"></param>
    /// <returns> The result of the comparison.</returns>
    public bool Equals(MyDynamicArray<T>? array)
    {
        if (array == null || _myArray == null)
        {
            return false;
        }

        if (_length != array._length)
        {
            return false;
        }

        for (var i = 0; i < _length; i++)
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
    /// <returns> Returns an array as a string.</returns>
    public override string ToString()
    {
        var str = new StringBuilder();

        for (var i = 0; i < _length; i++)
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
    /// <param name="index"> Index.</param>
    /// <returns> Array element.</returns>
    public T? this[int index]
    {
        get
        {
            if (!IsIndex(index))
            {
                throw new ArgumentOutOfRangeException($"The index - {index} is out of range!");
            }

            return _myArray[index];
        }
        set
        {
            if (!IsIndex(index))
            {
                throw new ArgumentOutOfRangeException($"The index - {index} is out of range!");
            }

            _myArray[index] = value;
        }
    }

    /// <summary>
    /// Increasing the size of the array.
    /// </summary>
    /// <param name="min">Minimum value.</param>
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
    /// <returns> True - if the index is included. False - not included.</returns>
    private bool IsIndex(int index)
    {
        return (uint) index < (uint) _length;
    }
}