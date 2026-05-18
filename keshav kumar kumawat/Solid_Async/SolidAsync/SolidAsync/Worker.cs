//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SolidAsync
//{
//    // Before ISP
//    //public interface IWorker
//    //{
//    //    void eat();
//    //    void sleep();
//    //    void work();
//    //}

//    //public class Manager : IWorker
//    //{
//    //    public void eat()
//    //    {
//    //        Console.WriteLine("Eating");
//    //    }
//    //    public void sleep()
//    //    {
//    //        Console.WriteLine("Sleeping");
//    //    }
//    //    public void work()
//    //    {
//    //        Console.WriteLine("Working");
//    //    }
//    //}

//    // After ISP

//    public interface IWorker
//    {
//        void work();
//    }
//    public interface ISleeping
//    {
//        void sleep();
//    }
//    public interface IEating
//    {
//        void eat();
//    }

//    public class Manager : IWorker, ISleeping, IEating
//    {
//        public void work()
//        {
//            Console.WriteLine("Working");
//        }
//        public void eat()
//        {
//            Console.WriteLine("Eating");
//        }
//        public void sleep()
//        {
//            Console.WriteLine("Sleeping");
//        }

//        public class Worker
//        {
//            public static void Main(string[] args)
//            {
//                Manager m = new Manager();
//                m.eat();
//                m.sleep();
//                m.work();
//            }
//        }
//    }
//}