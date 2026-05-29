using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Project1
{
    abstract class Shape
    {
        public abstract double area();
    }

    class Circle : Shape
    {
        public double radius;

        public override double area()
        {
            return Math.PI * radius * radius;
        }
    }

    class Rectanagle : Shape
    {
        public double Width;
        public double Length;
        public override double area()
        {
            return Length * Width;
        }
    }

    class Triangle : Shape
    {
        public double Base;
        public double Height;
        public override double area()
        {
            return 0.5 * Base * Height; 
        }
    }
    public class ShapeCalculator
    {
        public void calculate()
        {
            
            int choice;
            do
            {
                Console.WriteLine("\nWhich shape area do you want to calculate ? ");
                Console.WriteLine("1. Circle");
                Console.WriteLine("2. Rectangle");
                Console.WriteLine("3. Triangle");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Enter Choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                  {
                    case 1:
                        Circle circle = new Circle();

                        Console.Write("Enter radius: ");
                        circle.radius = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Area of Circle: " + circle.area());
                        break;

                    case 2:
                        Rectanagle rectangle = new Rectanagle();

                        Console.Write("Enter length: ");
                        rectangle.Length = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Enter width: ");
                        rectangle.Width = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Area of Rectangle: " + rectangle.area());
                        break;

                    case 3:
                        Triangle triangle = new Triangle();

                        Console.Write("Enter base: ");
                        triangle.Base = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Enter height: ");
                        triangle.Height = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Area of Triangle: " + triangle.area());
                        break;

                    case 4:
                        Console.WriteLine("Program exit...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice....");
                        break;
                  }
            }while(choice != 4);
        }
    }
}



