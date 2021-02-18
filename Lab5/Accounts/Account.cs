using System;

namespace Banks.Accounts
{
    public abstract class Account
    {
        protected double Balance;
        protected Client.Client Client;
        protected DateTime CurrentTime;
        protected bool Doubtful;
        protected Bank Bank;

        protected Account(Client.Client client, double balance, Bank bank)
        {
            CurrentTime = DateTime.Now;
            Balance = balance;
            Client = client;
            Bank = bank;
            Doubtful = Client.Passport == null || Client.Address == null;
        }

        public void EditDoubtful()
        {
            Doubtful = Client.Passport == null || Client.Address == null;
        }

        public double GetBalance()
        {
            return Balance;
        }

        public Client.Client GetClient()
        {
            return Client;
        }

        public Bank GetBank()
        {
            return Bank;
        }

        public bool GetDoubtful()
        {
            return Doubtful;
        }
        
        public abstract void TravelToTheFuture(int days);

        public abstract bool WithdrawMoney(double sum);

        public abstract bool PutMoney(double sum);
    }
}