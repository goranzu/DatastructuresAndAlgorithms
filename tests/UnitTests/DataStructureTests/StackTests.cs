using Newtonsoft.Json;
using UnitTests.SortingTests;

namespace UnitTests.DataStructureTests;

public class StackTests
{
    private SortingData _sortingData;

    public StackTests()
    {
        using StreamReader reader = new("./Data/sortingData.json");
        var json = reader.ReadToEnd();
        var data = JsonConvert.DeserializeObject<SortingData>(json);
        _sortingData = data!;
    }
    
    [Fact]
    public void TestPush()
    {
        var testData = _sortingData.lijst_willekeurig_3;
        var stack = new Stack<int>();
        stack.Push(testData[0]);
        stack.Push(testData[1]);
        stack.Push(testData[2]);
        
        Assert.Equal(3, stack.Count);
        Assert.Equal(testData[2], stack.Peek());
        // var stack = new Stack<string>();
        //
        // stack.Push("banana");
        // stack.Push("cherry");
        // stack.Push("apple");
        //
        // Assert.Equal(3, stack.Count);
        // Assert.Equal("apple", stack.Peek());
    }

    [Fact]
    public void TestPeek()
    {
        var testData = _sortingData.lijst_willekeurig_3;
        var stack = new Stack<int>();
        stack.Push(testData[0]);
        stack.Push(testData[1]);
        stack.Push(testData[2]);
        
        Assert.Equal(testData[2], stack.Peek());
        
        // var stack = new Stack<string>();
        //
        // stack.Push("banana");
        // stack.Push("cherry");
        // stack.Push("apple");
        //
        // Assert.Equal("apple", stack.Peek());
    }

    [Fact]
    public void TestPop()
    {
        var testData = _sortingData.lijst_willekeurig_3;
        var stack = new Stack<int>();
        stack.Push(testData[0]);
        stack.Push(testData[1]);
        stack.Push(testData[2]);
        
        var first = stack.Pop();
        var second = stack.Pop();
        var third = stack.Pop();
        
        Assert.Equal(testData[2], first);
        Assert.Equal(testData[1], second);
        Assert.Equal(testData[0], third);
        
        
        // var stack = new Stack<string>();
        //
        // stack.Push("banana");
        // stack.Push("cherry");
        // stack.Push("apple");
        //
        // var first = stack.Pop();
        // var second = stack.Pop();
        // var third = stack.Pop();
        //
        // Assert.Empty(stack);
        // Assert.Equal("apple", first);
        // Assert.Equal("cherry", second);
        // Assert.Equal("banana", third);
    }
}