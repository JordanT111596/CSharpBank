using System;

using BankLibrary;

namespace CSharpBank
{
    class Program
    {
        static void Main(string[] args)
        {
            bool tryAgain = true;
            var account = new BankAccount("", 1);
            //asks user for their name
            Console.WriteLine("Please enter your name:");
            //sets account name to the user's input
            string accountName = Convert.ToString(Console.ReadLine());
            //asks user to enter their initial deposit
            Console.WriteLine("What is your opening deposit?");
            //Loop created to catch format exceptions on the opening deposit
            while (tryAgain)
            {
                try
                {
                    //sets initDeposit to the user's input
                    decimal initDeposit = Convert.ToDecimal(Console.ReadLine());
                    if (initDeposit <= 0)
                    {
                        throw new ArgumentOutOfRangeException(nameof(initDeposit), "You can't just open an account with nothing! Or a negative balance!");
                    }
                    //Makes sure we don't loop again
                    tryAgain = false;
                    //creates new account with user-provided name and deposit
                    account = new BankAccount(accountName, initDeposit);
                    //Account creation successful line
                    Console.WriteLine($"\nSuccess! Account {account.Number} was created for {account.Owner} with ${account.Balance} initial balance.");
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Please enter a positive number for your opening deposit");
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine("You can't just open an account with nothing! Or a negative balance!");
                }
            }
            //Begins running the menu after account creation
            account.runMenu();
        }
    }
}
