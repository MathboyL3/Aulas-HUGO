using TAD_ContaBancaria.Files;

var sistema = new SistemaBancario()
    .AdicionarConta(new Conta("João", "123"))
    .AdicionarConta(new Conta("Daniel", "122"));

sistema.Depositar("123", 100);
sistema.Depositar("122", 50);

sistema.ImprimirContas("Antes");

sistema.Transferir("123", "122", 10);

sistema.ImprimirContas("Depois");

