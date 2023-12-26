using Algorithms.Course.DataStructures.PriorityQueue;

namespace UnitTests;

public class StackTests
{
    [Fact]
    public void TestPush()
    {
        var stack = new Stack<string>();

        stack.Push("banana");
        stack.Push("cherry");
        stack.Push("apple");

        Assert.Equal(3, stack.Count);
        Assert.Equal("apple", stack.Peek());
    }

    [Fact]
    public void TestPeek()
    {
        var stack = new Stack<string>();

        stack.Push("banana");
        stack.Push("cherry");
        stack.Push("apple");

        Assert.Equal("apple", stack.Peek());
    }

    [Fact]
    public void TestPop()
    {
        var stack = new Stack<string>();

        stack.Push("banana");
        stack.Push("cherry");
        stack.Push("apple");

        var first = stack.Pop();
        var second = stack.Pop();
        var third = stack.Pop();

        Assert.Empty(stack);
        Assert.Equal("apple", first);
        Assert.Equal("cherry", second);
        Assert.Equal("banana", third);
    }
}