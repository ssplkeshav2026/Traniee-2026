
using System;
using System.Collections.Generic;

namespace assignment_c__1
{
    class BankAccount
    {
        public int accNo;
        public string name;
        public double balance;

        public void CreateAccount(int no, string n, double bal)
        {
            accNo = no;
            name = n;
            balance = bal;
        }

        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine("Amount Deposited!");
            }
            else
            {
                Console.WriteLine("Invalid Amount!");
            }
        }

        public void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid Amount!");
            }
            else if (amount <= balance)
            {
                balance -= amount;
                Console.WriteLine("Amount Withdrawn!");
            }
            else
            {
                Console.WriteLine("Insufficient Balance!");
            }
        }

        public void CheckBalance()
        {
            Console.WriteLine("Current Balance: " + balance);
        }

        public void Display()
        {
            Console.WriteLine("Account No: " + accNo);
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Balance: " + balance);
        }
    }

    class Programm
    {
        public void bank()
        {
            List<BankAccount> accounts = new List<BankAccount>();
            int choice;

            do
            {
                Console.WriteLine("\n1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Check Balance");
                Console.WriteLine("5. Display Account Details");
                Console.WriteLine("6. Exit");

                Console.Write("Enter choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                BankAccount acc = null;

                if (choice >= 2 && choice <= 5)
                {
                    Console.Write("Enter Account No: ");
                    int no = Convert.ToInt32(Console.ReadLine());

                    acc = accounts.Find(a => a.accNo == no);

                    if (acc == null)
                    {
                        Console.WriteLine("Account not found!");
                        continue;
                    }
                }

                switch (choice)
                {
                    case 1:
                        BankAccount newAcc = new BankAccount();

                        Console.Write("Enter Account No: ");
                        int accNo = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter Initial Balance: ");
                        double bal = Convert.ToDouble(Console.ReadLine());

                        newAcc.CreateAccount(accNo, name, bal);
                        accounts.Add(newAcc);

                        Console.WriteLine("Account Created Successfully!");
                        break;

                    case 2:
                        Console.Write("Enter Amount: ");
                        double damt = Convert.ToDouble(Console.ReadLine());
                        acc.Deposit(damt);
                        break;

                    case 3:
                        Console.Write("Enter Amount: ");
                        double wamt = Convert.ToDouble(Console.ReadLine());
                        acc.Withdraw(wamt);
                        break;

                    case 4:
                        acc.CheckBalance();
                        break;

                    case 5:
                        acc.Display();
                        break;

                    case 6:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice!");
                        break;
                }

            } while (choice != 6);
        }
    }
}