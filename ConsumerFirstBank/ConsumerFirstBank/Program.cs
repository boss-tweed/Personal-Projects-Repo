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

            //After patron is created, create checking and savings accounts
            var checking = new Account { AccountType = "Checking" };
            checking.AssignUniqueAccountNumber();
            var savings = new Account { AccountType = "Savings" };
            savings.AssignUniqueAccountNumber();

            patron.Accounts.Add(checking);
            patron.Accounts.Add(savings);

            //Use the RandomAcctNum/AssignAcctNum method to assign an acct number to user
            Console.WriteLine("Thank you {0}. Your new checking account number is {1}. Your savings account number is {2}. Your Unique ID is {3}", 
            patron.Name, checking.AccountNumber, savings.AccountNumber, patron.PatronId);

            
            Transaction transaction = new Transaction();

            bool banking = false;
            while (!banking)
            {
                Console.WriteLine("Please select from one of the folowing options : \n1. Checking\n2. Savings");
                int choice = Convert.ToInt32(Console.ReadLine());
                account.ChooseAcct(choice);
                Console.WriteLine("You have selected a {0} account.", account.AccountType);
                Console.WriteLine("Please enter your pin");
                int inputPin;
                string pinInput = Console.ReadLine();   

                if (!int.TryParse(pinInput, out inputPin))
                {
                    Console.WriteLine("Invalid entry. Please try again.");
                    continue;
                }
                
                if (inputPin == patron.Pin)
                {
                    Console.WriteLine("Authentication successful. Press Enter to proceed to transaction selection.");

                }
                Console.ReadLine();

                //Set transaction account type
                transaction.AccountType = account.AccountType;

                Console.WriteLine("Please chose from one of the following selections:");
                Console.WriteLine("\n1. Deposit\n2. Withdrawal\n3. Transfer\n4. Exit");

                int transactionChoice;
                if (!int.TryParse(Console.ReadLine(), out transactionChoice))
                {
                    Console.WriteLine("Invalid entry. Please try again.");
                    continue;
                }

                switch (transactionChoice)
                {
                    case 1: //Deposit
                        Console.WriteLine("Please enter a deposit amount");
                        decimal depAmount;
                        if (!decimal.TryParse(Console.ReadLine(), out depAmount))
                        {
                            Console.WriteLine("Invalid amount. Please try again.");
                            continue;
                        }
                        transaction.MakeDeposit(account, depAmount);
                        break;

                    case 2: //Withdrawal
                        Console.WriteLine("Please enter a withdrawal amount");
                        decimal withAmount;
                        if (!decimal.TryParse(Console.ReadLine(), out withAmount))
                        {
                            Console.WriteLine("Invalid amount. Please try again.");
                            continue;
                        }
                        transaction.MakeWithdrawal(account, withAmount);
                        break;
                }

            }
        }
    }
}
