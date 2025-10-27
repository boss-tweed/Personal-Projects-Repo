namespace Bank
{
    class Account
    {
        static void Main(string[] args)
        {
            int balance = 0;
            string pin = "0488";

            string Name = "Garrett's Checking";
            //Print greeting and console options to choose from
            Console.WriteLine("Welcome to C# Bank " + Name);
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Make A Deposit");
            Console.WriteLine("3. Make A Withdrawl");
            Console.WriteLine("Exit. Type 'exit' to leave the application");

            var choice = string.Empty;

            while (choice != "exit")            {
                Console.WriteLine("Please make a selection: ");
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    CheckBalance(pin, balance);
                }

                else if (choice == "2")
                {
                    balance = MakeDeposit(pin, balance);
                }

                else if (choice == "3")
                {
                    balance = MakeWithdrawal(pin, balance);
                }
            }

        }

        private static void CheckBalance(string pin, int balance)
        {
            Console.WriteLine("Enter pin to show balance: ");

            string PinInput = Console.ReadLine() ?? "Guest";

            if (PinInput == pin)
            {
                Console.WriteLine("Login Success!");

                Console.WriteLine("Your Balance is: $" + balance);

                Console.WriteLine("Please make another selection");
            }
        }

        private static int MakeDeposit(string pin, int balance)
        {
            Console.WriteLine("Enter pin to make a deposit: ");

            string PinInput = Console.ReadLine() ?? "Guest";

            if (PinInput == pin)
            {
                Console.WriteLine("Login Success!");

                Console.WriteLine("Please enter an amount you wish to deposit: $");

                int AnyAmount = Convert.ToInt32(Console.ReadLine());

                if (AnyAmount >= 0)
                {
                    Console.WriteLine("You have deposited: $" + AnyAmount);
                    balance += AnyAmount;

                    Console.WriteLine("Your new balance is: $" + balance + "!");
                }
            }
            return balance;
        }

        private static int MakeWithdrawal(string pin, int balance)
        {
            Console.WriteLine("Enter pin to make a withdrawal: ");

            string PinInput = Console.ReadLine() ?? "Guest";

            if (PinInput == pin)
            {
                Console.WriteLine("Login Success!");

                Console.WriteLine("Please enter an amount you wish to withdraw: $");

                int AnyAmount = Convert.ToInt32(Console.ReadLine());

                if (AnyAmount < balance)
                {
                    Console.WriteLine("You have withdrawn: $" + AnyAmount);
                    balance -= AnyAmount;

                    Console.WriteLine("Your new balance is: $" + balance + "!");
                }

                else if (AnyAmount > balance)
                {
                    Console.WriteLine("Please choose an amount that does not exceed your current balance of: $" + balance);
                }
            }
            return balance;

        }
    }

}