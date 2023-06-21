using Console_Bank_App_Assignment.BankApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Bank_App_Assignment
{

    public class Account
    {
        public string FullName { get; }
        public string AccountNumber { get; }
        public AccountType AccountType { get; }
        public decimal Amount { get; private set; }
        public string Note { get; }

        public Account(string fullName, string accountNumber, AccountType accountType, decimal amount, string note)
        {
            FullName = fullName;
            AccountNumber = accountNumber;
            AccountType = accountType;
            Amount = amount;
            Note = note;
        }

        public void Deposit(decimal amount)
        {
            Amount += amount;
            Console.WriteLine($"Deposited {amount} into account {AccountNumber}. New balance: {Amount}");
        }

        public void Withdraw(decimal amount)
        {
            if (AccountType == AccountType.Savings && Amount - amount < 1000)
            {
                Console.WriteLine($"Insufficient funds. Minimum balance for a savings account: 1000");
                return;
            }

            if (AccountType == AccountType.Current && Amount - amount < 0)
            {
                Console.WriteLine($"Insufficient funds in current account.");
                return;
            }

            Amount -= amount;
            Console.WriteLine($"Withdrawn {amount} from account {AccountNumber}. New balance: {Amount}");
        }
    }


}
