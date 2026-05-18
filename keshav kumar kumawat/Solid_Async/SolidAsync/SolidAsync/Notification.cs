//using System;

//namespace SolidAsync
//{
//    // Before DIP
//    //public class EmailNotification
//    //{
//    //    public void Send(string message)
//    //    {
//    //        Console.WriteLine(message);
//    //    }
//    //}

//    //public class NotificationService
//    //{
//    //    private EmailNotification e;

//    //    public NotificationService()
//    //    {
//    //        e = new EmailNotification();
//    //    }

//    //    public void Notify(string message)
//    //    {
//    //        e.Send(message);
//    //    }
//    //}

//    // After DIP

//    public interface INotification
//    {
//        void Send(string message);
//    }

//    public class EmailNotification : INotification
//    {
//        public void Send(string message)
//        {
//            Console.WriteLine("Email: " + message);
//        }
//    }

//    public class SmsNotification : INotification
//    {
//        public void Send(string message)
//        {
//            Console.WriteLine("SMS: " + message);
//        }
//    }

//    public class SlackNotification : INotification
//    {
//        public void Send(string message)
//        {
//            Console.WriteLine("Slack: " + message);
//        }
//    }

//    public class NotificationService
//    {
//        public void Notify(INotification notification,string message)
//        {
//            notification.Send(message);
//        }
//    }
//    public class Notification
//    {
//        public static void Main(string[] args)
//        {
//            //NotificationService s = new NotificationService();
//            //s.Notify("Hello User!");

//            INotification notification = new EmailNotification();
//            NotificationService s = new NotificationService();
//            s.Notify(notification, "Hello User!");
//        }
//    }
//}