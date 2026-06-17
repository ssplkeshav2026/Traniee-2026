using System;

namespace assignment_c__1
{
    public interface Inotification
    {
        void sendnotification(string message);
    }

    public class emailnotification : Inotification
    {
        public void sendnotification(string message)
        {
            Console.WriteLine($"sending {message} via email");
        }
    }

    public class smsnotification : Inotification
    {
        public void sendnotification(string message)
        {
            Console.WriteLine($"sending {message} via sms");
        }
    }

    public class pushnotification : Inotification
    {
        public void sendnotification(string message)
        {
            Console.WriteLine($"sending {message} push notification.");
        }
    }

    public class call : Inotification
    {
        public void sendnotification(string message)
        {
            Console.WriteLine($"sending {message} via calling");
        }
    }


    internal class question33
    {
        public question33()
        {
            //Console.WriteLine("Sending the notification");

            //Console.Write("Enter the message ");
            //string message=  Console.ReadLine();
            //{
            //    Console.WriteLine("Invalid message!");
            //    return;
            //}

            Console.Write("Enter the sending message: ");
            string message = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(message))
            {
                Console.WriteLine("Invalid message!");
                return;
            }

            Console.WriteLine("Select notification Method:");
            Console.WriteLine("1. Email Notitfation");
            Console.WriteLine("2. Sms Notification");
            Console.WriteLine("3. Push Notification");
            Console.WriteLine("4. Call");

            string choice = Console.ReadLine();

            Inotification sendingmessage = null;

            switch (choice)
            {
                case "1":
                    sendingmessage = new emailnotification();
                    break;
                case "2":
                    sendingmessage = new smsnotification();
                    break;
                case "3":
                    sendingmessage = new pushnotification();
                    break;
                case "4":
                    sendingmessage = new call();
                    break;
                default:
                    Console.WriteLine("Invalid selection.");
                    return;
            }

            sendingmessage.sendnotification(message);
        }
    }
}