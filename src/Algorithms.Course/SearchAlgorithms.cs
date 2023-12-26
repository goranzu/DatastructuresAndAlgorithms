namespace Algorithms.Course;

public static class SearchAlgorithms
{
    public static int TwoCrystalBalls(bool[] breaks)
    {
        var jmpAmount = (int)Math.Floor(Math.Sqrt(breaks.Length));
        var i = jmpAmount;
        for (; i < breaks.Length; i++)
        {
            if (breaks[i])
            {
                break;
            }
        }

        i -= jmpAmount;
        for (int j = 0; j < jmpAmount && i < breaks.Length; j++, i++)
        {
            if (breaks[i])
            {
                return i;
            }
        }

        return -1;
    }

    public static bool BinarySearch(int[] haystack, int needle)
    {
        Array.Sort(haystack);
        var l = 0;
        var h = haystack.Length;

        do
        {
            var m = l + (h - l) / 2;
            var v = haystack[m];

            if (v == needle)
            {
                return true;
            }

            if (v > needle)
            {
                h = m;
            }
            else
            {
                l = m + 1;
            }
        } while (l < h);

        return false;
    }
}