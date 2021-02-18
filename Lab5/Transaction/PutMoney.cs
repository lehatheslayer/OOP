using Banks.Accounts;

namespace Banks.Transaction
{
    public class PutMoney : ITransaction
    {
        private Account _acc;
        private double _sum;

        public PutMoney(Account acc, double sum)
        {
            _acc = acc;
            _sum = sum;
        }
        
        public bool Execute()
        {
            var res = _acc.PutMoney(_sum);
            return res;
        }

        public void Undo()
        {
            _acc.WithdrawMoney(_sum);
        }
    }
}