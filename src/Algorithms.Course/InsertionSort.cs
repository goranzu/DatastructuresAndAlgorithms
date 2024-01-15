namespace Algorithms.Course;

public static class InsertionSort
{
    public static void Sort<T>(T?[] array)
    {
        var comparer = Comparer<T>.Default;
        
        for (int i = 1; i < array.Length; i++)
        {
            T? temp = array[i];
            int j = i - 1;

            while (j >= 0 && comparer.Compare(array[j], temp) > 0)
            {
                array[j + 1] = array[j];
                j--;
            }

            array[j + 1] = temp;
        }
    }
}