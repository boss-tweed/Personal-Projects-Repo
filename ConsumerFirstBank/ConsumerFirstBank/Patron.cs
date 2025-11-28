using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerFirstBank
{
    public class Patron
    {
        //Properties
        public string Name { get; set; }
        public int Pin { get; set; }
        public int AccountNumber { get; set; }
        public string PatronId { get; private set; }
        public List<Account> Accounts { get; set; } = new List<Account>();

        public Patron(string name, int validPin)
        {
            Name = name;
            Pin = validPin;
            // Assign unique patron id
            PatronId = UniqueIdGenerator.Instance.NextPatronId();

            //Create and persit a checking and savings account for the patron
            var checking = new Account { AccountType = "Checking" };
            checking.AssignUniqueAccountNumber();
            
            var savings = new Account { AccountType = "Savings" };
            savings.AssignUniqueAccountNumber();

            Accounts.Add(checking);
            Accounts.Add(savings);
        }

    }
}
