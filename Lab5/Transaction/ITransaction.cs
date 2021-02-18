namespace Banks.Transaction
{
    public interface ITransaction
    {
        bool Execute();
        void Undo();
    }
}