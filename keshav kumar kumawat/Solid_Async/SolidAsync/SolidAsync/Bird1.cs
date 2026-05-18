//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SolidAsync
//{
//    // Before LSP
//    //public class Bird
//    //{
//    //    public virtual void fly()
//    //    {
//    //        Console.WriteLine("Fly Method");
//    //    }
//    //}
//    //public class Sparrow : Bird
//    //{
//    //    public override void fly()
//    //    {
//    //        Console.WriteLine("Sparrow is flying");
//    //    }
//    //}
//    //public class Penguin : Bird
//    //{
//    //    public override void fly()
//    //    {
//    //        Console.WriteLine("Penguin is not flying");
//    //    }
//    //}

//    // After LSP
//   public interface IFlyable
//    {
//        void Fly();
//    }
//    public class Sparrow : IFlyable
//    {
//        public void Fly()
//        {
//            Console.WriteLine("Sparrow is Flying");
//        }
//    }

//    public class Penguin : IFlyable
//    {
//        public void Fly()
//        {
//            throw new NotImplementedException("Penguins cannot fly");
//        }
//    }
//    public class Bird1
//    {

//        public static void Main(string[] args)
//        {
//            //Bird b = new Bird();
//            //Sparrow s = new Sparrow();
//            //Penguin p = new Penguin();

//            //b.fly();
//            //s.fly();
//            //p.fly();

//            Sparrow s = new Sparrow();
//            Penguin p = new Penguin();

//            s.Fly();
//            p.Fly();
//        }
//    }
//}