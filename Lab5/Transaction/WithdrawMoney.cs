using Banks.Accounts;

namespace Banks.Transaction
{
    public class WithdrawMoney : ITransaction

    {
        private readonly Account _acc;
        private readonly double _sum;
        
        public WithdrawMoney(Account acc, double sum)
        {
            _acc = acc;
            _sum = sum;
        }
        
        public bool Execute()
        {
            var res = _acc.WithdrawMoney(_sum);
            return res;
        }

        public void Undo()
        {
            _acc.PutMoney(_sum);
        }

        public double GetSum()
        {
            return _sum;
        }
    }
}