using Algorithms.Course;
using Newtonsoft.Json;

namespace UnitTests.SortingTests;

public class SelectionSortTests
{
    private SortingData _sortingData;

    public SelectionSortTests()
    {
        using StreamReader reader = new("./Data/sortingData.json");
        var json = reader.ReadToEnd();
        var data = JsonConvert.DeserializeObject<SortingData>(json);
        _sortingData = data!;
    }

    [Fact]
    public void selection_sort_should_correctly_sort_an_unsorted_array()
    {
        // making copies is necessary for the test to work
        var testData = _sortingData.lijst_gesorteerd_aflopend_3.ToArray();
        var expected = _sortingData.lijst_gesorteerd_oplopend_3.ToArray();

        SelectionSort.Sort(testData);

        Assert.Equal(expected, testData);
    }

    [Fact]
    public void selection_sort_should_not_modify_an_already_sorted_array()
    {
        var testData = _sortingData.lijst_oplopend_10000.ToArray();
        var expected = _sortingData.lijst_oplopend_10000.ToArray();

        SelectionSort.Sort(testData);

        Assert.Equal(expected, testData);
    }

    [Fact]
    public void selection_sort_should_sort_descending_lists()
    {
        int[] testData = _sortingData.lijst_aflopend_2.ToArray();
        SelectionSort.Sort(testData);
        Assert.Equal([-10033224, 1], testData);
    }

    [Fact]
    public void selection_sort_should_sort_ascending_lists()
    {
        int[] testData = _sortingData.lijst_oplopend_2.ToArray();
        SelectionSort.Sort(testData);
        Assert.Equal([-100324, 1023], testData);
    }

    [Fact]
    public void selection_sort_should_sort_float_lists()
    {
        float[] testData = _sortingData.lijst_float_8001.ToArray();
        SelectionSort.Sort(testData);

        // Sort with the standard library
        float[] expected = testData.ToArray();
        Array.Sort(expected);

        Assert.Equal(expected, testData);
    }

    [Fact]
    public void selection_sort_should_sort_empty_lists()
    {
        int[] testData = _sortingData.lijst_leeg_0.ToArray();
        SelectionSort.Sort(testData);
        Assert.Empty(testData);
    }

    [Fact]
    public void selection_sort_should_sort_single_element_lists()
    {
        int[] testData = [1];
        SelectionSort.Sort(testData);
        Assert.Equal([1], testData);
    }

    [Fact]
    public void selection_sort_should_sort_single_null_lists()
    {
        var testData = _sortingData.lijst_null_1.ToArray();
        SelectionSort.Sort(testData);
        Assert.Equal(new int?[] { null }, testData);
    }

    [Fact]
    public void selection_sort_should_sort_list_with_int_and_null()
    {
        // null is treated as the lowest value
        var testData = _sortingData.lijst_null_3.ToArray();
        SelectionSort.Sort(testData);
        Assert.Equal(new int?[] { null, 1, 3 }, testData);
    }
}