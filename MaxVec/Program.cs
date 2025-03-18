
int[] numbers = { 8, 5, 2, 9 };

Console.WriteLine($" Antes: {string.Join(", ", numbers)}");
Order(numbers);
Console.WriteLine($"Depois: {string.Join(", ", numbers)}");

int Max(int[] vec, int from, int to)
{
    var max = numbers[from];
    var idx = from;
    for (int i = from; i <= to; i++)
    {
        if (numbers[i] > max)
        {
            max = numbers[i];
            idx = i;
        }
    }
    return idx;
}

int Min(int[] vec, int from, int to)
{
    var min = numbers[from];
    var idx = from;
    for (int i = from; i <= to; i++)
    {
        if (numbers[i] < min)
        {
            min = numbers[i];
            idx = i;
        }
    }
    return idx;
}

void Order(int[] arr)
{
    int maxB = arr.Length - 1;
    int n = arr.Length / 2;

    if (arr.Length % 2 == 0)
        n += 1;

    for (int i = 0; i < n; i++)
    {
        var lastPos = maxB - i;
        var min = Min(arr, i, lastPos);
        var max = Max(arr, i, lastPos);

        if (min == max) break;

        (arr[i], arr[min]) = (arr[min], arr[i]);
        (arr[lastPos], arr[max]) = (arr[max], arr[lastPos]);
    }
}