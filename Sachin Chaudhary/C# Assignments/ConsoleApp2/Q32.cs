using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{


    public interface Ipayment
    {
        void processpayment(Double amount);

    }
    class CreditCard : Ipayment
    {
        public void processpayment(Double amount)
        {
            Console.WriteLine($"proccessing CreditCard payment{amount}");
        }
    }

    class Debitcard : Ipayment
    {
        public void processpayment(Double amount)
        {
            Console.WriteLine($"proccessing DEBITCard payment{amount}");
        }
    }

    class Cash : Ipayment
    {
        public void processpayment(Double amount)
        {
            Console.WriteLine($"proccessing CashCard payment{amount}");
        }
    }

    class Upi : Ipayment
    {
        public void processpayment(Double amount)
        {
            Console.WriteLine($"proccessing upiCard payment{amount}");
        }
    }
    internal class Q32
    {
        public Q32()
        {
            bool start = true;
            while (start)
            {
                Console.WriteLine("Select the payment method");
                Console.WriteLine("1. CreditCard");
                Console.WriteLine("2. debitcard");
                Console.WriteLine("3. Cash");
                Console.WriteLine("4. Upi");
                Console.WriteLine("5. Exit");

                int choice = Convert.ToInt32(Console.ReadLine());


                switch (choice)
                {
                    case 1:
                        CreditCard cc = new CreditCard();
                        Console.WriteLine("enter the amount :");
                        int amount = Convert.ToInt32(Console.ReadLine());
                        cc.processpayment(amount);

                        break;
                    case 2:
                        Debitcard dc = new Debitcard();
                        Console.WriteLine("enter the amount :");
                        int amount1 = Convert.ToInt32(Console.ReadLine());
                        dc.processpayment(amount1);
                        break;
                    case 3:
                        Cash cash = new Cash();
                        Console.WriteLine("enter the amount :");
                        int amount2 = Convert.ToInt32(Console.ReadLine());
                        cash.processpayment(amount2);
                        break;
                    case 4:
                        Upi upi = new Upi();
                        Console.WriteLine("enter the amount :");
                        int amount3 = Convert.ToInt32(Console.ReadLine());
                        upi.processpayment(amount3);
                        break;
                    case 5:
                        start = false;
                        Console.WriteLine("bye");
                        break;

                }



            }



        }

    }
}

//solid principle'
//         asyn progrmming
