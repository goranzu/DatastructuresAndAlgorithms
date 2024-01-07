using Algorithms.Course.DataStructures.DoublyLinkedList;

namespace UnitTests.DataStructureTests;

public class DoublyLinkedListTests
{
    [Fact]
    public void TestAddFirst()
    {
        var linkedList = new DoublyLinkedList<int>();

        linkedList.AddFirst(1);
        linkedList.AddFirst(2);
        linkedList.AddFirst(3);

        Assert.Equal(3, linkedList.Count);
        Assert.Equal(3, linkedList.GetFirst());
        Assert.Equal(1, linkedList.GetLast());
        Assert.True(linkedList.Contains(2));
        Assert.False(linkedList.Contains(10));
    }

    [Fact]
    public void TestAddLast()
    {
        var linkedList = new DoublyLinkedList<int>();

        linkedList.AddLast(1);
        linkedList.AddLast(2);
        linkedList.AddLast(3);

        Assert.Equal(3, linkedList.Count);
        Assert.Equal(3, linkedList.GetLast());
        Assert.Equal(1, linkedList.GetFirst());
        Assert.True(linkedList.Contains(2));
        Assert.False(linkedList.Contains(10));
    }

    [Fact]
    public void TestInsertAt()
    {
        var list = new DoublyLinkedList<string>();
        list.AddFirst("apple");
        list.AddFirst("banana");
        list.AddFirst("cherry");

        list.InsertAt(2, "orange");


        Assert.Equal(4, list.Count);
        Assert.True(list.Contains("orange"));
        Assert.Equal("cherry", list.GetFirst());
        Assert.Equal("apple", list.GetLast());
        Assert.Equal("orange", list.GetAt(2));
    }

    [Fact]
    public void TestRemove()
    {
        var list = new DoublyLinkedList<string>();
        list.AddLast("apple");
        list.AddLast("banana");
        list.AddLast("cherry");

        list.Remove("banana");

        Assert.Equal(2, list.Count);
        Assert.False(list.Contains("banana"));
        Assert.Equal("apple", list.GetFirst());
        Assert.Equal("cherry", list.GetLast());
    }

    [Fact]
    public void TestRemoveFirst()
    {
        var list = new DoublyLinkedList<string>();
        list.AddFirst("apple");
        list.AddFirst("banana");
        list.AddFirst("cherry");

        var value = list.RemoveFirst();

        Assert.Equal(2, list.Count);
        Assert.False(list.Contains("cherry"));
        Assert.Equal("banana", list.GetFirst());
        Assert.Equal("apple", list.GetLast());
        Assert.Equal("cherry", value);
    }

    [Fact]
    public void TestRemoveLast()
    {
        var list = new DoublyLinkedList<string>();
        list.AddFirst("apple");
        list.AddFirst("banana");
        list.AddFirst("cherry");

        var value = list.RemoveLast();

        Assert.Equal(2, list.Count);
        Assert.False(list.Contains("apple"));
        Assert.Equal("cherry", list.GetFirst());
        Assert.Equal("banana", list.GetLast());
        Assert.Equal("apple", value);
    }

    [Fact]
    public void TestRemoveAt()
    {
        var list = new DoublyLinkedList<string>();

        list.AddFirst("apple");
        list.AddFirst("banana");
        list.AddFirst("cherry");

        list.RemoveAt(2);

        Assert.Equal(2, list.Count);
        Assert.False(list.Contains("apple"));
        Assert.Equal("cherry", list.GetFirst());
        Assert.Equal("banana", list.GetLast());
    }

    [Fact]
    public void TestGetFirst()
    {
        var list = new DoublyLinkedList<string>();

        list.AddFirst("apple");
        list.AddFirst("banana");
        list.AddFirst("cherry");

        var val = list.GetFirst();

        Assert.Equal(3, list.Count);
        Assert.Equal("cherry", val);
    }

    [Fact]
    public void TestGetLast()
    {
        var list = new DoublyLinkedList<string>();

        list.AddFirst("apple");
        list.AddFirst("banana");
        list.AddFirst("cherry");

        var val = list.GetLast();

        Assert.Equal(3, list.Count);
        Assert.Equal("apple", val);
    }

    [Fact]
    public void TestGetAt()
    {
        var list = new DoublyLinkedList<string>();

        list.AddFirst("apple");
        list.AddFirst("banana");
        list.AddFirst("cherry");

        var first = list.GetAt(0);
        var second = list.GetAt(1);
        var third = list.GetAt(2);

        Assert.Equal(3, list.Count);
        Assert.Equal("cherry", first);
        Assert.Equal("banana", second);
        Assert.Equal("apple", third);
    }

    [Fact]
    public void TestClear()
    {
        var list = new DoublyLinkedList<string>();

        list.AddFirst("apple");
        list.AddFirst("banana");
        list.AddFirst("cherry");

        list.Clear();

        Assert.Equal(0, list.Count);
        Assert.Null(list.GetFirst());
        Assert.Null(list.GetLast());
    }
}