using System;

namespace Assignment1
{
    
    interface IPayment
    {
        void ProcessPayment();
    }

    class CreditCard : IPayment
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Payment done using Credit Card");
        }
    }

    class DebitCard : IPayment
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Payment done using Debit Card");
        }
    }

    class Cash : IPayment
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Payment done using Cash");
        }
    }

    class UPI : IPayment
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Payment done using UPI");
        }
    }


    class Question32
    {
        bool isRunning = true;
        public Question32() {
            while (isRunning)
            {
                Console.WriteLine("--Payment System --");
                Console.WriteLine("1. Credit Card");
                Console.WriteLine("2. Debit Card");
                Console.WriteLine("3. Cash");
                Console.WriteLine("4. UPI");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());


                IPayment payment = null;


                switch (choice)
                {
                    case 1:
                        payment = new CreditCard();
                        break;

                    case 2:
                        payment = new DebitCard();
                        break;

                    case 3:
                        payment = new Cash();
                        break;

                    case 4:
                        payment = new UPI();
                        break;
                    case 5:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }

                if (payment != null)
                {
                    payment.ProcessPayment();
                }

            }
        } 
    }
}