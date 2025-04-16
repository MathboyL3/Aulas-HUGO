using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAD_ContaBancaria.Files
{
    public class Conta
    {
        public Conta(string reponsavel, string numero)
        {
            if (string.IsNullOrWhiteSpace(reponsavel)) 
                throw new Exception("Deve-se definir um responsável para a conta");

            if(string.IsNullOrWhiteSpace(numero))

            Reponsavel = reponsavel;
            Numero = numero;
            Saldo = 0;
        }

        public string Reponsavel { get; private set; }
        public string Numero { get; private set; }
        public double Saldo { get; private set; }


        public void AdicionarSaldo(double saldo)
        {
            if (saldo <= 0)
                throw new Exception("O saldo a ser adicionado deve ser maior que zero");
            Saldo += saldo;
        }

        public void Sacar(double saldo)
        {
            if (saldo <= 0)
                throw new Exception("O saldo a ser sacado deve ser maior que zero");
            if (saldo > Saldo)
                throw new Exception("Saldo insuficiente");
            Saldo -= saldo;
        }
    }
}
