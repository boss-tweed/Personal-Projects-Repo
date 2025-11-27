using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerFirstBank
{
    public class Account
    {
        private readonly object _balanceLock = new object();

        public string AccountType { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }

        public List<Transaction> Transactions { get; } = new List<Transaction>();

        public string ChooseAcct(int value)
        {
            switch (value)
            {
                case 1:
                    AccountType = "Checking";
                    break;
                case 2:
                    AccountType = "Savings";
                    break;
            }

            const int accountNumberDigits = 9;
            if (string.IsNullOrEmpty(AccountNumber))
            {
                AccountNumber = UniqueIdGenerator.Instance.NextNumericId(accountNumberDigits);
            }

            return AccountType;
        }

        public string AssignUniqueAccountNumber(int digits = 9)
        {
            AccountNumber = UniqueIdGenerator.Instance.NextNumericId(digits);
            return AccountNumber;
        }

        // Deposit that delegates to Transaction.MakeDeposit and records the transaction when successful
        public bool Deposit(decimal amount)
        {
            // Transaction.MakeDeposit already validates amount and updates balance.
            var tx = new Transaction();
            var success = tx.MakeDeposit(this, amount);
            if (success)
            {
                lock (_balanceLock)
                {
                    // MakeDeposit already updated account.Balance, but lock to keep consistency in concurrent scenarios.
                    Balance = this.Balance;
                }
                Transactions.Add(tx);
            }
            return success;
        }
    }
}
