using System;
using System.Collections.Generic;
using System.Linq;
using LibraryDynamicArray;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryDynamicArrayTests;

[TestClass]
public class DynamicArrayTests
{
    private static DynamicArray<int> _array;

    /// <summary>
    /// Initialization of the array.
    /// </summary>
    /// <param name="context"> Context. </param>
    [ClassInitialize]
    public static void Init(TestContext context)
    {
        _array = new DynamicArray<int>() {1, 5, 15, 30, 50, 100};
    }

    /// <summary>
    /// Clearing the array.
    /// </summary>
    [TestCleanup]
    public void Clean()
    {
        _array = new DynamicArray<int>() {1, 5, 15, 30, 50, 100};
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }

    /// <summary>
    /// Default array constructor.
    /// </summary>
    [Ignore("Calls the constructor.")]
    [TestMethod()]
    public void DynamicArrayIgnoreTest()
    {
        Assert.Fail();
    }

    /// <summary>
    /// Creating an array with the default length.
    /// </summary>
    [TestMethod]
    public void DynamicArrayInitTest()
    {
        var array = new DynamicArray<object>();
        Assert.AreEqual(8, array.Capacity);
        Assert.AreEqual(0, array.Length);
    }

    /// <summary>
    /// Creating an array with a specified length.
    /// </summary>
    /// <param name="capacity"> Array length. </param>
    [TestMethod()]
    [DataRow(0)]
    [DataRow(1)]
    [DataRow(10)]
    [DataRow(100)]
    public void DynamicArrayCapacityTest(int capacity)
    {
        var array = new DynamicArray<int>(capacity);
        Assert.AreEqual(capacity, array.Capacity);
        Assert.AreEqual(0, array.Length);
    }

    /// <summary>
    /// Creating an array with a minimum value.
    /// </summary>
    [TestMethod()]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void DynamicArrayCapacityErrorTest()
    {
        new DynamicArray<int>(int.MinValue);
    }

    /// <summary>
    /// Creating an array with a null value.
    /// </summary>
    [TestMethod()]
    [ExpectedException(typeof(ArgumentNullException))]
    public void DynamicArrayNullTest()
    {
        _array = new DynamicArray<int>(null);
    }

    /// <summary>
    /// Adding a null value to the array.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void AddRangeExceptionTest()
    {
        _array.AddRange(null);
    }

    /// <summary>
    /// Adding elements that go beyond the boundaries of the array.
    /// </summary>
    /// <param name="index"> Element. </param>
    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    [DataRow(-1)]
    [DataRow(-2000)]
    [DataRow(100)]
    [DataRow(4000)]
    public void InsertExceptionTest(int index)
    {
        _array.Insert(index, index);
    }

    /// <summary>
    /// Adding collection values to the end of the array.
    /// </summary>
    /// <param name="collection"> Collection. </param>
    [TestMethod()]
    [DataRow(new[] {2, 4, 8, 64, 128})]
    [DataRow(new int[] {2, 4, 8})]
    [DataRow(new int[] {6, 10, 12, 56, 66, 96})]
    [DataRow(new int[] {100, 200, 300, 400})]
    [DataRow(new int[] {1000, 2000, 3000, 4000, 5000})]
    public void AddRangeTest(IEnumerable<int> collection)
    {
        var lastLength = _array.Length;
        _array.AddRange(collection);
        Assert.AreEqual(lastLength + collection.Count(), _array.Length);
    }

    /// <summary>
    /// Adding a single value to the array.
    /// </summary>
    /// <param name="value"> Value. </param>
    [TestMethod()]
    [DataRow(20)]
    [DataRow(-1000)]
    [DataRow(0)]
    [DataRow(150)]
    public void AddTest(int value)
    {
        _array.Add(value);
        Assert.AreEqual(_array[_array.Length - 1], value);
    }

    /// <summary>
    /// Deleting an element from the array.
    /// </summary>
    /// <param name="value"> Value. </param>
    [TestMethod()]
    [DataRow(15)]
    [DataRow(5)]
    [DataRow(30)]
    [DataRow(50)]
    public void RemoveTest(int value)
    {
        Assert.IsTrue(_array.Remove(value));
    }

    /// <summary>
    /// Adding an element to an arbitrary array position.
    /// </summary>
    /// <param name="value"> The element to add. </param>
    /// <param name="index"> Index of the element in the array. </param>
    [TestMethod()]
    [DataRow(111, 1)]
    [DataRow(222, 2)]
    [DataRow(333, 3)]
    [DataRow(444, 4)]
    [DataRow(555, 5)]
    public void InsertTest(int value, int index)
    {
        _array.Insert(value, index);
        Assert.AreEqual(value, _array[index]);
    }

    /// <summary>
    /// Comparing an instance of a class with another array.
    /// </summary>
    [TestMethod()]
    public void EqualsClassInstanceTest()
    {
        Assert.IsTrue(_array.Equals(new DynamicArray<int>() {1, 5, 15, 30, 50, 100}));
    }

    /// <summary>
    /// Checking for type equality.
    /// </summary>
    [TestMethod()]
    public void EqualsTypesTest()
    {
        var array = new DynamicArray<int>(new int[] {1, 5, 15, 30, 50, 100});
        Assert.IsTrue(_array.Equals(array));
    }

    /// <summary>
    /// Checking for inconsistency with equality of types.
    /// </summary>
    [TestMethod]
    public void EqualsWrongTypesTest()
    {
        var list = new List<int>(new int[] {1, 5, 15, 30, 50, 100});
        Assert.IsFalse(_array.Equals(list));
    }

    /// <summary>
    /// Array in string representation.
    /// </summary>
    [TestMethod()]
    public void ToStringTest()
    {
        Assert.AreEqual("1 5 15 30 50 100 ", _array.ToString());
    }
}