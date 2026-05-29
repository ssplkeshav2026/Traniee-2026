using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    interface INotification
    {
        void SendNotification();
    }
    class EmailNotification : INotification
    {
        public void SendNotification()
        {
            Console.WriteLine("Enter notification message that you want to send  :");
            string emailMessage = Console.ReadLine();
            Console.WriteLine($"Message : {emailMessage} sent successfully via email");
        }
    }
    class SMSNotification : INotification
    {
        public void SendNotification()
        {
            Console.WriteLine("Enter notification message that you want to send  :");
            string smsMessage = Console.ReadLine();
            Console.WriteLine($"Message : {smsMessage} sent successfully via sms");
        }
    }
    class PushNotification : INotification
    {
        public void SendNotification()
        {
            Console.WriteLine("Enter notification message that you want to send  :");
            string pushMessage = Console.ReadLine();
            Console.WriteLine($"Message : {pushMessage} sent successfully via push notification");
        }
    }






    public class Question33
    {
        bool keepRun = true;

        public Question33()
        {
            while (keepRun)
            {
                Console.WriteLine(" Select send notification method ");
                Console.WriteLine("1 = Via Email");
                Console.WriteLine("2 = Via SMS");
                Console.WriteLine("3 = Via Push notification");
                Console.WriteLine("4 = Exit");
                Console.Write("Select an option: ");
                int option = Convert.ToInt32(Console.ReadLine());


                INotification notification = null;
                switch (option)
                {
                    case 1:
                        notification = new EmailNotification();
                        notification.SendNotification();
                        break;

                    case 2:
                        notification = new SMSNotification();
                        notification.SendNotification();
                        break;
                    case 3:
                        notification = new PushNotification();
                        notification.SendNotification();
                        break;
                    case 4:
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
