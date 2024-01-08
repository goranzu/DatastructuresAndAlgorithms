using Algorithms.Course.DataStructures.Queue;

namespace UnitTests.DataStructureTests;

public class DequeueTests
{
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
    public void delete_empty_queue_returns_default()
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