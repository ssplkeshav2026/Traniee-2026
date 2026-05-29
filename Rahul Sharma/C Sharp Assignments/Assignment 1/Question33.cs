using System;

namespace Assignment1
{
    interface INotification
    {
        void SendNotification();
    }

    class EmailNotification : INotification
    {
        public void SendNotification()
        {
            Console.WriteLine("Email Notification Sent");
        }
    }

    class SMSNotification : INotification
    {
        public void SendNotification()
        {
            Console.WriteLine("SMS Notification Sent");
        }
    }

    class PushNotification : INotification
    {
        public void SendNotification()
        {
            Console.WriteLine("Push Notification Sent");
        }
    }

    class Question33
    {
        public Question33()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\n--- Notification System ---");
                Console.WriteLine("1. Email");
                Console.WriteLine("2. SMS");
                Console.WriteLine("3. Push Notification");
                Console.WriteLine("4. Exit");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                INotification notification = null;

                switch (choice)
                {
                    case 1:
                        notification = new EmailNotification();
                        break;

                    case 2:
                        notification = new SMSNotification();
                        break;

                    case 3:
                        notification = new PushNotification();
                        break;

                    case 4:
                        isRunning = false;
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }

                if (notification != null)
                {
                    notification.SendNotification();
                }
            }
        }
    }
}