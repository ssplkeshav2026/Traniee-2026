using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    public class BankAccount
    {
        public BankAccount()
        {
            List<string> names = new List<string>();
            List<int> AccountNumber = new List<int>();
            List<int> TotalBalance = new List<int>();

            bool start = true;
            while (start)
            {
                Console.WriteLine("----BankAccount----");
                Console.WriteLine("1.Create Account");
                Console.WriteLine("2.Deposit");
                Console.WriteLine("3.Withdraw");
                Console.WriteLine("4.Check balance");
                Console.WriteLine("5.Display account details");
                Console.WriteLine("6.Exit");

                int Choice = Convert.ToInt32(Console.ReadLine());

                switch (Choice)
                {
                    case 1:
                        Console.WriteLine("Enter the Name of account holder:");
                        string NAME = Console.ReadLine();

                        Console.WriteLine("Enter the account number:");
                        int AccNo = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter the deposit amount:");
                        int Balance = Convert.ToInt32(Console.ReadLine());

                        names.Add(NAME);
                        AccountNumber.Add(AccNo);
                        TotalBalance.Add(Balance);

                        Console.WriteLine("Your account is CREATED SUCCESSFULLY");
                        break;

                    case 2:
                        Console.WriteLine("Enter the Account number to deposit money:");
                        int Ac = Convert.ToInt32(Console.ReadLine());

                        int index = AccountNumber.IndexOf(Ac);
                        if (index != -1)
                        {
                            Console.WriteLine($"Found {AccountNumber[index]} - Name: {names[index]}");

                            Console.WriteLine("Enter deposit amount:");
                            int bal = Convert.ToInt32(Console.ReadLine());

                            TotalBalance[index] += bal;
                            Console.WriteLine($"New Balance: {TotalBalance[index]}");
                        }
                        else
                        {
                            Console.WriteLine("User not found");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Enter the Account number to withdraw money:");
                        int Acc = Convert.ToInt32(Console.ReadLine());

                        int index1 = AccountNumber.IndexOf(Acc);
                        if (index1 != -1)
                        {
                            Console.WriteLine($"Found {AccountNumber[index1]} - Name: {names[index1]}");

                            Console.WriteLine("Enter withdrawal amount:");
                            int bal = Convert.ToInt32(Console.ReadLine());

                            if (TotalBalance[index1] >= bal)
                            {
                                TotalBalance[index1] -= bal;
                                Console.WriteLine($"New Balance: {TotalBalance[index1]}");
                            }
                            else
                            {
                                Console.WriteLine("Insufficient balance");
                            }
                        }
                        else
                        {
                            Console.WriteLine("User not found");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Enter the Account number to check balance:");
                        int Acc1 = Convert.ToInt32(Console.ReadLine());

                        int index2 = AccountNumber.IndexOf(Acc1);
                        if (index2 != -1)
                        {
                            Console.WriteLine($"Found {AccountNumber[index2]} - Name: {names[index2]}");
                            Console.WriteLine($"Balance: {TotalBalance[index2]}");
                        }
                        else
                        {
                            Console.WriteLine("User not found");
                        }
                        break;

                    case 5:
                        Console.WriteLine("Enter the Account number to view details:");
                        int Acc2 = Convert.ToInt32(Console.ReadLine());

                        int index3 = AccountNumber.IndexOf(Acc2);
                        if (index3 != -1)
                        {
                            Console.WriteLine($"Account No: {AccountNumber[index3]} | Name: {names[index3]} | Balance: {TotalBalance[index3]}");
                        }
                        else
                        {
                            Console.WriteLine("User not found");
                        }
                        break;

                    case 6:
                        start = false;
                        Console.WriteLine("Bye");
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}