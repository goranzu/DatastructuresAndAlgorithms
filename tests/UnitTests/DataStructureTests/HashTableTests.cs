using Algorithms.Course;
using Newtonsoft.Json;

namespace UnitTests.DataStructureTests;

public class HashTableTests
{
    public HashingData _data;

    public HashTableTests()
    {
        using StreamReader reader = new("./Data/hashingData.json");
        var json = reader.ReadToEnd();
        var data = JsonConvert.DeserializeObject<HashingData>(json);
        _data = data!;
    }

    [Fact]
    public void hash_table_should_be_initialized_correctly()
    {
        var expectedItemCount = _data.hashtabelsleutelswaardes.Count;

        HashTable<string, List<int>> hashTable = new(expectedItemCount);
        foreach (var item in _data.hashtabelsleutelswaardes)
        {
            hashTable.Insert(item.Key, item.Value);
        }

        Assert.NotNull(hashTable);
        foreach (var item in _data.hashtabelsleutelswaardes)
        {
            var valueInHashTable = hashTable.Search(item.Key);
            Assert.NotNull(valueInHashTable);
            Assert.Equal(item.Value, valueInHashTable);
        }
    }

    [Fact]
    public void search_should_find_the_correct_value()
    {
        HashTable<string, List<int>> hashTable = new(_data.hashtabelsleutelswaardes.Count);
        foreach (var item in _data.hashtabelsleutelswaardes)
        {
            hashTable.Insert(item.Key, item.Value);
        }

        var knownKey = "a";
        var expectedValue = new List<int> { 0 };
        var actualValue = hashTable.Search(knownKey);
        Assert.NotNull(actualValue);
        Assert.Equal(expectedValue, actualValue);

        var secondKnownKey = "w";
        var secondExpectedValue = new List<int> { 04545, 334344, 45454, 6576, -1 };
        var secondActualValue = hashTable.Search(secondKnownKey);
        Assert.NotNull(secondActualValue);
        Assert.Equal(secondExpectedValue, secondActualValue);
    }

    [Fact]
    public void search_should_return_null_if_key_does_not_exist()
    {
        HashTable<string, List<int>> hashTable = new(_data.hashtabelsleutelswaardes.Count);
        foreach (var item in _data.hashtabelsleutelswaardes)
        {
            hashTable.Insert(item.Key, item.Value);
        }

        var knownKey = "doesnotexist";
        var result = hashTable.Search(knownKey);
        Assert.Null(result);
    }

    [Fact]
    public void removing_an_existing_item_should_remove_item_from_hash_table()
    {
        HashTable<string, List<int>> hashTable = new(_data.hashtabelsleutelswaardes.Count);
        foreach (var item in _data.hashtabelsleutelswaardes)
        {
            hashTable.Insert(item.Key, item.Value);
        }

        var initialCount = hashTable.Count;
        var keyToRemove = "a";

        Assert.NotNull(hashTable.Search(keyToRemove));

        hashTable.Remove(keyToRemove);

        var valueAfterRemoval = hashTable.Search(keyToRemove);
        Assert.Null(valueAfterRemoval);
        Assert.Equal(initialCount - 1, hashTable.Count);
    }

    [Fact]
    public void remove_a_non_existing_should_not_modify_the_table()
    {
        HashTable<string, List<int>> hashTable = new(_data.hashtabelsleutelswaardes.Count);
        foreach (var item in _data.hashtabelsleutelswaardes)
        {
            hashTable.Insert(item.Key, item.Value);
        }

        var expectedCount = hashTable.Count;
        var keyToRemove = "doesnotexist";
        hashTable.Remove(keyToRemove);

        Assert.Equal(expectedCount, hashTable.Count);
    }
}