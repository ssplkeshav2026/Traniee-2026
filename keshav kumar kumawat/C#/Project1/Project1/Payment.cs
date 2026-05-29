using Project1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    interface IPayment
    {
        void ProcessPayment();
    }

    class CreditCard : IPayment
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Paid using Credit Card.");
        }
    }
    class DebitCard : IPayment
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Paid using Debit Card.");
        }
    }
    class Cash : IPayment
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Paid using Cash");
        }
    }
    class UPI : IPayment
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Paid using UPI");
        }
    }
public class Payment{
    public void finalCode()
        {
            while (true)
            {
                Console.WriteLine("Select Payment: 1.Card, 2.Debit, 3.Cash, 4.UPI");
                string choice = Console.ReadLine();

                IPayment myPayment;

                if (choice == "1")
                {
                    myPayment = new CreditCard();
                }
                else if (choice == "2")
                {
                    myPayment = new DebitCard();
                }
                else if (choice == "3")
                {
                    myPayment = new Cash();
                }
                else if (choice == "4")
                {
                    myPayment = new UPI();
                }
                else
                {
                    Console.WriteLine("Invalid choice!");
                    return;
                }

                myPayment.ProcessPayment();
            }
        }
    }
}
