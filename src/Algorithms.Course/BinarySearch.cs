namespace Algorithms.Course;

public static class BinarySearch
{
    public static int Search(IEnumerable<int> haystack, int needle)
    {
        var array = haystack as int[] ?? haystack.ToArray();
        var low = 0;
        var high = array.Length;
        var result = -1;

        do
        {
            var mid = low + (high - low) / 2;
            var value = array[mid];

            if (value == needle)
            {
                result = mid;
            }

            if (value > needle)
            {
                high = mid;
            }
            else
            {
                low = mid + 1;
            }
        } while (low < high);

        return result;
    }
}