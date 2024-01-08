using Algorithms.Course.DataStructures.PriorityQueue;

namespace UnitTests.DataStructureTests;

public class PriorityQueueTests
{
    [Fact]
    public void Add_SingleItem_CountIncreases()
    {
        var queue = new PriorityQueue<Person>();

        queue.Add(new Person { Name = "Alice", Age = 30 });

        Assert.Equal(1, queue.Count);
    }

    [Fact]
    public void Add_MultipleItems_CorrectOrder()
    {
        var queue = new PriorityQueue<Person>();
        var person1 = new Person { Name = "Alice", Age = 30 };
        var person2 = new Person { Name = "Bob", Age = 25 };
        var person3 = new Person { Name = "Carol", Age = 35 };

        queue.Add(person1);
        queue.Add(person2);
        queue.Add(person3);

        Assert.Equal(person2, queue.Poll()); // Bob should be first (youngest)
        Assert.Equal(person1, queue.Poll()); // Then Alice
        Assert.Equal(person3, queue.Poll()); // Finally Carol
    }

    [Fact]
    public void Poll_EmptyQueue_ReturnsDefault()
    {
        var queue = new PriorityQueue<Person>();

        var result = queue.Poll();

        Assert.Null(result);
    }

    [Fact]
    public void Poll_ItemsExist_ReturnsItemAndDecreasesCount()
    {
        var queue = new PriorityQueue<Person>();
        var person = new Person { Name = "Alice", Age = 30 };
        queue.Add(person);

        var dequeued = queue.Poll();

        Assert.Equal(person, dequeued);
        Assert.Equal(0, queue.Count);
    }

    [Fact]
    public void Peek_EmptyQueue_ReturnsDefault()
    {
        var queue = new PriorityQueue<Person>();

        var result = queue.Peek();

        Assert.Null(result);
    }

    [Fact]
    public void Peek_ItemsExist_ReturnsHeadWithoutRemoving()
    {
        var queue = new PriorityQueue<Person>();
        var person = new Person { Name = "Alice", Age = 30 };
        queue.Add(person);

        var peeked = queue.Peek();

        Assert.Equal(person, peeked);
        Assert.Equal(1, queue.Count);
    }
}