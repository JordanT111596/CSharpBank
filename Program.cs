using System;

using BankLibrary;

namespace CSharpBank
{
    class Program
    {
        static void Main(string[] args)
        {
            //asks user for their name
            Console.WriteLine("Please enter your name:");
            //sets account name to the user's input
            string accountName = Convert.ToString(Console.ReadLine());
            //asks user to enter their initial deposit
            Console.WriteLine("What is your opening deposit?");
            //sets initDeposit to the user's input
            decimal initDeposit = Convert.ToDecimal(Console.ReadLine());
            //creates new account with user-provided name and deposit
            var account = new BankAccount(accountName, initDeposit);
            //Account creation successful line
            Console.WriteLine($"Success! Account {account.Number} was created for {account.Owner} with ${account.Balance} initial balance.");

            //menu appears for user asking if they want to withdraw, deposit, view account history, or exit
            //if user wants to withdraw, ask them for amount and description, then show success message, then back to menu
            //if user wants to deposit, ask them for amount and description, then show success message, then back to menu
            //if user wants to view account history, display the history, then back to menu
            //if user wants to exit, then show exit message, then exit the applicaiton

            //Showing examples of transactions at work
            account.MakeWithdrawal(1100, DateTime.Now, "Rent payment");
            Console.WriteLine($"The balance is now {account.Balance}");
            account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
            Console.WriteLine($"The balance is now {account.Balance}");

            // // Test that the initial balances must be positive.
            // try
            // {
            //     var invalidAccount = new BankAccount("invalid", -55);
            // }
            // catch (ArgumentOutOfRangeException e)
            // {
            //     Console.WriteLine("Exception caught creating account with negative balance");
            //     Console.WriteLine(e.ToString());
            // }

            // account.MakeWithdrawal(60, DateTime.Now, "Bought Ghost of Tsushima");

            // // Test for a negative balance.
            // try
            // {
            //     account.MakeWithdrawal(1000, DateTime.Now, "Attempt to overdraw");
            // }
            // catch (InvalidOperationException e)
            // {
            //     Console.WriteLine("Exception caught trying to overdraw");
            //     Console.WriteLine(e.ToString());
            // }

            //Shows account history after previous hard coded transactions
            Console.WriteLine(account.GetAccountHistory());
        }
    }
}
