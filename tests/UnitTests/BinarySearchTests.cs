using Algorithms.Course;
using Newtonsoft.Json;

namespace UnitTests;

public class BinarySearchTests
{
    private readonly SortingData _sortingData;

    public BinarySearchTests()
    {
        using StreamReader reader = new("./Data/sortingData.json");
        var json = reader.ReadToEnd();
        var data = JsonConvert.DeserializeObject<SortingData>(json);
        _sortingData = data!;
    }

    [Fact]
    public void binary_search_should_find_existing_item_in_sorted_array_and_return_its_index()
    {
        List<int> haystack = _sortingData.lijst_gesorteerd_oplopend_3;
        const int needle = 1;
        const int expectedIndex = 0;

        var result = SearchAlgorithms.BinarySearch(haystack, needle);

        Assert.Equal(expectedIndex, result);
    }

    [Fact]
    public void binary_search_should_return_minus_one_when_needle_is_not_found()
    {
        List<int> haystack = _sortingData.lijst_gesorteerd_oplopend_3;
        const int needle = 100;
        const int expected = -1;

        var result = SearchAlgorithms.BinarySearch(haystack, needle);

        Assert.Equal(expected, result);
    }
}