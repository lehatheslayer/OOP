namespace Banks.Transaction
{
    public class UndoTransaction : ITransaction
    {
        private ITransaction _transaction;
        
        public UndoTransaction(ITransaction transaction)
        {
            _transaction = transaction;
        }
        public bool Execute()
        {
            _transaction.Undo();
            return true;
        }

        public void Undo()
        {
            return;
        }
    }
}