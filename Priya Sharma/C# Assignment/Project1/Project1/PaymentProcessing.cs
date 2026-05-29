using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public interface IPayment
    {
        void processpayment(Double amount);

    }
    class CreditCard : IPayment
    {
        public void processpayment(Double amount)
        {
            Console.WriteLine("Processing CreditCard payment " + amount);
        }
    }

    class DebitCard : IPayment
    {
        public void processpayment(Double amount)
        {
            Console.WriteLine("Processing DebitCard payment " + amount);
        }
    }

    class Cash : IPayment
    {
        public void processpayment(Double amount)
        {
            Console.WriteLine("Processing Cash payment " + amount);
        }
    }

    class Upi : IPayment
    {
        public void processpayment(Double amount)
        {
            Console.WriteLine("Processing UPI payment " + amount);
        }
    }
    public class PaymentProcessing
    {
        public void Pay()
        {
            bool start = true;
            while (start)
            {
                Console.WriteLine("Select the payment method");
                Console.WriteLine("1. CreditCard");
                Console.WriteLine("2. Debitcard");
                Console.WriteLine("3. Cash");
                Console.WriteLine("4. Upi");
                Console.WriteLine("5. Exit");
                Console.Write("Enter Choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());


                switch (choice)
                {
                    case 1:
                        CreditCard creditcard = new CreditCard();

                        Console.WriteLine("enter the amount :");
                        int amount = Convert.ToInt32(Console.ReadLine());

                        creditcard.processpayment(amount);

                        break;
                    case 2:
                        DebitCard debitcard = new DebitCard();

                        Console.WriteLine("enter the amount :");
                        int amount1 = Convert.ToInt32(Console.ReadLine());

                        debitcard.processpayment(amount1);
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
                        Console.WriteLine("Program Exit");
                        break;
                    default:
                        Console.WriteLine("Invalid option...");
                        continue;
                }
            }
        }
    }
}

