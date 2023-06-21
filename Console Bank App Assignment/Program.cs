namespace Console_Bank_App_Assignment
{
    using System;
    using System.Collections.Generic;

    namespace BankApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                Bank bank = new Bank();
                bank.CreateAccount("John Doe", "0987654321", AccountType.Savings, 10000, "Gift");
                bank.CreateAccount("John Doe", "0987654311", AccountType.Current, 100000, "Food");

                bank.DisplayAccounts();

                bank.Deposit("0987654321", 5000);
                bank.Withdraw("0987654311", 50000);
                bank.Transfer("0987654311", "0987654321", 30000);

                bank.DisplayAccounts();
            }
        }

        public enum AccountType
        {
            Savings,
            Current
        }

        public class Bank
        {
            private List<Account> accounts;

            public Bank()
            {
                accounts = new List<Account>();
            }

            public void CreateAccount(string fullName, string accountNumber, AccountType accountType, decimal amount, string note)
            {
                AccountManager accountManager = new AccountManager();
                accountManager.CreateAccount(accounts, fullName, accountNumber, accountType, amount, note);
            }

            public void Deposit(string accountNumber, decimal amount)
            {
                AccountManager accountManager = new AccountManager();
                accountManager.Deposit(accounts, accountNumber, amount);
            }

            public void Withdraw(string accountNumber, decimal amount)
            {
                AccountManager accountManager = new AccountManager();
                accountManager.Withdraw(accounts, accountNumber, amount);
            }

            public void Transfer(string fromAccountNumber, string toAccountNumber, decimal amount)
            {
                AccountManager accountManager = new AccountManager();
                accountManager.Transfer(accounts, fromAccountNumber, toAccountNumber, amount);
            }

            public void DisplayAccounts()
            {
                Console.WriteLine("|-------------------|-------------------------------|--------------------------|---------------------|----------|");
                Console.WriteLine("| FULL NAME         | ACCOUNT NUMBER                | ACCOUNT TYPE             | AMOUNT BAL          | NOTE     |");
                Console.WriteLine("|-------------------|-------------------------------|--------------------------|---------------------|----------|");

                foreach (var account in accounts)
                {
                    Console.WriteLine($"| {account.FullName,-18} | {account.AccountNumber,-29} | {account.AccountType,-24} | {account.Amount,-19} | {account.Note,-8} |");
                }

                Console.WriteLine("|--------------------------------------------------------------------------------------------------------------|");
            }
        }

     

       
    }

}