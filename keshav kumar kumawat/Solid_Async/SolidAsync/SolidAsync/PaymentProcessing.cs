//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SolidAsync
//{
// After OCP
//    public interface IPaymentMethod
//    {
//        void Process(double amount);
//    }
//    public class CreditCard : IPaymentMethod
//    {
//       public void Process(double amount)
//        {
//            Console.WriteLine($"Successfully Processed {amount} via CreditCard");
//        }
//    }

//    public class PayPal : IPaymentMethod
//    {
//        public void Process(double amount)
//        {
//            Console.WriteLine($"Successfully Processed {amount} via PayPal");

//        }
//    }

//    public class Cryptocurrency : IPaymentMethod
//    {
//        public void Process(double amount)
//        {
//            Console.WriteLine($"Successfully Processed {amount} via CryptoCurrency");
//        }
//    }
//    public class PaymentProcessing
//    {
//        // Before OCP
//        //public void CreditCard()
//        //{
//        //    Console.WriteLine("Credit Card");
//        //}
//        //public void PayPal()
//        //{
//        //    Console.WriteLine("PayPal");
//        //}
//        //public void Cryptocurrency()
//        //{
//        //    Console.WriteLine("Crypto Currency");
//        //}
//        static void Main(string[] args)
//        {
//            //PaymentProcessing p=new PaymentProcessing();
//            //p.CreditCard();
//            //p.PayPal();
//            //p.Cryptocurrency();

//            CreditCard c=new CreditCard();
//            PayPal p=new PayPal();
//            Cryptocurrency cc=new Cryptocurrency();

//            c.Process(1000.1);
//            p.Process(1000.2);
//            cc.Process(1000.3);
//        }
//    }
//}