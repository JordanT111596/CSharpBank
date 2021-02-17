using System;
using System.Collections.Generic;

namespace BankLibrary
{
    public class BankAccount
    {
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }
        //Account number seed to start with
        private static int accountNumberSeed = 1674513240;

        //List for holding transactions
        private List<Transaction> allTransactions = new List<Transaction>();

        //Constructor for the Bank Account
        public BankAccount(string name, decimal initialBalance)
        {
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;

            this.Owner = name;
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
        }
        //Function for making a deposit with exceptions handled
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "You can't just deposit nothing! Nor make a negative deposit!");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        //Function for making a withdrawal with exceptions handled
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "You must withdraw a positive number from your available balance");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("You don't have enough for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }

        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            //Header for table
            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");

            //Transactions being iterated through, then appended to the string
            foreach (var item in allTransactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }

            return report.ToString();
        }
        //Method for bringing up menu UI
        public void runMenu()
        {
            //try again boolean
            bool againTry = true;
            //initializes the choice integer variable
            Int32 choice;
            //handles menu choice exceptions
            while (againTry)
            {
                try
                {
                    //loop begins that runs menu and functions until exit is chosen
                    do
                    {
                        //menu appears for user asking if they want to withdraw, deposit, view account history, or exit
                        Console.WriteLine("\nWhat would you like to do?\n1. Make a Withdrawal\n2. Make a Deposit\n3. View Account History\n4. Exit");
                        //User choice is stored in the variable after converting to int
                        choice = Convert.ToInt32(Console.ReadLine());

                        //switch case to decide what to do based on user option
                        switch (choice)
                        {
                            //if user wants to withdraw, ask them for amount and description, then show success message, then back to menu
                            case 1:
                                Console.WriteLine("\n---------------------------------------------------------------------------");
                                Console.WriteLine("How much would you like to withdraw?");
                                Console.WriteLine("---------------------------------------------------------------------------");
                                var withTotal = Convert.ToDecimal(Console.ReadLine());
                                Console.WriteLine("\n---------------------------------------------------------------------------");
                                Console.WriteLine("Describe this transaction:");
                                Console.WriteLine("---------------------------------------------------------------------------");
                                String withDesc = Convert.ToString(Console.ReadLine());
                                MakeWithdrawal(withTotal, DateTime.Now, withDesc);
                                Console.WriteLine($"\nSuccess! Your withdrawal of ${withTotal} for {withDesc} was made at {DateTime.Now}!\nThat leaves you with a balance of ${Balance}");
                                break;
                            //if user wants to deposit, ask them for amount and description, then show success message, then back to menu
                            case 2:
                                Console.WriteLine("\n---------------------------------------------------------------------------");
                                Console.WriteLine("How much would you like to deposit?");
                                Console.WriteLine("---------------------------------------------------------------------------");
                                var depTotal = Convert.ToDecimal(Console.ReadLine());
                                Console.WriteLine("\n---------------------------------------------------------------------------");
                                Console.WriteLine("Describe this transaction:");
                                Console.WriteLine("---------------------------------------------------------------------------");
                                String depDesc = Convert.ToString(Console.ReadLine());
                                MakeDeposit(depTotal, DateTime.Now, depDesc);
                                Console.WriteLine($"\nSuccess! Your deposit of ${depTotal} for {depDesc} was made at {DateTime.Now}!\nThat leaves you with a balance of ${Balance}");
                                break;
                            //if user wants to view account history, display the history, then back to menu
                            case 3:
                                Console.WriteLine($"\nHistory for Account owner: {Owner}\tAccount Number: {Number}\n");
                                Console.WriteLine(GetAccountHistory());
                                break;
                            //if user wants to exit, then exit the applicaiton
                            case 4:
                                Console.WriteLine("\n***************************************************************************");
                                break;
                            //Any other choice is brought back to the menu until a correct option is chosen
                            default:
                                Console.WriteLine("\nPlease enter either 1, 2, 3, or 4 to make your selection!");
                                break;
                        }
                    }
                    while (choice != 4);

                    //Exit message
                    Console.WriteLine("\nThank you for banking with Jordan's C Sharp!");
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("\nTry again, but this time with an appropiate number if you want this to work!");
                }
            }
        }
    }
}