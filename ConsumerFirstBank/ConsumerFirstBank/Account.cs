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
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public AccountType? SelectedAccountType { get; set; }

        //To keep balances separate for sub-accounts
        private readonly Dictionary<AccountType, decimal> _balances = new Dictionary<AccountType, decimal>
        {
            { AccountType.Checking, 0m },
            { AccountType.Savings, 0m },
            { AccountType._401k, 0m }
        };

        //Private Storge for individually generted sub-account numbers
        private readonly Dictionary<AccountType, string> _subAccountNumbers = new Dictionary<AccountType, string>();

        public Account()
        {
            AccountNumber = UniqueIdGenerator.Instance.NextAccountNumber();
        }

        public List<Transaction> Transactions { get; } = new List<Transaction>();

        public void ChooseAccountService(AccountType acctType)
        {
            SelectedAccountType = acctType;
        }
        
        public void ChooseAccountService(int value)
        {
            if (!Enum.IsDefined(typeof(AccountType), value))
                throw new ArgumentOutOfRangeException(nameof(value), "Choose a valid account type.");
            ChooseAccountService((AccountType)value);
        }

        //Lazily generate and return sub-account number for given account type
        public string AcctNumFor(AccountType acctType)
        {
            lock (_balanceLock)
            {
                if (!_subAccountNumbers.TryGetValue(acctType, out var num))
                {
                    num = UniqueIdGenerator.Instance.NextAccountNumber();
                    _subAccountNumbers[acctType] = num;
                }
                return num;
            }
        }

        public string CurrentAcctNum
        {
            get
            {
                if (!SelectedAccountType.HasValue) return null;
                return AcctNumFor(SelectedAccountType.Value);
            }
        }

        //Transaction methods


        //Deposit
        public decimal Deposit(decimal amount)
        {
            if (!SelectedAccountType.HasValue) throw new InvalidOperationException("Account type not selected");
            if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount));

            lock (_balanceLock)
            {
                var key = SelectedAccountType.Value;
                _balances[key] += amount;

                //Update balance (sum of sub-accounts)
                Balance = 0m;
                foreach (var v in _balances.Values) Balance += v;

                //Create and record a transaction locally
                var tx = new Transaction
                {
                    Amount = amount,
                    Balance = _balances[key]
                };

                Transactions.Add(tx);

                //Return new balance for selected sub-account
                return _balances[key];
            }
        }
    }
}
