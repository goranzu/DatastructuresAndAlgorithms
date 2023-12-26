namespace Algorithms.Course.DataStructures.Stack;

internal sealed class Node<T>(T value)
{
    public T Value { get; set; } = value;
    public Node<T>? Prev { get; set; } = null;
}