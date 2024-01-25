namespace Algorithms.Course.DataStructures;

public interface IAvlTreeGeneric<T> where T : IComparable<T>
{
    void Insert(T value);
    void Remove(T value);
    T? FindMin();
    T? FindMax();
    T? Find(T value);
}

public class AvlGeneric<T> : IAvlTreeGeneric<T> where T : IComparable<T>
{
    public class Node : IComparable<Node>
    {
        public T Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Height { get; set; }

        public Node(T value)
        {
            Value = value;
            Height = 0;
        }

        public int CompareTo(Node other)
        {
            return Value.CompareTo(other.Value);
        }
    }
    
    private Node _root;
    
    public void Insert(T value)
    {
       _root = Insert(_root, value); 
    }
    
    private Node Insert(Node node, T value)
    {
        if (node is null)
        {
            return new Node(value);
        }

        if (value.CompareTo(node.Value) < 0)
        {
            node.Left = Insert(node.Left, value);
        }
        else if (value.CompareTo(node.Value) > 0)
        {
            node.Right = Insert(node.Right, value);
        }
        else
        {
            return node;
        }

        node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;

        var balance = GetBalance(node);

        if (balance > 1 && value.CompareTo(node.Left.Value) < 0)
        {
            return RightRotate(node);
        }

        if (balance < -1 && value.CompareTo(node.Right.Value) > 0)
        {
            return LeftRotate(node);
        }

        if (balance > 1 && value.CompareTo(node.Left.Value) > 0)
        {
            node.Left = LeftRotate(node.Left);
            return RightRotate(node);
        }

        if (balance < -1 && value.CompareTo(node.Right.Value) < 0)
        {
            node.Right = RightRotate(node.Right);
            return LeftRotate(node);
        }

        return node;
    }
    

    public void Remove(T value)
    {
        _root = Remove(_root, value);
    }

    private Node Remove(Node node, T value)
    {
        if (node is null)
        {
            return node;
        }

        if (value.CompareTo(node.Value) < 0)
        {
            node.Left = Remove(node.Left, value);
        }
        else if (value.CompareTo(node.Value) > 0)
        {
            node.Right = Remove(node.Right, value);
        }
        else
        {
            if (node.Left is null || node.Right is null)
            {
                node = node.Left ?? node.Right;
            }
            else
            {
                var temp = FindMin(node.Right);
                node.Value = temp.Value;
                node.Right = Remove(node.Right, temp.Value);
            }
        }

        if (node is null)
        {
            return node;
        }

        node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;

        var balance = GetBalance(node);

        if (balance > 1 && GetBalance(node.Left) >= 0)
        {
            return RightRotate(node);
        }

        if (balance > 1 && GetBalance(node.Left) < 0)
        {
            node.Left = LeftRotate(node.Left);
            return RightRotate(node);
        }

        if (balance < -1 && GetBalance(node.Right) <= 0)
        {
            return LeftRotate(node);
        }

        if (balance < -1 && GetBalance(node.Right) > 0)
        {
            node.Right = RightRotate(node.Right);
            return LeftRotate(node);
        }

        return node;
    }

    public T? FindMin()
    {
        var node = FindMin(_root);
        return node is null ? default : node.Value;
    }
    
    private Node FindMin(Node node)
    {
        return node.Left is null ? node : FindMin(node.Left);
    }

    public T? FindMax()
    {
        var node = FindMax(_root);
        return node is null ? default : node.Value;
    }
    
    private Node FindMax(Node node)
    {
        return node.Right is null ? node : FindMax(node.Right);
    }

    public T? Find(T value)
    {
        var node = Find(_root, value);
        return node is null ? default : node.Value;
    }
    
    private Node Find(Node node, T value)
    {
        if (node is null)
        {
            return null;
        }

        if (value.CompareTo(node.Value) < 0)
        {
            return Find(node.Left, value);
        }

        if (value.CompareTo(node.Value) > 0)
        {
            return Find(node.Right, value);
        }

        return node;
    }
    
    private int GetBalance(Node node)
    {
        return node is null ? 0 : Height(node.Left) - Height(node.Right);
    }
    
    private int Height(Node node)
    {
        return node is null ? -1 : node.Height;
    }
    
    private int Balance(Node node)
    {
        return node is null ? 0 : Height(node.Left) - Height(node.Right);
    }
    
    private Node RightRotate(Node node)
    {
        var left = node.Left;
        var right = left.Right;

        left.Right = node;
        node.Left = right;

        node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;
        left.Height = Math.Max(Height(left.Left), Height(left.Right)) + 1;

        return left;
    }
    
    private Node LeftRotate(Node node)
    {
        var right = node.Right;
        var left = right.Left;

        right.Left = node;
        node.Right = left;

        node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;
        right.Height = Math.Max(Height(right.Left), Height(right.Right)) + 1;

        return right;
    }
}