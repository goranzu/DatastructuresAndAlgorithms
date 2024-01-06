using System.Collections;

namespace Algorithms.Course;

public static class SortingAlgorithms
{
    public static void InsertionSort<T>(T?[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            T? temp = array[i];
            int j = i - 1;

            while (j >= 0 && Compare(array[j], temp) > 0)
            {
                array[j + 1] = array[j];
                j--;
            }

            array[j + 1] = temp;
        }
    }

    private static int Compare<T>(T x, T y)
    {
        return Comparer<T>.Default.Compare(x, y);
    }
}