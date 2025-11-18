using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerFirstBank
{
    public class Account
    {
        public string AccountType { get; set; }

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
            return AccountType;
        }
    }
}
