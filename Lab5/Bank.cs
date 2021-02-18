using System;
using System.Collections.Generic;
using Banks.Accounts;
using Banks.Client;
using Banks.Exceptions;

namespace Banks
{
    public class Bank
    {
        private readonly double _percent;
        private readonly double _limit;
        private readonly double _commission;
        private string _name;
        private readonly Dictionary<int, Client.Client> _clients;
        private readonly Dictionary<int, Dictionary<int, Account>> _accounts;
        private int _accountId = 0;
        private readonly ClientBuilder _builder;
        private readonly int _maxSumToTransfer;
        
        public Bank(string name, double percent, double limit, double commission, int maxSumToTransfer)
        {
            _name = name;
            _percent = percent;
            _limit = limit;
            _commission = commission;
            _clients = new Dictionary<int, Client.Client>();
            _accounts = new Dictionary<int, Dictionary<int, Account>>();
            _builder = new ClientBuilder();
            _maxSumToTransfer = maxSumToTransfer;
        }

        public void AddClient(string name, string secondName, string address, string passport)
        {
            //enter name
            _builder.SetName(name);
            //enter secondName
            _builder.SetSecondName(secondName);
            //enter address
            _builder.SetAddress(address);
            //enter passport
            _builder.SetPassport(passport);
            _clients.Add(_clients.Count, _builder.Build());
        }

        public void CreateDebit(int cid, double balance)
        {
            try
            {
                if (!_clients.ContainsKey(cid))
                    throw new AccountException($"id {cid}: there isn't client with such id");
                var tmp = new DebitAccount(_clients[cid], balance, this, _percent);
                _accounts.Add(cid, new Dictionary<int, Account>());
                _accounts[cid].Add(_accountId, tmp);
                _accountId++;
            }
            catch (AccountException e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }

        public void CreateDeposit(int cid, double balance, DateTime expirationTime)
        {
            try
            {
                if (!_clients.ContainsKey(cid))
                    throw new AccountException($"id {cid}: there isn't client with such id");
                var tmp = new DepositAccount(_clients[cid], balance, this, expirationTime);
                _accounts.Add(cid, new Dictionary<int, Account>());
                _accounts[cid].Add(_accountId, tmp);
                _accountId++;
            }
            catch (AccountException e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }
        
        public void CreateCredit(int cid)
        {
            try
            {
                if (!_clients.ContainsKey(cid))
                    throw new AccountException($"id {cid}: there isn't client with such id");
                var tmp = new CreditAccount(_clients[cid], 0, this, _limit, _commission);
                _accounts.Add(cid, new Dictionary<int, Account>());
                _accounts[cid].Add(_accountId, tmp);
                _accountId++;
            }
            catch (AccountException e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }

        public void EditAddress(int cid, string address)
        {
            _clients[cid].Address = address;

            foreach (var accounts in _accounts[cid])
            {
                accounts.Value.EditDoubtful();
            }
                
        }
        
        public void EditPassport(int cid, string passport)
        {
            _clients[cid].Passport = passport;
            
            foreach (var accounts in _accounts[cid])
            {
                accounts.Value.EditDoubtful();
            }
        }

        public void TravelToTheFuture(int days)
        {
            foreach (var account in _accounts)
            {
                foreach (var concreteAccount in account.Value)
                {
                    concreteAccount.Value.TravelToTheFuture(days);
                }
            }
        }

        public Dictionary<int, Dictionary<int, Account>> GetAccounts()
        {
            return _accounts;
        }

        public int GetMaxSumToTransfer()
        {
            return _maxSumToTransfer;
        }
    }
}