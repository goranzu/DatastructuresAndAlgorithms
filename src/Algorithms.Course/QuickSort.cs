namespace Algorithms.Course;

public static class QuickSort
{
    public static void Sort<T>(T?[] array, int start, int end)
    {
        if (start >= end)
        {
            return;
        }

        int pivot = Partition(array, start, end);

        Sort(array, start, pivot - 1);
        Sort(array, pivot + 1, end);
    }

    private static int Partition<T>(T?[] array, int start, int end)
    {
        var comparer = Comparer<T>.Default;
        T? pivot = array[end];
        int i = start - 1;

        for (int j = start; j < end; j++)
        {
            if (comparer.Compare(array[j], pivot) < 0)
            {
                i++;
                Swap(ref array[i], ref array[j]);
            }
        }

        Swap(ref array[i + 1], ref array[end]); // Placing pivot in the correct position
        return i + 1;
    }

    private static void Swap<T>(ref T x, ref T y)
        => (x, y) = (y, x);
}