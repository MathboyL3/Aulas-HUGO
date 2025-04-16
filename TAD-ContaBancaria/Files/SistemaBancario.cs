using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAD_ContaBancaria.Files
{
    public class SistemaBancario
    {
        public List<Conta> Contas { get; set; }
        public SistemaBancario()
        {
            Contas = new List<Conta>();
        }
        public SistemaBancario AdicionarConta(Conta conta)
        {
            Contas.Add(conta);
            return this;
        }
        public SistemaBancario RemoverConta(Conta conta)
        {
            Contas.Remove(conta);
            return this;
        }
        public Conta BuscarConta(string numero)
        {
            return Contas.FirstOrDefault(c => c.Numero.Equals(numero));
        }

        public void Transferir(string numeroOrigem, string numeroDestino, double valor)
        {
            var contaOrigem = BuscarConta(numeroOrigem);
            var contaDestino = BuscarConta(numeroDestino);
            if (contaOrigem == null)
                throw new Exception("Conta de origem não encontrada");
            if (contaDestino == null)
                throw new Exception("Conta de destino não encontrada");
            contaOrigem.Sacar(valor);
            contaDestino.AdicionarSaldo(valor);
        }

        public void Sacar(string numero, double valor)
        {
            var conta = BuscarConta(numero);
            if (conta == null)
                throw new Exception("Conta não encontrada");
            conta.Sacar(valor);
        }

        public void Depositar(string numero, double valor)
        {
            var conta = BuscarConta(numero);
            if (conta == null)
                throw new Exception("Conta não encontrada");
            conta.AdicionarSaldo(valor);
        }

        public void ImprimirContas(string message = "")
        {
            Console.WriteLine(message); 
            foreach (var conta in Contas)
            {
                Console.WriteLine($"Responsável: {conta.Reponsavel}");
                Console.WriteLine($"Número: {conta.Numero}");
                Console.WriteLine($"Saldo: {conta.Saldo}");
                Console.WriteLine();
            }
        }
    }
}
