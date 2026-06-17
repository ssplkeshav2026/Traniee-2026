using System;

namespace assignment_c__1
{
    public interface IPayment
    {
        void ProcessPayment(double amount);
    }

    public class CreditCard : IPayment
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing ₹{amount} via Credit Card");
        }
    }

    public class DebitCard : IPayment
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing ₹{amount} via Debit Card");
        }
    }

    public class Cash : IPayment
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing ₹{amount}");
        }
    }

    public class UPI : IPayment
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing ₹{amount} ");
        }
    }
    internal class question32
    {
        public question32()
        {
            Console.WriteLine(" Payment Processing Console ");

            Console.Write("Enter transaction amount ");
            if (!double.TryParse(Console.ReadLine(), out double amount))
            {
                Console.WriteLine("Invalid amount!");
                return;
            }

            Console.WriteLine("\nSelect Payment Method:");
            Console.WriteLine("1. Credit Card");
            Console.WriteLine("2. Debit Card");
            Console.WriteLine("3. Cash");
            Console.WriteLine("4. UPI");

            string choice = Console.ReadLine();

            IPayment paymentProcessor = null;

            switch (choice)
            {
                case "1":
                    paymentProcessor = new CreditCard();
                    break;
                case "2":
                    paymentProcessor = new DebitCard();
                    break;
                case "3":
                    paymentProcessor = new Cash();
                    break;
                case "4":
                    paymentProcessor = new UPI();
                    break;
                default:
                    Console.WriteLine("Invalid selection.");
                    return;
            }

            paymentProcessor.ProcessPayment(amount);
        }
    }
}