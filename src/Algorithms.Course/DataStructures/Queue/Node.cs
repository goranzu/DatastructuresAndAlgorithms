namespace Algorithms.Course.DataStructures.Queue;

public sealed class Node<T>(T value)
{
    public T Value { get; } = value;
    public Node<T>? Next { get; set; } = null;
}