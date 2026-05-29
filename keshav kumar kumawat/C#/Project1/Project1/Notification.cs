using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{

    interface INotification
    {
        void SendNotification();
    }
    class EmailNotification : INotification
    {
        public void SendNotification()
        {
            Console.WriteLine("Send Notification");
        }
    }
    class SMSNotification : INotification
    {
        public void SendNotification()
        {
            Console.WriteLine("SMS Notification");
        }
    }
    class PushNotification : INotification
    {
        public void SendNotification()
        {
            Console.WriteLine("Push Notification");
        }
    }

    public class Notification
    {
        public void finalCode()
        {
            while (true)
            {
                Console.WriteLine("Select Notification: 1.Send, 2.SMS, 3.Push");
                string choice = Console.ReadLine();

                INotification notify;

                if (choice == "1")
                {
                    notify = new EmailNotification();
                }
                else if (choice == "2")
                {
                    notify = new SMSNotification();
                }
                else if (choice == "3")
                {
                    notify = new PushNotification();
                }
                else
                {
                    Console.WriteLine("Invalid choice!");
                    return;
                }

                notify.SendNotification();

            }
        }
    }
}


       
 