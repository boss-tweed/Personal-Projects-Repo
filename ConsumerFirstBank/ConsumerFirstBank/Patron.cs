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
        public string AccountNumber { get; set; }
        public string PatronId { get; set; }
        public List<Account> Accounts { get; set; } = new List<Account>();

        public Patron(string name, int validPin)
        {
            Name = name;
            Pin = validPin;
            // Assign unique patron id
            PatronId = UniqueIdGenerator.Instance.NextPatronId();           
        }
    }
}
