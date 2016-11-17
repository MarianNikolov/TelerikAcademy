using System.Collections.Generic;

namespace Mediator
{
    /// <summary>
    /// Mediator
    /// </summary>
    /// <seealso cref="Mediator.IBank" />

    internal class Bank : IBank
    {
        private IDictionary<string, int> clients;

        public Bank()
        {
            clients = new Dictionary<string, int>();
        }

        public void RegisterClient(Client client)
        {
            clients.Add(client.Name, client.BankAccount);
        }

        public void SendMoney(Client sender, Client receiver, int transactionMoney)
        {
            clients[sender.Name] -= transactionMoney;
            sender.BankAccount -= transactionMoney;

            clients[receiver.Name] += transactionMoney;
            receiver.BankAccount += transactionMoney;
        }
    }
}
