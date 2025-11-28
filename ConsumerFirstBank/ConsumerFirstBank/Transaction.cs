using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerFirstBank
{
    public class Transaction
    {
        public string TransactionId { get; set; }
        public decimal Amount { get; set; }
        public string AccountType { get; set; }
        public string TransactionType { get; set; }
        public decimal Balance { get; set; }

        public Transaction()
        {
            // Assign unique transaction id on creation
            TransactionId = UniqueIdGenerator.Instance.NextTransactionId();
        }

        // Perform a withdrawal on an Account instance. Returns true if successful.
        public bool MakeWithdrawal(Account account, decimal amount)
        {
            if (account == null) throw new ArgumentNullException(nameof(account));
            AccountType = account.AccountType;
            TransactionType = "Withdrawal";
            Amount = amount;

            if (amount <= 0m)
            {
                Console.WriteLine("Invalid withdrawal amount.");
                return false;
            }

            if (amount > account.Balance)
            {
                Console.WriteLine("Insufficient funds in {0} account. Please try again.", account.AccountType);
                return false;
            }

            account.Balance -= amount;
            Balance = account.Balance;

            Console.WriteLine("Transaction {0}: Withdrawal of {1:C} from {2} account successful. New balance: {3:C}",
                TransactionId, Amount, AccountType, Balance);
            return true;
        }

        // Perform a deposit on an Account instance. Returns true if successful.
        public bool MakeDeposit(Account account, decimal amount)
        {
            if (account == null) throw new ArgumentNullException(nameof(account));
            AccountType = account.AccountType;
            TransactionType = "Deposit";
            Amount = amount;

            account.Balance += amount;
            Balance = account.Balance;

            Console.WriteLine("Transaction {0}: Deposit of {1:C} to {2} account #{3} successful. New balance: {4:C}",
                TransactionId, Amount, AccountType, account.AccountNumber, Balance);
            return true;
        }        
    }           
}
