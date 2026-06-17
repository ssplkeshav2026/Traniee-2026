using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    interface IPayment
    {
        void ProcessPayment();
    }
    public class CreditCard : IPayment
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Enter amount :");
            int amount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Processing Credit Card Payment");
            Console.WriteLine($"Amount Paid: {amount}");
        }
    }
    public class DebitCard : IPayment
    {

        public void ProcessPayment()
        {
            Console.WriteLine("Enter amount :");
            int amount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Processing debit Card Payment");
            Console.WriteLine($"Amount Paid: {amount}");
        }


    }

    public class Cash : IPayment
    {

        public void ProcessPayment()
        {
            Console.WriteLine("Enter amount :");
            int amount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Processing cash Payment");
            Console.WriteLine($"Amount Paid: {amount}");
        }


    }

    public class UPI : IPayment
    {

        public void ProcessPayment()
        {
            Console.WriteLine("Enter amount :");
            int amount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Processing UPI Payment");
            Console.WriteLine($"Amount Paid: {amount}");
        }


    }



    public class Question32
    {
        bool keepRun = true;

        public Question32()
        {

            while (keepRun)
            {
                Console.WriteLine(" Select payment method ");
                Console.WriteLine("1 = Via Credit card");
                Console.WriteLine("2 = Via Debit card");
                Console.WriteLine("3 = Cash");
                Console.WriteLine("4 = UPI");
                Console.WriteLine("5 = Exit");
                Console.Write("Select an option: ");
                int option = Convert.ToInt32(Console.ReadLine());
                

                IPayment payment = null;
                switch (option)
                {
                    case 1:
                        payment = new CreditCard();
                        payment.ProcessPayment();
                        break;
                    case 2:
                        payment = new DebitCard();
                        payment.ProcessPayment();

                        break;
                    case 3:
                        payment = new Cash();
                        payment.ProcessPayment();

                        break;
                    case 4:
                        payment = new UPI();
                        payment.ProcessPayment();

                        break;
                    case 5:
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
