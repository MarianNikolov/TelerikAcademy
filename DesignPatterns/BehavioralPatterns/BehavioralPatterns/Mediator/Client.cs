namespace Mediator
{
    public class Client
    {
        private string name;
        private int bankAccount;

        public Client(string name, int bankAccount)
        {
            this.Name = name;
            this.BankAccount = bankAccount;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public int BankAccount
        {
            get
            {
                return this.bankAccount;
            }

            set
            {
                this.bankAccount = value;
            }
        }
    }
}