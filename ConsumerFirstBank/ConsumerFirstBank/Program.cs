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

            //Use the RandomAcctNum/AssignAcctNum method to assign an acct number to user
            Console.WriteLine("Thank you {0}. Your new account number is {1}.", patron.Name, patron.AccountNumber);

            Account account = new Account();
            Transaction transaction = new Transaction();

            Console.WriteLine("Please select from one of the folowing options : \n1. Checking\n2. Savings");
            int choice = Convert.ToInt32(Console.ReadLine());
            account.ChooseAcct(choice);
            Console.WriteLine("You have selected a {0} account.", account.AccountType);
            Console.WriteLine("Please enter your pin");
            int pinEntry = Convert.ToInt32(Console.ReadLine());

            if (pinEntry == patron.Pin)
            {

            }



        }
    }
}
