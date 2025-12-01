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

            //Use the RandomAcctNum/AssignAcctNum method to assign an acct number to user
            Console.WriteLine("Thank you {0}. Your new Checking account number is {1}. Your Savings account number is {2}. Your Unique ID is {3}", 
                patron.Name, account.CheckingAccountNumber, account.SavingsAccountNumber, patron.PatronId );

            
            Transaction transaction = new Transaction();

            bool banking = false;
            while (!banking)
            {
                Console.WriteLine("Please select from one of the folowing options : \n1. Checking\n2. Savings");
                int choice = Convert.ToInt32(Console.ReadLine());
                account.ChooseAcct(choice);
                Console.WriteLine("You have selected {0}, account number {1}.", account.AccountType, account.CurrentAcctNum);
                Console.WriteLine("Please enter your pin to proceed:");
                int inputPin = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Please choose from the following options: \n1. Deposit\n2. Withdraw\n3. Transfer\n4. Check Balance\n5. Exit");
                int action = Convert.ToInt32(Console.ReadLine());

                switch (action)
                {
                    case 1:
                        Console.WriteLine("Enter amount to deposit:");
                        decimal depAmount = Convert.ToDecimal(Console.ReadLine());
                        transaction.MakeDeposit(account, depAmount);
                        break;
                    case 2:
                        Console.WriteLine("Enter amount to withdraw:");
                        decimal withAmount = Convert.ToDecimal(Console.ReadLine());
                        transaction.MakeWithdrawal(account, withAmount);
                        break;
                }
            }
        }
    }
}
