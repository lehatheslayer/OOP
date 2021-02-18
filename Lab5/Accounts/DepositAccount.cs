using System;
using Banks.Exceptions;

namespace Banks.Accounts
{
    public class DepositAccount : Account
    {
        private DateTime _expirationTime;
        private double _startBalance;
        private bool _active = false;
        
        public DepositAccount(Client.Client client, double balance, Bank bank, DateTime expirationTime) : base(client, balance, bank)
        {
            _expirationTime = expirationTime;
            _startBalance = balance;
        }

        private void CountYearlyAmount()
        {
            if (Balance < 50000)
                Balance += 0.03 * _startBalance;
            if (Balance > 50000 && Balance < 100000)
                Balance += 0.035 * _startBalance;
            if (Balance > 100000)
                Balance += 0.04 * _startBalance;
        }

        public override void TravelToTheFuture(int days)
        {
            var tmp = 0;
            while (tmp < days)
            {
                tmp += 1;
                CurrentTime = CurrentTime.AddDays(1);
                if (CurrentTime.Day == 1 && CurrentTime.Month == 1)
                    CountYearlyAmount();
                if (CurrentTime > _expirationTime)
                    _active = true;
            }
        }

        public override bool WithdrawMoney(double sum)
        {
            try
            {
                DateTime cur = DateTime.Now;
                if (cur < _expirationTime)
                    throw new TransactionException("Счет все еще закрыт");
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