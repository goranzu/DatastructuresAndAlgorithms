using Algorithms.Course;
using Newtonsoft.Json;

namespace UnitTests.SortingTests;

public class MergeSortTests
{
    private SortingData _sortingData;

    public MergeSortTests()
    {
        using StreamReader reader = new("./Data/sortingData.json");
        var json = reader.ReadToEnd();
        var data = JsonConvert.DeserializeObject<SortingData>(json);
        _sortingData = data!;
    }

    [Fact]
    public void merge_sort_should_correctly_sort_an_unsorted_array()
    {
        // making copies is necessary for the test to work
        var testData = _sortingData.lijst_gesorteerd_aflopend_3.ToArray();
        var expected = _sortingData.lijst_gesorteerd_oplopend_3.ToArray();

        MergeSort.Sort(testData, 0, testData.Length);

        Assert.Equal(expected, testData);
    }

    [Fact]
    public void merge_sort_should_not_modify_an_already_sorted_array()
    {
        var testData = _sortingData.lijst_oplopend_10000.ToArray();
        var expected = _sortingData.lijst_oplopend_10000.ToArray();

        MergeSort.Sort(testData, 0, testData.Length);

        Assert.Equal(expected, testData);
    }

    [Fact]
    public void merge_sort_should_sort_descending_lists()
    {
        int[] testData = _sortingData.lijst_aflopend_2.ToArray();
        MergeSort.Sort(testData, 0, testData.Length);
        Assert.Equal([-10033224, 1], testData);
    }

    [Fact]
    public void merge_sort_should_sort_ascending_lists()
    {
        int[] testData = _sortingData.lijst_oplopend_2.ToArray();
        MergeSort.Sort(testData, 0, testData.Length);
        Assert.Equal([-100324, 1023], testData);
    }

    [Fact]
    public void merge_sort_should_sort_float_lists()
    {
        float[] testData = _sortingData.lijst_float_8001.ToArray();
        MergeSort.Sort(testData, 0, testData.Length);

        // Sort with the , 0, testData.Lengthstandard library
        float[] expected = testData.ToArray();
        Array.Sort(expected, 0, testData.Length);

        Assert.Equal(expected, testData);
    }

    [Fact]
    public void merge_sort_should_sort_empty_lists()
    {
        int[] testData = _sortingData.lijst_leeg_0.ToArray();
        MergeSort.Sort(testData, 0, testData.Length);
        Assert.Empty(testData);
    }

    [Fact]
    public void merge_sort_should_sort_single_element_lists()
    {
        int[] testData = [1];
        MergeSort.Sort(testData, 0, testData.Length);
        Assert.Equal([1], testData);
    }

    [Fact]
    public void merge_sort_should_sort_single_null_lists()
    {
        var testData = _sortingData.lijst_null_1.ToArray();
        MergeSort.Sort(testData, 0, testData.Length);
        Assert.Equal(new int?[] { null }, testData);
    }

    [Fact]
    public void merge_sort_should_sort_list_with_int_and_null()
    {
        // null is treated as the lowest value
        var testData = _sortingData.lijst_null_3.ToArray();
        MergeSort.Sort(testData, 0, testData.Length);
        Assert.Equal(new int?[] { null, 1, 3 }, testData);
    }

    [Fact]
    public void merge_sort_should_sort_a_random_list()
    {
        // null is treated as the lowest value
        var testData = new[] { 5, 2, 99, 1, 6, 9 };
        MergeSort.Sort(testData, 0, testData.Length);
        Assert.Equal(new int[] { 1, 2, 5, 6, 9, 99 }, testData);
    }
}