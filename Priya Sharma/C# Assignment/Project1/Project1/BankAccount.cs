using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project1
{
    public class BankAccount
    {
        public Guid AccountNumber = Guid.NewGuid();
        public string Name;
        public double Balance;

        public BankAccount()
        {

        }

        List<BankAccount> accounts = new List<BankAccount>();

        public void CreateAccount()
        { 
            BankAccount acc = new BankAccount();

            Console.Write("Enter Name: ");
            acc.Name = Console.ReadLine();

            acc.Balance = 0;

            accounts.Add(acc); 

            Console.WriteLine("Account Number: " + acc.AccountNumber);
            Console.WriteLine("Account Created Successfully");
        }

        

        public BankAccount FindAccount(string accNo)
        {
            Guid inputGuid;

            if (!Guid.TryParse(accNo, out inputGuid))
            {
                return null;
            }

            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].AccountNumber == inputGuid)
                {
                    return accounts[i];
                }
            }

            return null;
        }

        public void Deposit()
        {
            Console.Write("Enter Account Number: ");
            string accNo = Console.ReadLine();

            BankAccount acc = FindAccount(accNo);

            if (acc == null)
            {
                Console.WriteLine("Invalid Account");
                return;
            }

            Console.Write("Enter Amount to Deposit: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            acc.Balance += amount;
            Console.WriteLine("Amount Deposited Successfully");
        }

        public void Withdraw()
        {
            Console.Write("Enter Account Number: ");
            string accNo = Console.ReadLine();

            BankAccount acc = FindAccount(accNo);

            if (acc == null)
            {
                Console.WriteLine("Invalid Account");
                return;
            }

            Console.Write("Enter Amount to Withdraw: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            if (acc.Balance >= amount)
            {
                acc.Balance -= amount;
                Console.WriteLine("Withdrawal Successful");
            }
            else
            {
                Console.WriteLine("Low Balance");
            }
        }

        public void CheckBalance()
        {
            Console.Write("Enter Account Number: ");
            string accNo = Console.ReadLine();

            BankAccount acc = FindAccount(accNo);

            if (acc == null)
            {
                Console.WriteLine("Invalid Account");
                return;
            }

            if (acc.Balance > 0)
                Console.WriteLine("Current Balance: " + acc.Balance);
            else
                Console.WriteLine("No Balance");
        }

        public void DisplayDetails()
        {
            Console.Write("Enter Account Number: ");
            string accNo = Console.ReadLine();

            BankAccount acc = FindAccount(accNo);

            if (acc == null)
            {
                Console.WriteLine("Invalid Account");
                return;
            }

            Console.WriteLine("\nAccount Details");
            Console.WriteLine("Name: " + acc.Name);
            Console.WriteLine("Account Number: " + acc.AccountNumber);
            Console.WriteLine("Balance: " + acc.Balance);
        }

        public void Run()
        {
            int option;
            do
            {
                Console.WriteLine("\nBank Account :-");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. WithDraw");
                Console.WriteLine("4. Check Balance");
                Console.WriteLine("5. Display Account Details");
                Console.WriteLine("6. Exit\n");
                Console.Write("Enter Option: ");

                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        CreateAccount();
                        break;

                    case 2:
                        Deposit();
                        break;

                    case 3:
                        Withdraw();
                        break;

                    case 4:
                        CheckBalance();
                        break;

                    case 5:
                        DisplayDetails();
                        break;

                    case 6:
                        Console.WriteLine("Program Exit");
                        break;

                    default:
                        Console.WriteLine("Invalid ! try again...");
                        break;
                }
            } while (option != 6);
        }
    }
}




