using System.Collections;
using Algorithms.Course;

int[] myArr = [5, 1, 53, 11, 46, 76];

Console.WriteLine($"Binary Search: {SearchAlgorithms.BinarySearch(myArr, 77)}");
SortingAlgorithms.BubbleSort(myArr);
PrintArray(myArr);

return;

static void PrintArray(IEnumerable myArr)
{
    foreach (var item in myArr)
    {
        Console.Write($"{item},");
    }
}