using Algorithms.Course.DataStructures;
using Newtonsoft.Json;
using UnitTests.SortingTests;

namespace UnitTests.DataStructureTests;

public class AvlTests
{
    private SortingData _sortingData;
    
    public AvlTests()
    {
        using StreamReader reader = new("./Data/sortingData.json");
        var json = reader.ReadToEnd();
        var data = JsonConvert.DeserializeObject<SortingData>(json);
        _sortingData = data!;
    }
    
    [Fact]
    public void TestAvlLijstAflopend()
    {
        var avlTree = new AvlGeneric<int>();

        var list = _sortingData.lijst_aflopend_2;
        
        foreach (var item in list)
        {
            avlTree.Insert(item);
        }
        
        Assert.NotNull(avlTree);

        var minimum = avlTree.FindMin();
        Assert.Equal(-10033224, minimum);

        var max = avlTree.FindMax();
        Assert.Equal(1, max);

        var find = avlTree.Find(-10033224);
        Assert.Equal(-10033224, find);
        
        avlTree.Remove(-10033224);
        
        var findNot = avlTree.Find(-10033224);
        Assert.Equal(default, findNot);
    }
    
    [Fact]
    public void TestAvlLijstWillekeurig()
    {
        var avlTree = new AvlGeneric<int>();

        var list = _sortingData.lijst_willekeurig_10000;
        
        foreach (var item in list)
        {
            avlTree.Insert(item);
        }

        Assert.NotNull(avlTree);
        
        var find = avlTree.Find(5877);
        
        Assert.Equal(5877, find);
        
        avlTree.Remove(5877);
        Assert.Equal(default, avlTree.Find(5877));
    }
}