using Algorithms.Course.DataStructures.PriorityQueue;

namespace UnitTests;

public class PriorityQueueTests
{
    [Fact]
    public void Enqueue_SingleItem_CountIncreases()
    {
        var queue = new PriorityQueue<Person>();

        queue.Enqueue(new Person { Name = "Alice", Age = 30 });

        Assert.Equal(1, queue.Count);
    }

    [Fact]
    public void Enqueue_MultipleItems_CorrectOrder()
    {
        var queue = new PriorityQueue<Person>();
        var person1 = new Person { Name = "Alice", Age = 30 };
        var person2 = new Person { Name = "Bob", Age = 25 };
        var person3 = new Person { Name = "Carol", Age = 35 };

        queue.Enqueue(person1);
        queue.Enqueue(person2);
        queue.Enqueue(person3);

        Assert.Equal(person2, queue.Dequeue()); // Bob should be first (youngest)
        Assert.Equal(person1, queue.Dequeue()); // Then Alice
        Assert.Equal(person3, queue.Dequeue()); // Finally Carol
    }

    [Fact]
    public void Dequeue_EmptyQueue_ReturnsDefault()
    {
        var queue = new PriorityQueue<Person>();

        var result = queue.Dequeue();

        Assert.Null(result);
    }

    [Fact]
    public void Dequeue_ItemsExist_ReturnsItemAndDecreasesCount()
    {
        var queue = new PriorityQueue<Person>();
        var person = new Person { Name = "Alice", Age = 30 };
        queue.Enqueue(person);

        var dequeued = queue.Dequeue();

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
        queue.Enqueue(person);

        var peeked = queue.Peek();

        Assert.Equal(person, peeked);
        Assert.Equal(1, queue.Count); // Count should not change
    }
}