using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{


    public interface Notification
    {
        void SendNotification(string message);

    }
    class EmailNotification : Notification
    {
        public void SendNotification(string message)
        {
            Console.WriteLine($"this is a Email notification{message}");
        }
    }

    class SmsNotification : Notification
    {


        public void SendNotification(string message)
        {
            Console.WriteLine($"this is a sms notification{message}");
        }
    }

    class PushNotification : Notification
    {
        public void SendNotification(string message)
        {
            Console.WriteLine($"this is a Push notification{message}");
        }
    }


    internal class Q33
    {
        public Q33()
        {
            bool start = true;
            while (start)
            {
                Console.WriteLine("Select the Notification type");
                Console.WriteLine("1. Email");
                Console.WriteLine("2. sms");
                Console.WriteLine("3. push");
              
                Console.WriteLine("5. Exit");

                int choice = Convert.ToInt32(Console.ReadLine());


                switch (choice)
                {
                    case 1:
                        EmailNotification cc = new EmailNotification();
                        Console.WriteLine("enter the message :");
                        string message = Console.ReadLine();
                        cc.SendNotification(message);

                        break;
                    case 2:
                        SmsNotification cc1 = new SmsNotification();
                        Console.WriteLine("enter the message :");
                        string message1 = Console.ReadLine();
                        cc1.SendNotification(message1);
                        break;
                    case 3:
                        PushNotification cc2 = new PushNotification();
                        Console.WriteLine("enter the message :");
                        string message2 = Console.ReadLine();
                        cc2.SendNotification(message2);
                        break;
                   
                    case 4:
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
