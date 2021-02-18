using System;

namespace Banks
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            BankManager bankManager = new BankManager();
            bankManager.CreateBank("bank1", 1.5, 10000, 2000, 5000);
            bankManager.CreateBank("bank2", 2.5, 12500, 2250, 5000);
            bankManager.CreateBank("bank3", 3.5, 15000, 2500, 5000);
            
            bankManager.GetBank(0).AddClient("Ivan", "Ivanov", "Moscow", "111111 9999");
            bankManager.GetBank(0).CreateDebit(0, 1000);
            bankManager.GetBank(0).AddClient("Sergey", "Sergeev", "SPB", "222222 8888");
            bankManager.GetBank(0).CreateDeposit(1, 60000, new DateTime(2021,12,1));
            bankManager.GetBank(0).AddClient("Pavel", "Pavlov", "Kazan", "333333 7777");
            bankManager.GetBank(0).CreateCredit(2);
            
            bankManager.GetBank(1).AddClient("Ivan", "Ivanov", "Moscow", "111111 9999");
            bankManager.GetBank(1).CreateDebit(0, 1000);
            bankManager.GetBank(1).AddClient("Sergey", "Sergeev", "SPB", "222222 8888");
            bankManager.GetBank(1).CreateDeposit(1, 60000, new DateTime(2021,12,1));
            bankManager.GetBank(1).AddClient("Pavel", "Pavlov", "Kazan", "333333 7777");
            bankManager.GetBank(1).CreateCredit(2);
            
            bankManager.GetBank(2).AddClient("Ivan", "Ivanov", "Moscow", "111111 9999");
            bankManager.GetBank(2).CreateDebit(0, 1000);
            bankManager.GetBank(2).AddClient("Sergey", "Sergeev", "SPB", "222222 8888");
            bankManager.GetBank(2).CreateDeposit(1, 60000, new DateTime(2021,12,1));
            bankManager.GetBank(2).AddClient("Pavel", "Pavlov", "Kazan", "333333 7777");
            bankManager.GetBank(2).CreateCredit(2);

            for (int i = 0; i < 3; i++)
            {
                foreach (var res in bankManager.GetBank(i).GetAccounts())
                {
                    foreach (var res1 in res.Value)
                    {
                        Console.WriteLine($"client id: {res.Key}, account id: {res1.Key}, balance: {res1.Value.GetBalance()}");
                    }
                }
            }
            
           

            Console.WriteLine("\n1:");
            Console.WriteLine(bankManager.GetBank(0).GetAccounts()[0][0].GetBalance());
            bankManager.WithdrawMoney(bankManager.GetBank(0).GetAccounts()[0][0], 1500);
            Console.WriteLine(bankManager.GetBank(0).GetAccounts()[0][0].GetBalance());
            bankManager.WithdrawMoney(bankManager.GetBank(0).GetAccounts()[0][0], 800);
            Console.WriteLine(bankManager.GetBank(0).GetAccounts()[0][0].GetBalance());
            bankManager.UndoTransaction(0);
            Console.WriteLine(bankManager.GetBank(0).GetAccounts()[0][0].GetBalance());
            
            Console.WriteLine("\n2:");
            Console.WriteLine(bankManager.GetBank(0).GetAccounts()[0][0].GetBalance());
            Console.WriteLine(bankManager.GetBank(0).GetAccounts()[1][1].GetBalance());
            bankManager.TransferMoney(bankManager.GetBank(0).GetAccounts()[1][1], bankManager.GetBank(0).GetAccounts()[0][0], 20000);
            Console.WriteLine(bankManager.GetBank(0).GetAccounts()[0][0].GetBalance());
            Console.WriteLine(bankManager.GetBank(0).GetAccounts()[1][1].GetBalance());
            bankManager.TransferMoney(bankManager.GetBank(0).GetAccounts()[2][2], bankManager.GetBank(0).GetAccounts()[0][0], 20000);
            Console.WriteLine(bankManager.GetBank(0).GetAccounts()[0][0].GetBalance());
            Console.WriteLine(bankManager.GetBank(0).GetAccounts()[2][2].GetBalance());
            bankManager.UndoTransaction(1);
            Console.WriteLine(bankManager.GetBank(0).GetAccounts()[0][0].GetBalance());
            Console.WriteLine(bankManager.GetBank(0).GetAccounts()[2][2].GetBalance());
            
            Console.WriteLine("\n3:");
            bankManager.GetBank(0).AddClient("Ivan", "Ivanov", "", "111111 9999");
            bankManager.GetBank(0).CreateDebit(3, 100000);
            bankManager.TransferMoney(bankManager.GetBank(0).GetAccounts()[3][3], bankManager.GetBank(0).GetAccounts()[0][0], 60000);
            
            Console.WriteLine();
            bankManager.TravelToTheFuture(450);
            for (int i = 0; i < 3; i++)
            {
                foreach (var res in bankManager.GetBank(i).GetAccounts())
                {
                    foreach (var res1 in res.Value)
                    {
                        Console.WriteLine($"client id: {res.Key}, account id: {res1.Key}, balance: {res1.Value.GetBalance()}");
                    }
                }
            }
            
        }
    }
}