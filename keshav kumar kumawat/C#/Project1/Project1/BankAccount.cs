using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class BankAccount    
    {
        public Guid AccountNumber= Guid.NewGuid();
        public string AccountHolder { get; set; }
        public double Balance { get; set; }
            
        public BankAccount()
        {

        }

        public void Deposit(double amount)
        {
            Balance = Balance + amount;
        }

        public bool Withdraw(int amount)
        {
        if(amount <= Balance)
            {
                Balance = Balance - amount;
                return true;
            }
            else
            {
                return false;
            }
        }

        public double CheckBalance()
        {
            return Balance;
        }

        public void DisplayAccountDetails()
        {
            Console.WriteLine("Account Number:"+ AccountNumber);
            Console.WriteLine("Account Holder:"+ AccountHolder);
            Console.WriteLine("Balance:"+ Balance);
        }

        public void finalCode()
        {
            BankAccount b = new BankAccount();

            List<BankAccount> accounts = new List<BankAccount>();

            while (true)
            {
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Check Balance");
                Console.WriteLine("5. Display Details");
                Console.WriteLine("6. Exit");
                Console.Write("Enter choice: ");

                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter account holder name: ");
                        string name = Console.ReadLine();

                        BankAccount acc = new BankAccount();
                        acc.AccountHolder = name;
                        accounts.Add(acc);

                        Console.WriteLine("Account created successfully!");
                        Console.WriteLine("Your Account Number: " + acc.AccountNumber);
                        break;

                    case 2:

                        Console.WriteLine("Your Account Number: " + b.AccountNumber);

                        Console.WriteLine("Enter deposit amount");
                        double d = double.Parse(Console.ReadLine());
                        b.Deposit(d);
                        break;

                    case 3:


                        Console.WriteLine("Your Account Number: " + b.AccountNumber);

                        Console.WriteLine("Enter withdraw amount");
                        int w = int.Parse(Console.ReadLine());
                        b.Withdraw(w);
                        break;
                    case 4:


                        Console.WriteLine("Your Account Number: " + b.AccountNumber);

                        Console.WriteLine("Balance :" + b.CheckBalance());
                        break;

                    case 5:
                        Console.Write("Enter Account Number: ");
                        string input = Console.ReadLine();

                        foreach (var acc1 in accounts)
                        {
                            if (acc1.AccountNumber.ToString() == input)
                            {
                                acc1.DisplayAccountDetails();
                                return;
                            }
                        }

                        Console.WriteLine("Account not found!");
                        break;

                    case 6:
                        Console.WriteLine("Exit");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }

    }
}




