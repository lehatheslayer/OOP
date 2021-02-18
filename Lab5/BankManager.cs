using System;
using System.Collections.Generic;
using Banks.Accounts;
using Banks.Transaction;

namespace Banks
{
    public class BankManager
    {
        private readonly List<Bank> _banks;
        private readonly TransactionHistory _history;

        public BankManager()
        {
            _banks = new List<Bank>();
            _history = new TransactionHistory();
        }

        public void CreateBank(string name, double percent, double limit, double commission, int maxSumToTransfer)
        {
            _banks.Add( new Bank(name, percent, limit, commission, maxSumToTransfer));
        }

        public void WithdrawMoney(Account acc, double sum)
        {
            ITransaction transaction = new WithdrawMoney(acc, sum);
            var res = transaction.Execute();
            if (res)
                _history.Push(transaction);
        }

        public void PutMoney(Account acc, double sum)
        {
            ITransaction transaction = new PutMoney(acc, sum);
            var res = transaction.Execute();
            if (res)
                _history.Push(transaction);
        }

        public void TransferMoney(Account from, Account to, double sum)
        {
            try
            {
                ITransaction transaction = new TransferMoney(from, to, sum);
                var res = transaction.Execute();
                if (!res && from.GetDoubtful())
                    throw new Exception("Ограниченный счет");
                _history.Push(transaction);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }

        public void UndoTransaction(int id)
        {
            var toUndo = _history.GetHistory()[id];
            ITransaction transaction = new UndoTransaction(toUndo);
            transaction.Execute();
            _history.GetHistory().Remove(toUndo);
        }
        
        public void TravelToTheFuture(int days)
        {
            foreach (var bank in _banks)
            {
                bank.TravelToTheFuture(days);
            }
        }

        public List<Bank> GetBanks()
        {
            return _banks;
        }

        public Bank GetBank(int id)
        {
            return _banks[id];
        }
        
    }
}