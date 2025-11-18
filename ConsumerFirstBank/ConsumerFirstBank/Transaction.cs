using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerFirstBank
{
    public class Transaction
    {
        public decimal Amount { get; set; }

        public string AccountType { get; set; }
        public string TransactionType { get; set; }

        public decimal Balance { get; set; }

        public void MakeWithdrawal(decimal amount, decimal balance, int value)
        {
            if (value == 1 && AccountType == "Checking")
            {
                if (amount > balance)
                {
                    Console.WriteLine("Insufficient funds in Checking account.\nPlease try again.");
                }
                else
                {
                    Amount = amount;
                    balance -= amount;
                    Balance = balance;
                    Console.WriteLine("Withdrawal of {0:C} from Checking account successful. New balance: {1:C}", Amount, Balance);
                }
            }
            else if (value == 2 && AccountType == "Savings")
            {
                if (amount > balance)
                {
                    Console.WriteLine("Insufficient funds in Savings account.\nPlease try again.");
                }
                else
                {
                    Amount = amount;
                    balance -= amount;
                    Balance = balance;
                    Console.WriteLine("Withdrawal of {0:C} from Savings account successful. New balance: {1:C}", Amount, Balance);  
                }
            }

        }
    }
}
