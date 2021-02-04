using System;
using System.Collections.Generic;

namespace CSharpBank
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
    }
}