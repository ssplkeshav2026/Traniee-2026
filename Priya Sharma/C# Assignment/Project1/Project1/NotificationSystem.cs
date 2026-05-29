using Project1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public interface INotification
    {
        void SendNotification();

    }

    class  EmailNotification : INotification
    {
        public void SendNotification()
        {
            Console.WriteLine("New MAIL Notification");
        }
    }

    class SMSNotification : INotification
    {
        public void SendNotification()
        {
            Console.WriteLine("New SMS Notification");
        }
    }

    class  PushNotification : INotification
    {
        public void SendNotification()
        {
            Console.WriteLine("New PUSH Notification");
        }
    }

    public class NotificationSystem
    {
        public void Notification()
        {
            int choice;

            do
            {
                Console.WriteLine("\nNotification System");
                Console.WriteLine("1. Email Notification");
                Console.WriteLine("2. SMS Notification");
                Console.WriteLine("3. Push Notification");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Invalid input!");
                    choice = 0;
                }

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
                        Console.WriteLine("Program Exit...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }

                if (notification != null)
                {
                    notification.SendNotification();
                }

            } while (choice != 4);
        }
    }
}


