using Algorithms.Course.DataStructures.PriorityQueue;
using Newtonsoft.Json;
using UnitTests.SortingTests;

namespace UnitTests.DataStructureTests;

public class PriorityQueueTests
{
    private SortingData _sortingData;

    public PriorityQueueTests()
    {
        using StreamReader reader = new("./Data/sortingData.json");
        var json = reader.ReadToEnd();
        var data = JsonConvert.DeserializeObject<SortingData>(json);
        _sortingData = data!;
    }

    [Fact]
    public void Add_SingleItem_CountIncreases()
    {
        var testData = _sortingData.lijst_willekeurig_3;
        var queue = new PriorityQueue<int>();

        // queue.Add(new Person { Name = "Alice", Age = 30 });
        queue.Add(testData[0]);

        Assert.Equal(1, queue.Count);
    }

    [Fact]
    public void Add_MultipleItems_CorrectOrder()
    {
        var testData = _sortingData.lijst_willekeurig_3;
        var queue = new PriorityQueue<int>();
        // var queue = new PriorityQueue<Person>();
        // var person1 = new Person { Name = "Alice", Age = 30 };
        // var person2 = new Person { Name = "Bob", Age = 25 };
        // var person3 = new Person { Name = "Carol", Age = 35 };

        queue.Add(testData[0]);
        queue.Add(testData[1]);
        queue.Add(testData[2]);

        Assert.Equal(1, queue.Poll()); 
        Assert.Equal(2, queue.Poll());
        Assert.Equal(3, queue.Poll());
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
        var testData = _sortingData.lijst_willekeurig_3;
        var queue = new PriorityQueue<int>();
        // var queue = new PriorityQueue<Person>();
        // var person = new Person { Name = "Alice", Age = 30 };
        // queue.Add(person);
        queue.Add(testData[0]);

        var dequeued = queue.Poll();

        Assert.Equal(1, dequeued);
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