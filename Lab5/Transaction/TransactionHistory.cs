using System.Collections.Generic;

namespace Banks.Transaction
{
    public class TransactionHistory
    {
        private List<ITransaction> _history;

        public TransactionHistory()
        {
            _history = new List<ITransaction>();
        }

        public void Push(ITransaction transaction)
        {
            _history.Add(transaction);
        }

        public List<ITransaction> GetHistory()
        {
            return _history;
        }
    }
}