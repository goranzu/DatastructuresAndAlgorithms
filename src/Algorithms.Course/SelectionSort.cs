namespace Algorithms.Course;

public static class SelectionSort
{
    public static void Sort<T>(T?[] array)
    {
        var comparer = Comparer<T>.Default;
        for (int i = 0; i < array.Length - 1; i++)
        {
            int min = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (comparer.Compare(array[min], array[j]) > 0)
                {
                    min = j;
                }
            }

            (array[i], array[min]) = (array[min], array[i]);
        }
    }
}