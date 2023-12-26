namespace Algorithms.Course.DataStructures.DoublyLinkedList;

public sealed class Node<T>(T val)
{
    public T Val { get; } = val;
    public Node<T>? Next { get; set; } = null;
    public Node<T>? Prev { get; set; } = null;
}