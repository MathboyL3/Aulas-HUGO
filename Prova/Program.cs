using System.Diagnostics;
public class Program
{
    public static void Main()
    {
        int runCount = 1000;
        CallTestes(X, runCount, "Implementação recursiva");
        CallTestes(X2, runCount, "Implementação while");
    }

    public static void CallTestes(Func<int, int> test, int repeat, string header)
    {
        Console.WriteLine(header);
        double totalTime = 0;
        for (int i = 0; i < repeat; i++)
        {
            var timer = Stopwatch.StartNew();
            test(20000);
            timer.Stop();
            var memoryAfter = GC.GetTotalMemory(true);
            totalTime += timer.Elapsed.TotalNanoseconds;
        }
        Console.WriteLine($"Time spent: {totalTime / repeat / 1000:00}ms");
    }


    public static int X(int a)
    {
        if (a <= 0)
            return 0;

        return a + X(a - 1);
    }

    public static int X2(int a)
    {
        int num = 0;
        while(a > 0)
        {
            num += a;
            a--;
        }
        return num;
    }
}

// a. O que essa funcão faz?
//    A função X é uma função recursiva que soma todos os números de 1 até 'a'.
//    A função X2 é uma função iterativa que faz a mesma coisa.

// b. Mostre como você chegou nesse resultado.
//    A função X chama a si mesma, reduzindo o valor de 'a' em 1 a cada chamada até que 'a' seja 0.

// c. Escreva uma função não recursiva que resolva o mesmo problema.
//   A função X2 é uma versão não recursiva que usa um loop while para somar os números de 1 até 'a'.
//    Ambas as funções retornam a soma dos números de 1 até 'a'.

// d. Qual implementação é mais eficiente? Justifique.
//    A implementação não recursiva (X2) é mais eficiente em termos de uso de memória e tempo de execução,
//    pois evita o overhead de chamadas de função recursivas e a criação de múltiplos frames na pilha de chamadas.
//    A implementação recursiva (X) pode levar a um estouro de pilha para valores altos de 'a'.
