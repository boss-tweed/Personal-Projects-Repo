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

        public string AccountType { get; private set; }
        public string CheckingAccountNumber { get; private set; }
        public string SavingsAccountNumber { get; private set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }

        //To keep balances separate for sub-accounts
        private readonly Dictionary<string, decimal> _balances = new Dictionary<string, decimal>
        {
            { "Checking", 0m },
            { "Savings", 0m }
        };

        public List<Transaction> Transactions { get; } = new List<Transaction>();

        //New: assign both unique numbers at creation so they are immediately available for printing
        public Account()
        {
            const int accountNumberDigits = 9;
            CheckingAccountNumber = UniqueIdGenerator.Instance.NextNumericId(accountNumberDigits);
            SavingsAccountNumber = UniqueIdGenerator.Instance.NextNumericId(accountNumberDigits);
        }

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
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), "Choose 1 for Checking or 2 for Savings.");
            }
            return AccountType;
        }

        //Get the current account number based on selected account type
        public string CurrentAcctNum
        {
            get
            {
                return AccountType == "Checking" ? CheckingAccountNumber
                     : AccountType == "Savings" ? SavingsAccountNumber
                     : null;
            }
        }

        //Get the account number for specific type w/o changing selection
        public string AcctNumFor(string acctType)
        {
            if (string.Equals(acctType, "Checking", StringComparison.OrdinalIgnoreCase))
                return CheckingAccountNumber;
            if (string.Equals(acctType, "Savings", StringComparison.OrdinalIgnoreCase))
                return SavingsAccountNumber;
            return null;
        }

        //Deposit that delegates to Transaction.MakeDeposit and records the transaction when successful
        //Operates on the currently selected account type
        public decimal Deposit(decimal amount)
        {
            if (string.IsNullOrEmpty(AccountType)) throw new InvalidOperationException("Account type not selected");
            if (amount <= 0m) throw new ArgumentOutOfRangeException(nameof(amount));

            lock (_balanceLock)
            {
                _balances[AccountType] += amount;
                return _balances[AccountType];
            }
        }
        //Withdrawal that delegates to Transaction.MakeWithdrawal and records the transaction when successful
        public bool Withdraw(decimal amount, out decimal newBal)
        {
            newBal = 0m;
            if (string.IsNullOrEmpty(AccountType)) throw new InvalidOperationException("Account type not selected");
            if (amount <= 0m) return false;

            lock (_balanceLock)
            {
                var current = _balances[AccountType];
                if (amount > current)
                {
                    newBal = current;
                    return false;
                }
                current -= amount;
                _balances[AccountType] = current;
                newBal = current;   
                return true;
            }
        }
    }
}
