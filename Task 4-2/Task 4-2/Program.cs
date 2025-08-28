namespace Task_4_2
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    public static class AccountUtil
    {
        public static void Display(List<Account> accounts)
        {
            Console.WriteLine("\n=== Display ======================================");
            foreach (var acc in accounts)
                Console.WriteLine(acc);
        }

        public static void Deposit(List<Account> accounts, double amount)
        {
            Console.WriteLine($"\n=== Deposit ({amount}) ===============================");
            foreach (var acc in accounts)
            {
                if (acc.Deposit(amount))
                    Console.WriteLine($"Deposited {amount} to {acc}");
                else
                    Console.WriteLine($"Failed to deposit {amount} to {acc}");
            }
        }

        public static void Withdraw(List<Account> accounts, double amount)
        {
            Console.WriteLine($"\n=== Withdraw ({amount}) ==============================");
            foreach (var acc in accounts)
            {
                if (acc.Withdraw(amount))
                    Console.WriteLine($"Withdrew {amount} from {acc}");
                else
                    Console.WriteLine($"Failed to withdraw {amount} from {acc}");
            }
        }
    }


    public class Account
    {
        private string name;
        protected double balance;

        public Account(string name = "Unnamed Account", double balance = 0.0)
        {
            this.name = name;
            this.balance = balance;
        }

        public virtual bool Deposit(double amount)
        {
            if (amount < 0)
                return false;
            else
            {
                balance += amount;
                return true;
            }
        }

        public virtual bool Withdraw(double amount)
        {
            if (amount < 0) return false;
            if (balance - amount >= 0)
            {
                balance -= amount;
                return true;
            }
            return false;
        }

        public double GetBalance() => balance;
        public override string ToString() => $"[Account: {name}: {balance}]";
    }
    public class SavingAccount : Account
    {
        public double InterestRate { get; set; }

        public SavingAccount(string name = "Unnamed Savings Account", double balance = 0.0, double interestRate = 0.025)
            : base(name, balance)  { InterestRate = interestRate; }
        public override bool Deposit(double amount)
        {
            if (base.Deposit(amount))
            {
                double interest = amount * InterestRate;
                base.Deposit(interest);
                return true;
            }
            return false;
        }
        public override string ToString() => $"[SavingsAccount: {GetBalance()}, Interest Rate: {InterestRate}]";
    }

    public class CheckingAccount : Account
    {
        private const double Fee = 1.50;

        public CheckingAccount(string name = "Unnamed Checking Account", double balance = 0.0)
            : base(name, balance) { }
        public override bool Withdraw(double amount)
        {
            return base.Withdraw(amount + Fee);
        }
        public override string ToString() => $"[CheckingAccount: {GetBalance()}, Fee: {Fee}]";
    }
    public class TrustAccount : SavingAccount
    {
        private int withdrawals = 0;
        private const int MaxWithdrawals = 3;
        private const double BonusThreshold = 5000.00;
        private const double BonusAmount = 50.00;
        public TrustAccount(string name = "Unnamed Trust Account", double balance = 0.0, double interestRate = 0.025) : base(name, balance) { }
        public override bool Deposit(double amount)
        {
            if (base.Deposit(amount) == false )
                return false;
            double interest = amount * InterestRate;
            base.Deposit(interest);
            if (amount >= BonusThreshold)
            {
                base.Deposit(BonusAmount);
            }
            return true;
        }

        public override bool Withdraw(double amount)
        {
            if (withdrawals >= MaxWithdrawals)
                return false;

            if (amount > (GetBalance() * 0.2))
                return false;

            withdrawals++;
            return base.Withdraw(amount);
        }
        public override string ToString() => $"[TrustAccount: {GetBalance():C}, Interest Rate: {InterestRate}, Withdrawals: {withdrawals}/{MaxWithdrawals}]";
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Accounts
            var accounts = new List<Account>
    {
        new Account(),
        new Account("Larry"),
        new Account("Moe", 2000),
        new Account("Curly", 5000)
    };

            AccountUtil.Display(accounts);
            AccountUtil.Deposit(accounts, 1000);
            AccountUtil.Withdraw(accounts, 2000);

            // Savings
            var savAccounts = new List<Account>
    {
        new SavingAccount(),
        new SavingAccount("Superman"),
        new SavingAccount("Batman", 2000),
        new SavingAccount("Wonderwoman", 5000)
    };

            AccountUtil.Display(savAccounts);
            AccountUtil.Deposit(savAccounts, 1000);
            AccountUtil.Withdraw(savAccounts, 2000);

            // Checking
            var checAccounts = new List<Account>
    {
        new CheckingAccount(),
        new CheckingAccount("Larry2"),
        new CheckingAccount("Moe2", 2000),
        new CheckingAccount("Curly2", 5000)
    };

            AccountUtil.Display(checAccounts);
            AccountUtil.Deposit(checAccounts, 1000);
            AccountUtil.Withdraw(checAccounts, 2000);
            AccountUtil.Withdraw(checAccounts, 2000);

            // Trust
            var trustAccounts = new List<Account>
    {
        new TrustAccount(),
        new TrustAccount("Superman2"),
        new TrustAccount("Batman2", 2000),
        new TrustAccount("Wonderwoman2", 5000)
    };

            AccountUtil.Display(trustAccounts);
            AccountUtil.Deposit(trustAccounts, 1000);
            AccountUtil.Deposit(trustAccounts, 6000);
            AccountUtil.Withdraw(trustAccounts, 2000);
            AccountUtil.Withdraw(trustAccounts, 3000);
            AccountUtil.Withdraw(trustAccounts, 500);
        }
    }
}


