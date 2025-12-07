using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerFirstBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Consumer First Bank!");
            Console.WriteLine("Would you like to open a Checking/Savings account with us today?");

            string name = null;
            if (Console.ReadLine().ToLower() == "yes")
            {
                Console.WriteLine("Great! Let's get started. What is your name?");
                name = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("No worries! Have a great day!");
                return;
            }

            Console.WriteLine("Welcome {0}! Please set a 4-digit PIN for your account:", name);
            int validPin = Convert.ToInt32(Console.ReadLine());

            Patron patron = new Patron(name, validPin);
            Account account = new Account();
            AccountService accountService = new AccountService();
            Transaction transaction = new Transaction();


            Console.WriteLine("Thank you {0}. Your new Checking account number is {1}. Your Savings account number is {2}. Your 401k account number is {3}. Your Unique ID is {4}", 
                patron.Name, 
                account.AcctNumFor(AccountType.Checking),
                account.AcctNumFor(AccountType.Savings),
                account.AcctNumFor(AccountType._401k),
                patron.PatronId );

            bool banking = false;
            while (!banking)
            {
                Console.WriteLine("Please select from one of the folowing options : \n1. Checking\n2. Savings");
                int choice = Convert.ToInt32(Console.ReadLine());
                account.ChooseAccountService(choice);
                Console.WriteLine("You have selected {0}, account number {1}.", account.SelectedAccountType, account.CurrentAcctNum);
                Console.WriteLine("Please enter your pin to proceed:");
                int inputPin = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Please choose from the following options: \n1. Deposit\n2. Withdraw\n3. Transfer\n4. Check Balance\n5. Exit");
                int action = Convert.ToInt32(Console.ReadLine());

                switch (action)
                {
                    case 1:
                        Console.WriteLine("Enter amount to deposit:");
                        decimal depAmount = Convert.ToDecimal(Console.ReadLine());
                        decimal newBal = account.Deposit(depAmount);
                        var lastTx = account.Transactions.Last();
                        Console.WriteLine("Deposit of {0:C} to {1} account successful. New balance is {2:C}. Transaction ID: {3}", depAmount, account.SelectedAccountType, newBal, lastTx.TransactionId);
                        break;
                    case 2:
                        Console.WriteLine("Enter amount to withdraw:");
                        decimal withAmount = Convert.ToDecimal(Console.ReadLine());
                     
                        break;
                }
            }
        }
    }
}
