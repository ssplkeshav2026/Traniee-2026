
//25.Console - Based Bank Account System: Create a BankAccount class and a console menu:
//1.Create Account
//2. Deposit
//3. Withdraw
//4. Check Balance
//5. Display Account Details
//6. Exit
//Store multiple accounts in an array/list.



using System;
using System.Collections.Generic;

namespace Assignment1
{
    internal class BankAccountDetails
    {
        public string Name;
        public Guid AccountNumber;
        public double Balance;
    }

    internal class BankAccount
    {
        public BankAccount()
        {
            List<BankAccountDetails> accounts = new List<BankAccountDetails>();
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\n--- Bank ---");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4.CheckBalance");
                Console.WriteLine("5. Display All Account Details");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        BankAccountDetails account = new BankAccountDetails();

                        Console.WriteLine("Enter Your Name:");
                        account.Name = Console.ReadLine();

                        account.AccountNumber = Guid.NewGuid();
                        account.Balance = 0;

                        accounts.Add(account);

                        Console.WriteLine("\nAccount Created Successfully!");
                        Console.WriteLine("Name: " + account.Name);
                        Console.WriteLine("Account Number: " + account.AccountNumber);
                        Console.WriteLine("Balance: " + account.Balance);
                        break;

                    case 2:
                        Console.Write("Enter Account Number: ");
                        string accNo = Console.ReadLine();

                        BankAccountDetails depAccount = null;

                        foreach (BankAccountDetails acc in accounts)
                        {
                            if (acc.AccountNumber.ToString() == accNo)
                            {
                                depAccount = acc;
                                break;
                            }
                        }

                        if (depAccount != null)
                        {
                            Console.Write("Enter amount to deposit: ");
                            double deposit = double.Parse(Console.ReadLine());

                            depAccount.Balance += deposit;
                            Console.WriteLine("Amount Deposited Successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Account Not Found!");
                        }
                        break;

                    case 3:
                        Console.Write("Enter Account Number: ");
                        string withdrawAccNo = Console.ReadLine();

                        BankAccountDetails WithdrawAccount = null;

                        foreach (BankAccountDetails acc in accounts)
                        {
                            if (acc.AccountNumber.ToString() == withdrawAccNo)
                            {
                                WithdrawAccount = acc;
                                break;
                            }
                        }

                        if (WithdrawAccount != null)
                        {
                            Console.Write("Enter amount to withdraw: ");
                            double withdraw = double.Parse(Console.ReadLine());

                            if (withdraw <= WithdrawAccount.Balance)
                            {
                                WithdrawAccount.Balance -= withdraw;
                                Console.WriteLine("Withdrawal Successful!");
                            }
                            else
                            {
                                Console.WriteLine("Insufficient Balance!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Account Not Found!");
                        }
                        break;

                    case 4:
                        Console.Write("Enter Account Number: ");
                        string CheckAccNo = Console.ReadLine();

                        BankAccountDetails CheckAccount = null;

                        foreach (BankAccountDetails acc in accounts)
                        {
                            if (acc.AccountNumber.ToString() == CheckAccNo)
                            {
                                CheckAccount = acc;
                                break;
                            }
                        }

                        if (CheckAccount != null)
                        {
                        Console.WriteLine("Balance is "+CheckAccount.Balance);
                        }
                        else
                        {
                            Console.WriteLine("Account Not Found!");
                        }

                        break;

                    case 5:
                        Console.WriteLine("\n----- All Account Details -----");

                        foreach (BankAccountDetails acc in accounts)
                        {
                            Console.WriteLine("--------------------------");
                            Console.WriteLine("Name: " + acc.Name);
                            Console.WriteLine("Account Number: " + acc.AccountNumber);
                            Console.WriteLine("Balance: " + acc.Balance);
                        }
                        break;

                    case 6:
                        isRunning = false;
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice!");
                        break;
                }
            }
        }
    }
}




