namespace Mediator
{
    internal interface IBank
    {
        void SendMoney(Client sender, Client receiver, int transactionMoney);
    }
}