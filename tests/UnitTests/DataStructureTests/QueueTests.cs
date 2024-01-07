namespace UnitTests.DataStructureTests;

public class QueueTests
{
    [Fact]
    public void TestEnqueue()
    {
        var queue = new Queue<string>();

        queue.Enqueue("banana");
        queue.Enqueue("cherry");
        queue.Enqueue("apple");

        Assert.Equal(3, queue.Count);
    }

    [Fact]
    public void TestPeek()
    {
        var queue = new Queue<string>();

        queue.Enqueue("banana");
        queue.Enqueue("cherry");
        queue.Enqueue("apple");

        Assert.Equal("banana", queue.Peek());
    }

    [Fact]
    public void TestDequeue()
    {
        var queue = new Queue<string>();

        queue.Enqueue("banana");
        queue.Enqueue("cherry");
        queue.Enqueue("apple");

        var first = queue.Dequeue();
        var second = queue.Dequeue();
        var third = queue.Dequeue();

        Assert.Empty(queue);
        Assert.Equal("banana", first);
        Assert.Equal("cherry", second);
        Assert.Equal("apple", third);
    }
}