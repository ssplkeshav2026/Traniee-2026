//using System;

//namespace program
//{
//    public abstract class Shape
//    {
//        public string Name { get; set; }
//        public abstract double GetArea();
//    }

//    public class Circle : Shape
//    {
//        public double Radius { get; set; }

//        public override double GetArea()
//        {
//            return Math.PI * Radius * Radius;
//        }
//    }

//    public class Rectangle : Shape
//    {
//          public double Wi { get; set; }
//           public double Hi { get; set; }

//        public override double GetArea()
//        {
//            return Wi * Hi;
//        }
//    }

//    public class Triangle : Shape
//    {
//        public double B { get; set; }
//        public double Height { get; set; }

//        public override double GetArea()
//        {
//            return 0.5 * B * Height;
//        }
//    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            bool start = true;

//            while (start)
//            {
//                Console.WriteLine("Select the shape:");
//                Console.WriteLine("1. Circle");
//                   Console.WriteLine("2. Rectangle");
//                  Console.WriteLine("3. Triangle");
//                 Console.WriteLine("4. Exit");

//                int choice = Convert.ToInt32(Console.ReadLine());

//                switch (choice)
//                {
//                       case 1:
//                        Circle c = new Circle();
//                          Console.Write("Enter radius: ");
//                           c.Radius = Convert.ToDouble(Console.ReadLine());
//                          Console.WriteLine($"Area: {c.GetArea()}");
//                        break;

//                       case 2:
//                        Rectangle r = new Rectangle();
//                           Console.Write("Enter width: ");
//                        r.Wi = Convert.ToDouble(Console.ReadLine());
//                          Console.Write("Enter height: ");
//                        r.Hi = Convert.ToDouble(Console.ReadLine());
//                           Console.WriteLine($"Area: {r.GetArea()}");
//                        break;

//                     case 3:
//                        Triangle t = new Triangle();
//                        Console.Write("Enter base: ");
//                            t.B = Convert.ToDouble(Console.ReadLine());
//                        Console.Write("Enter height: ");
//                          t.Height = Convert.ToDouble(Console.ReadLine());
//                           Console.WriteLine($"Area: {t.GetArea()}");
//                        break;

//                      case 4:
//                        start = false;
//                          Console.WriteLine("Bye");
//                        break;
//                }
//            }
//        }
//    }
//}