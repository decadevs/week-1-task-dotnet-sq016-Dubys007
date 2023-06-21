using Console_Bank_App_Assignment.BankApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Bank_App_Assignment
{

    public class AccountManager
    {
        public void CreateAccount(List<Account> accounts, string fullName, string accountNumber, AccountType accountType, decimal amount, string note)
        {
            // Check if the account already exists
            if (GetAccount(accounts, accountNumber) != null)
            {
                Console.WriteLine("Account with the given account number already exists.");
                return;
            }

            // Check if the user already has an account of the same type
            if (GetAccountByFullNameAndType(accounts, fullName, accountType) != null)
            {
                Console.WriteLine("User already has an account of the same type.");
                return;
            }

            // Sanitize the full name
            fullName = SanitizeFullName(fullName);

            // Create the account
            Account account = new Account(fullName, accountNumber, accountType, amount, note);
            accounts.Add(account);
        }

        public void Deposit(List<Account> accounts, string accountNumber, decimal amount)
        {
            Account account = GetAccount(accounts, accountNumber);
            if (account != null)
            {
                account.Deposit(amount);
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        public void Withdraw(List<Account> accounts, string accountNumber, decimal amount)
        {
            Account account = GetAccount(accounts, accountNumber);
            if (account != null)
            {
                account.Withdraw(amount);
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        public void Transfer(List<Account> accounts, string fromAccountNumber, string toAccountNumber, decimal amount)
        {
            Account fromAccount = GetAccount(accounts, fromAccountNumber);
            Account toAccount = GetAccount(accounts, toAccountNumber);

            if (fromAccount != null && toAccount != null)
            {
                fromAccount.Withdraw(amount);
                toAccount.Deposit(amount);
            }
            else
            {
                Console.WriteLine("One or both accounts not found.");
            }
        }

        private Account GetAccount(List<Account> accounts, string accountNumber)
        {
            foreach (var account in accounts)
            {
                if (account.AccountNumber == accountNumber)
                {
                    return account;
                }
            }

            return null;
        }

        private Account GetAccountByFullNameAndType(List<Account> accounts, string fullName, AccountType accountType)
        {
            foreach (var account in accounts)
            {
                if (account.FullName == fullName && account.AccountType == accountType)
                {
                    return account;
                }
            }

            return null;
        }

        private string SanitizeFullName(string fullName)
        {
            if (char.IsDigit(fullName[0]) || char.IsLower(fullName[0]))
            {
                fullName = char.ToUpper(fullName[0]) + fullName.Substring(1);
            }

            return fullName;
        }
    }


}
