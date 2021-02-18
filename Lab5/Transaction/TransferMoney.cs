using Banks.Accounts;

namespace Banks.Transaction
{
    public class TransferMoney : ITransaction
    {
        private Account _from;
        private Account _to;
        private double _sum;

        public TransferMoney(Account from, Account to, double sum)
        {
            _from = from;
            _to = to;
            _sum = sum;
        }
        
        public bool Execute()
        {
            if (_from.GetDoubtful() && _sum > _from.GetBank().GetMaxSumToTransfer())
                return false;
            var res1 = _from.WithdrawMoney(_sum);
            var res2 = _to.PutMoney(_sum);
            switch (res1)
            {
                case false when res2 == true:
                    _to.WithdrawMoney(_sum);
                    return false;
                case true when res2 == false:
                    _from.PutMoney(_sum);
                    return false;
                default:
                    return res1 & res2;
            }
        }

        public void Undo()
        {
            _from.PutMoney(_sum);
            _to.WithdrawMoney(_sum);
        }
    }
}