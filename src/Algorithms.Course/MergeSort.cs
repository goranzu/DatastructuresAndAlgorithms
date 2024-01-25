namespace Algorithms.Course;

public static class MergeSort
{
    public static void Sort<T>(T?[] array, int start, int end)
    {
        if (end - start <= 1)
        {
            return;
        }

        var middle = start + (end - start) / 2;

        Parallel.Invoke(
            () => Sort(array, start, middle),
            () => Sort(array, middle, end));

        Merge(array, start, middle, end);
    }

    private static void Merge<T>(T?[] array, int start, int middle, int end)
    {
        int i = start, j = middle;
        var comparer = Comparer<T>.Default;

        while (i < j && j < end)
        {
            if (comparer.Compare(array[i], array[j]) > 0)
            {
                T? temp = array[j];
                for (int k = j; k > i; k--)
                {
                    array[k] = array[k - 1];
                }

                array[i] = temp;
                j++;
            }

            i++;
        }
    }
}