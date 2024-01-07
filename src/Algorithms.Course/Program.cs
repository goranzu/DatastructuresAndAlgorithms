using System.Collections;

int[] myArr = [5, 1, 53, 11, 46, 76];

PrintArray(myArr);

return;

static void PrintArray(IEnumerable myArr)
{
    foreach (var item in myArr)
    {
        Console.Write($"{item},");
    }
}