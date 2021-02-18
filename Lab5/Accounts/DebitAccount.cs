using System;
using System.ComponentModel;
using Banks.Exceptions;

namespace Banks.Accounts
{
    public class DebitAccount : Account
    {
        private readonly double _percent;
        private double _accrualAmount = 0;
        public DebitAccount(Client.Client client, double balance, Bank bank, double percent) : base(client, balance, bank)
        {
            _percent = percent;
        }

        private void CountDailyAmount()
        {
            _accrualAmount += _percent * Balance / 365;
        }

        private void AddAccountBalance()
        {
            Balance += _accrualAmount;
            _accrualAmount = 0;
        }

        public override void TravelToTheFuture(int days)
        {
            var tmp = 0;
            while (tmp < days)
            {
                tmp += 1;
                CountDailyAmount();
                CurrentTime = CurrentTime.AddDays(1);
                if (CurrentTime.Day == 1)
                    AddAccountBalance();
            }
        }

        public override bool WithdrawMoney(double sum)
        {
            try
            {
                if (Balance < sum)
                    throw new TransactionException("Недостаточно средств");
                Balance -= sum;
            }
            catch (TransactionException e)
            {
                Console.WriteLine($"{e.Message}");
                return false;
            }

            return true;
        }

        public override bool PutMoney(double sum)
        {
            Balance += sum;
            return true;
        }
    }
}