struct item
{
    public int chave;
    public int dado;

    public item(int chave, int dado)
    {
        this.chave = chave;
        this.dado = dado;
    }
}

public static class Program
{
    public static void Main()
    {
        int n = 1000;
        List<item> lista = new();

        for (int i = 0; i < n; i++)
            lista.Add(new item(Random.Shared.Next(), Random.Shared.Next()));

        Console.WriteLine($"O item foi encontrado no index {Busca(lista, lista[n-1].chave, n)}");
    }

    static int Busca(IList<item> lista, int chave, int tamanhoLista)
    {
        int i = 0;
        while(i < tamanhoLista)
        {
            if (lista[i].chave == chave)
                return i;
            i += 1;
        }
        return -1;
    }
}


