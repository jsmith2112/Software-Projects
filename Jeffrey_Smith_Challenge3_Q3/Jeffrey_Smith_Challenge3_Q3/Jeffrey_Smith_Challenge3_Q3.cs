using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeffrey_Smith_Challenge3_Q3
{
    public class BankAccount
    {
        public string AccountHolder { get; set; }
        public decimal Balance { get; private set; }

        public BankAccount(string accountHolder, decimal initialBalance = 0)
        {
            AccountHolder = accountHolder;
            Balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            // TODO: if amount is negative, throw ArgumentOutOfRangeException
            // TODO: otherwise add to Balance
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Deposit amount cannot be negative.");
            }
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            // TODO: if amount is negative, throw ArgumentOutOfRangeException
            // TODO: if amount > Balance, throw InvalidOperationException (insufficient funds)
            // TODO: otherwise subtract from Balance
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Withdrawal amount cannot be negative.");
            }
            if (amount > Balance)
            {
                throw new InvalidOperationException("Insufficient funds for this withdrawal.");
            }
            Balance -= amount;
        }

        public void DisplayAccountInfo()
        {
            Console.WriteLine($"Holder: {AccountHolder}, Balance: {Balance:C}");
        }
    }

    public class Bank
    {
        private List<BankAccount> accounts = new List<BankAccount>();

        public void AddAccount(BankAccount account)
        {
            // TODO: if account with same holder exists, throw InvalidOperationException
            // TODO: otherwise add to the list
            if (accounts.Any(a => a.AccountHolder == account.AccountHolder))
            {
                throw new InvalidOperationException("An account with this holder already exists.");
            }
            accounts.Add(account);
        }

        public BankAccount GetAccountByHolder(string holder)
        {
            // TODO: find account by holder, if not found throw KeyNotFoundException
            if (!accounts.Any(a => a.AccountHolder == holder))
            {
                throw new KeyNotFoundException("Account with the specified holder not found.");
            }
            return accounts.First(a => a.AccountHolder == holder);
        }

        public void DisplayAccounts()
        {
            // TODO: if no accounts, print message or throw InvalidOperationException per your design
            // TODO: otherwise display each account
            if (accounts.Count == 0)
            {
                Console.WriteLine("No accounts available.");
                return;
            }
            foreach (var account in accounts)
            {
                account.DisplayAccountInfo();
            }
        }
    }

    class Jeffrey_Smith_Challenge3_Q3
    {
        static void Main(string[] args)
        {
            // TODO: Create Bank and BankAccount objects. Use try-catch to test:
            // try depositing a negative amount
            // - withdrawing more than balance
            // - accessing a non-existent account

            Bank bank = new Bank();
            try
            {
                BankAccount account1 = new BankAccount("Alice", 1000);
                bank.AddAccount(account1);
                BankAccount account2 = new BankAccount("Bob", 500);
                bank.AddAccount(account2);
                bank.DisplayAccounts();
                account1.Deposit(200);
                //account1.Withdraw(1500); // This should throw an exception
                BankAccount nonExistentAccount = bank.GetAccountByHolder("Charlie"); // This should throw an exception
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"ArgumentOutOfRangeException: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"InvalidOperationException: {ex.Message}");
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine($"KeyNotFoundException: {ex.Message}");
            }
            
        }
    }

}
