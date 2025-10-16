namespace Bank
{
    class Account
    {
        static void Main(string[] args)
        {
            int balance = 0;
            int pin = 0488;

            string Name = "Garrett's Checking";
            //Print greeting and console options to choose from
            Console.WriteLine("Welcome to C# Bank " + Name);
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Make A Deposit");
            Console.WriteLine("3. Make A Withdrawl");

            int Choice = Convert.ToInt32(Console.ReadLine());

            if (Choice == 1)
            {
                Console.WriteLine("Enter pin to show balance: ");

                int PinInput = Convert.ToInt32(Console.ReadLine());

                if (PinInput == pin)
                {
                    Console.WriteLine("Login Success!");

                    Console.WriteLine("Your Balance is: $" + balance);
                }

            }

            else if (Choice == 2)
            {
                Console.WriteLine("Enter pin to make a deposit: ");

                int PinInput = Convert.ToInt32(Console.ReadLine());

                if (PinInput == pin)
                {
                    Console.WriteLine("Login Success!");

                    Console.WriteLine("Please enter an amount you wish to deposit: $");

                    int AnyAmount = Convert.ToInt32(Console.ReadLine());

                    if (AnyAmount > balance)
                    {
                        Console.WriteLine("You have deposited: $" + AnyAmount);
                        balance += AnyAmount;

                        Console.WriteLine("Your new balance is: $" + balance + "!");
                    }
                }

            }
            
            else if (Choice == 3)
            {
                
            }
        }
    }
}