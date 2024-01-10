namespace Algorithms.Course;

public static class MergeSort
{
    public static void SortWithOutParallelism<T>(T?[] array)
    {
        var length = array.Length;
        if (length <= 1)
        {
            return;
        }

        var middle = length / 2;
        var leftArray = new T?[middle];
        var rightArray = new T?[length - middle];

        var i = 0;
        var j = 0;

        for (; i < length; i++)
        {
            if (i < middle)
            {
                leftArray[i] = array[i];
            }
            else
            {
                rightArray[j] = array[i];
                j++;
            }
        }

        Sort(leftArray);
        Sort(rightArray);
        Merge(leftArray, rightArray, array);
    }

    public static void Sort<T>(T?[] array)
    {
        var length = array.Length;
        if (length <= 1)
        {
            return;
        }

        var middle = length / 2;
        var leftArray = new T?[middle];
        var rightArray = new T?[length - middle];

        var i = 0;
        var j = 0;

        for (; i < length; i++)
        {
            if (i < middle)
            {
                leftArray[i] = array[i];
            }
            else
            {
                rightArray[j] = array[i];
                j++;
            }
        }

        Parallel.Invoke(
            () => Sort<T>(leftArray),
            () => Sort<T>(rightArray));

        Merge(leftArray, rightArray, array);
    }

    private static void Merge<T>(T?[] leftArray, T?[] rightArray, T?[] array)
    {
        var comparer = Comparer<T>.Default;
        var leftSize = array.Length / 2;
        var rightSize = array.Length - leftSize;
        int i = 0, l = 0, r = 0;

        while (l < leftSize && r < rightSize)
        {
            if (comparer.Compare(leftArray[l], rightArray[r]) < 0)
            {
                array[i] = leftArray[l];
                i++;
                l++;
            }
            else
            {
                array[i] = rightArray[r];
                i++;
                r++;
            }
        }

        while (l < leftSize)
        {
            array[i] = leftArray[l];
            i++;
            l++;
        }

        while (r < rightSize)
        {
            array[i] = rightArray[r];
            i++;
            r++;
        }
    }
}