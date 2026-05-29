//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SolidAsync
//{
//    // After SRP
//    public class UserData
//    {
//        public void User_Data()
//        {
//            Console.WriteLine("This method handle user data");

//        }
//    }
//    public class Email
//    {
//        public void User_Email()
//        {
//            Console.WriteLine("This method send email");
//        }
//    }

//    public class Database
//    {
//        public void User_Database()
//        {
//            Console.WriteLine("This method have to store data");

//        }
//    }
//    public class User
//    {
//        // Before SRP
//        //public void UserData()
//        //{
//        //    Console.WriteLine("This method handle user data");

//        //}
//        //public void Email()
//        //{
//        //    Console.WriteLine("This method send email");

//        //}
//        //public void Database()
//        //{
//        //    Console.WriteLine("This method have to store data");

//        //}


//        static void Main(string[] args)
//        {
//            //User u=new User();
//            //u.UserData();
//            //u.Email();
//            //u.Database();

//            UserData u=new UserData();
//            u.User_Data();

//            Email e=new Email();
//            e.User_Email();

//            Database d=new Database();
//            d.User_Database();
//        }
//    }
//}