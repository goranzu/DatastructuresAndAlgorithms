using Algorithms.Course.DataStructures.DynamicArray;

namespace UnitTests.DataStructureTests;

public class DynamicArrayTests
{
    [Fact]
    public void TestAdd()
    {
        var list = new DynamicArray<string>();

        list.Add("cherry");
        list.Add("banana");
        list.Add("apple");

        Assert.Equal(10, list.Capacity);
        Assert.Equal(3, list.Count);
        Assert.Equal("cherry", list[0]);
        Assert.Equal("banana", list[1]);
        Assert.Equal("apple", list[2]);
    }

    [Fact]
    public void TestInsertAt()
    {
        var list = new DynamicArray<string>();

        list.Add("cherry");
        list.Add("banana");
        list.Add("apple");

        list.InsertAt(1, "orange");

        Assert.Equal(4, list.Count);
        Assert.Equal("cherry", list[0]);
        Assert.Equal("orange", list[1]);
        Assert.Equal("banana", list[2]);
        Assert.Equal("apple", list[3]);
    }

    [Fact]
    public void TestIndexOf()
    {
        var list = new DynamicArray<string>();

        list.Add("cherry");
        list.Add("banana");
        list.Add("apple");

        Assert.Equal(3, list.Count);
        Assert.Equal(0, list.IndexOf("cherry"));
        Assert.Equal(1, list.IndexOf("banana"));
        Assert.Equal(2, list.IndexOf("apple"));
    }

    [Fact]
    public void TestGet()
    {
        var list = new DynamicArray<string>();

        list.Add("cherry");
        list.Add("banana");
        list.Add("apple");

        Assert.Equal("cherry", list.Get(0));
        Assert.Equal("banana", list.Get(1));
        Assert.Equal("apple", list.Get(2));
    }

    [Fact]
    public void TestFind()
    {
        var list = new DynamicArray<string>();

        list.Add("cherry");
        list.Add("banana");
        list.Add("apple");

        Assert.Equal("cherry", list.Find("cherry"));
        Assert.Equal("banana", list.Find("banana"));
        Assert.Equal("apple", list.Find("apple"));
    }

    [Fact]
    public void TestContains()
    {
        var list = new DynamicArray<string>();

        list.Add("cherry");
        list.Add("banana");
        list.Add("apple");

        Assert.True(list.Contains("cherry"));
        Assert.True(list.Contains("banana"));
        Assert.True(list.Contains("apple"));
        Assert.False(list.Contains("orange"));
    }

    [Fact]
    public void TestRemove()
    {
        var list = new DynamicArray<string>();

        list.Add("cherry");
        list.Add("banana");
        list.Add("apple");

        list.Remove("cherry");

        Assert.Equal(2, list.Count);
        Assert.Equal("banana", list[0]);
        Assert.Equal("apple", list[1]);
    }
    
    [Fact]
    public void TestRemoveAt()
    {
        var list = new DynamicArray<string>();

        list.Add("cherry");
        list.Add("banana");
        list.Add("apple");

        list.RemoveAt(0);

        Assert.Equal(2, list.Count);
        Assert.Equal("banana", list[0]);
        Assert.Equal("apple", list[1]);
    }
}