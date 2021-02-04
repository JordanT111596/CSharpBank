using System;

namespace CSharpBank
{
    class Program
    {
        static void Main(string[] args)
        {
            //creates new account with my name
            var account = new BankAccount("Jordan", 2000);
            //Account creation successful line
            Console.WriteLine($"Success! Account {account.Number} was created for {account.Owner} with ${account.Balance} initial balance.");

            //Showing examples of transactions at work
            account.MakeWithdrawal(1100, DateTime.Now, "Rent payment");
            Console.WriteLine(account.Balance);
            account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
            Console.WriteLine(account.Balance);

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
