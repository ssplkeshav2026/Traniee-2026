using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{

    //Question 25
    public class BankAccount
    {
        bool keepRun = true;

        public BankAccount()
        {
            List<string> accountNumber = new List<string>();
            List<string> accountHolder = new List<string>();
            List<Decimal> balance = new List<Decimal>();

            while (keepRun)
            {
                Console.WriteLine(" Menu ");
                Console.WriteLine("1 = Create your account");
                Console.WriteLine("2 = Deposit");
                Console.WriteLine("3 = Withdraw");
                Console.WriteLine("4 = Check your balance");
                Console.WriteLine("5 = Display Account details");
                Console.WriteLine("6 = Exit");
                Console.Write("Select an option: ");
                int option = Convert.ToInt32(Console.ReadLine());


                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter AccountNumber : ");
                        string AccountNumber = Console.ReadLine();

                        Console.WriteLine("Enter AccountHolder Name : ");
                        string AccountHolderName = Console.ReadLine();

                        Console.WriteLine("Enter Balance : ");
                        Decimal Balance = Convert.ToDecimal(Console.ReadLine());
                        accountNumber.Add(AccountNumber);
                        accountHolder.Add(AccountHolderName);
                        balance.Add(Balance);
                        Console.WriteLine("Account created successfully");
                        break;


                    case 2:

                        Console.Write("Enter Account Number to search: ");
                        string search = Console.ReadLine();

                        int index = accountNumber.IndexOf(search);

                        if (index != -1)
                        {

                            Console.WriteLine("Enter amount for deposit : ");
                            Decimal depositAmount = Convert.ToDecimal(Console.ReadLine());

                            balance[index] += depositAmount;
                            Console.WriteLine($"New Balance for {accountHolder[index]}: {balance[index]}");

                        }
                        else
                        {
                            Console.WriteLine("Account not found");

                        }
                        break;

                    case 3:
                        Console.Write("Enter Account Number to search: ");
                        string searchAcc = Console.ReadLine();

                        int i = accountNumber.IndexOf(searchAcc);

                        if (i != -1)
                        {

                            Console.WriteLine("Enter amount for withdraw : ");
                            Decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());

                            balance[i] -= withdrawAmount;
                            Console.WriteLine($"New Balance for {accountHolder[i]}: {balance[i]}");

                        }
                        else
                        {
                            Console.WriteLine("Account not found");

                        }
                        break;

                    case 4:
                        Console.Write("Enter Account Number to search: ");
                        string accSearch = Console.ReadLine();

                        int acc = accountNumber.IndexOf(accSearch);

                        if (acc != -1)
                        {
                            Console.WriteLine($"Total Balance for {accountHolder[acc]}: {balance[acc]}");

                        }
                        break;


                    case 5:
                        Console.Write("Enter Account Number to search: ");
                        string account = Console.ReadLine();

                        int accNum = accountNumber.IndexOf(account);

                        if (accNum != -1)
                        {
                            Console.WriteLine($"Account Number: {accountNumber[accNum]}\n Account Holder Name: {accountHolder[accNum]}\n Total Balance: {balance[accNum]}");
                        }
                        break;
                    case 6:
                        keepRun = false;
                        Console.WriteLine("exit");
                        break;

                    default:
                        Console.WriteLine("Invalid option");
                        break;

                }


            }
        }
    }
}
