using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerFirstBank
{
    public class AccountService
    {
        //Map numeric input to AccountType class enum and call ChooseAccount
        public bool ChooseAccount(Account account, int value, out string error)
        {
            error = null;
            if (account == null)
            {
                error = "Account cannot be null.";
                return false;
            }

            if (!Enum.IsDefined(typeof(AccountType), value))
            {
                error = "Invalid selection.";
                return false;
            }
            
            var acctType = (AccountType)value;
            return ChooseAccount(account, acctType, out error);
        }

        //Directly choose account type by enum
        public bool ChooseAccount(Account account, AccountType acctType, out string error)
        {
            error = null;
            if (account == null)
            {
                error = "Account cannot be null.";
                return false;
            }
            account.ChooseAccountService((int)acctType + 1); // +1 to match menu options
            return true;
        } 
    }
}
