using System.Diagnostics;
using System.Numerics;

//int[] sessions = [10, 100, 1_000, 10_000, 100_000, 1_000_000, 10_000_000, 100_000_000, 1_000_000_000];
int[] sessions = [1000000];

//TestFor(TesteSomaMethod);
TestForFunc(TesteMultiplicacaoMethodParallel);

Console.ReadLine();

int[] GetRandomNumbers(int size)
{
    return new int[size].Select(x => Random.Shared.Next()).ToArray();
}

int[] GetSequence(int size)
{
    var result = new int[size];
    for (int i = 0; i < size; i++)
        result[i] = i + 1;
    return result;
}

void TestFor(Action<int> method)
{
    for (int i = 0; i < sessions.Length; i++)
        method(sessions[i]);
}
void TestForFunc(Func<int, BigInteger> method)
{
    for (int i = 0; i < sessions.Length; i++)
        Console.WriteLine($"Reuslt: {method.Invoke(sessions[i])}");
}
void TesteSomaMethod(int iteration)
{
    var arr = new int[iteration];
    int i = iteration - 1;
    int soma = 0;
    var sw = Stopwatch.StartNew();

    for (; i >= 0; i--)
        soma += arr[i];

    sw.Stop();
    Console.WriteLine($"Soma: {iteration.ToString("N0")} números demoraram {sw.ElapsedMilliseconds}ms para executar");
}
void TesteMultiplicacaoMethod(int iteration)
{
    var arr = GetSequence(iteration);
    int i = iteration - 1;
    BigInteger soma = 1;
    var sw = Stopwatch.StartNew();
    
    for (; i >= 0; i--)
        soma *= arr[i];

    sw.Stop();
    Console.WriteLine($"Multiplicação: {iteration.ToString("N0")} números demoraram {sw.ElapsedMilliseconds}ms para executar");
}

BigInteger TesteMultiplicacaoMethodParallel(int iteration)
{
    var arr = GetSequence(iteration);

    List<Task<BigInteger>> tasks = new();
    int taskCount = 10;

    int batch = iteration / taskCount;
    int remaining = iteration % taskCount;

    for(int i = 0; i < taskCount; i++)
    {
        int offset = batch * i;
        var t = Task.Run(() => {
            BigInteger result = arr[offset];
            for (int b = offset + 1; b < offset + batch; b++)
                result *= arr[b];
            return result;
        });
        tasks.Add(t);
    }

    int lastOffset = batch * taskCount;

    if(lastOffset != iteration)
    {
        var lastTask = Task.Run(() => {
            BigInteger result = arr[lastOffset];
            for (int b = 1; b < remaining; b++)
                result *= arr[lastOffset + b];
            return result;
        });
        tasks.Add(lastTask);
    }

    var sw = Stopwatch.StartNew();

    Task.WaitAll(tasks);

    BigInteger soma = 0;

    for (int s = 0; s < tasks.Count; s++)
        soma += tasks[s].Result;

    sw.Stop();
    Console.WriteLine($"Multiplicação: {iteration.ToString("N0")} números demoraram {sw.ElapsedMilliseconds}ms para executar");
    return soma;
}