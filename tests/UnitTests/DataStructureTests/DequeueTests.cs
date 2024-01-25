using Algorithms.Course.DataStructures.Queue;
using Newtonsoft.Json;
using UnitTests.SortingTests;

namespace UnitTests.DataStructureTests;

public class DequeueTests
{
    private SortingData _sortingData;

    public DequeueTests()
    {
        using StreamReader reader = new("./Data/sortingData.json");
        var json = reader.ReadToEnd();
        var data = JsonConvert.DeserializeObject<SortingData>(json);
        _sortingData = data!;
    }

    [Fact]
    public void DeleteLeftFromData()
    {
        var deq = new Dequeue<int>();
        foreach (var item in _sortingData.lijst_gesorteerd_aflopend_3)
        {
            deq.InsertRight(item);
        }
        Assert.Equal(3, deq.Count);
        
        var result = deq.DeleteLeft();
        Assert.Equal(3, result);
        
        result = deq.DeleteLeft();
        Assert.Equal(2, result);
        
        result = deq.DeleteLeft();
        Assert.Equal(1, result);
    }

    [Fact]
    public void DeleteRightFromData()
    {
        var deq = new Dequeue<int>();
        foreach (var item in _sortingData.lijst_gesorteerd_aflopend_3)
        {
            deq.InsertLeft(item);
        }
        
        Assert.Equal(3, deq.Count);
        
        var result = deq.DeleteRight();
        Assert.Equal(3, result);
        
        result = deq.DeleteRight();
        Assert.Equal(2, result);
        
        result = deq.DeleteRight();
        Assert.Equal(1, result);
    }
    
    [Fact]
    public void insert_left_should_insert_items_correctly()
    {
        var deq = new Dequeue<int>();
        deq.InsertLeft(1);
        
        Assert.Equal(1, deq.Count);

        var result = deq.DeleteLeft();
        
        Assert.Equal(1, result);
    }
    
    [Fact]
    public void insert_right_should_insert_items_correctly()
    {
        var deq = new Dequeue<int?>();
        deq.InsertRight(1);
        deq.InsertRight(2);
        
        Assert.Equal(2, deq.Count);

        var result = deq.DeleteRight();
        
        Assert.Equal(2, result);
        Assert.Equal(1, deq.Count);
    }
    
    [Fact]
    public void delete_left_removes_and_returns_correct_item()
    {
        var deq = new Dequeue<int>();
        deq.InsertLeft(1);
        deq.InsertLeft(2);
        
        Assert.Equal(2, deq.DeleteLeft());
        Assert.Equal(1, deq.DeleteLeft());
    }
    
    [Fact]
    public void delete_right_removes_and_returns_correct_item()
    {
        var deq = new Dequeue<int>();
        deq.InsertLeft(1);
        deq.InsertLeft(2);
        
        Assert.Equal(1, deq.DeleteRight());
        Assert.Equal(2, deq.DeleteRight());
    }
    
    [Fact]
    public void multiple_insertions_and_deletions_should_behave_correctly()
    {
        var deq = new Dequeue<int>();
        deq.InsertLeft(1);
        deq.InsertRight(2);
        deq.InsertLeft(3);
        
        Assert.Equal(3, deq.DeleteLeft());
        Assert.Equal(2, deq.DeleteRight());
        Assert.Equal(1, deq.DeleteLeft());
        Assert.Equal(0, deq.Count);
    }
}