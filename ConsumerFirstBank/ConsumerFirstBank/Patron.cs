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

        public Patron(string name, int validPin)
        {
            Name = name;
            Pin = validPin;
            AccountNumber = RandomAcctNum();
        }

        //Generates a random 6-digit account number
        public static int RandomAcctNum()
        {
            return new Random().Next(100000, 999999);
        }

        public void AssignAcctNum()
        {
            AccountNumber = RandomAcctNum();
        }

    }
}
