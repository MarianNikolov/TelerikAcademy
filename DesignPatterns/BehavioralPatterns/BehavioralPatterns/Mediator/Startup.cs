using System;

namespace Mediator
{
    internal class Startup
    {
        static void Main()
        {
            int transactionMoney = 100;

            // mediator
            Bank bank = new Bank();

            Client pesho = new Client("Pesho", 500);
            bank.RegisterClient(pesho);

            Client gosho = new Client("Gosho", 900);
            bank.RegisterClient(gosho);

            Console.WriteLine("--Before transaction--");
            Console.WriteLine($"{pesho.Name}: {pesho.BankAccount}");
            Console.WriteLine($"{gosho.Name}: {gosho.BankAccount}");

            bank.SendMoney(pesho, gosho, transactionMoney);

            Console.WriteLine("--After transaction--");
            Console.WriteLine($"{pesho.Name}: {pesho.BankAccount}");
            Console.WriteLine($"{gosho.Name}: {gosho.BankAccount}");
        }
    }
}
