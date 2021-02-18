using System;

namespace Banks.Accounts
{
    public class CreditAccount : Account
    {
        private readonly double _commission;
        private readonly double _limit;
        
        public CreditAccount(Client.Client client, double balance, Bank bank, double limit, double commission) : base(client, balance, bank)
        {
            Balance = 0;
            _limit = limit;
            _commission = commission;
        }

        private void AccrualCommission()
        {
            if (Balance >= _limit)
                Balance += _commission;
        }

        public override void TravelToTheFuture(int days)
        {
            var tmp = 0;
            while (tmp < days)
            {
                tmp += 1;
                CurrentTime = CurrentTime.AddDays(1);
                if (CurrentTime.Day == 1)
                    AccrualCommission();
            }
        }

        public override bool WithdrawMoney(double sum)
        {
            Balance += sum;
            return true;
        }

        public override bool PutMoney(double sum)
        {
            Balance -= sum;
            return true;
        }
    }
}