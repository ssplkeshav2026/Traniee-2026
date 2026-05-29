using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public abstract class Shape
    {
        public abstract double CalculateArea();
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }

    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override double CalculateArea()
        {
            return Width * Height;
        }
    }

    public class Triangle : Shape
    {
        public double Base { get; set; }
        public double Height { get; set; }

        public Triangle(double b, double height)
        {
            Base = b;
            Height = height;
        }

        public override double CalculateArea()
        {
            return 0.5 * Base * Height;
        }
    }

    public class Shape1
    {
        public Shape1()
        {
            while (true)
            {
                Console.WriteLine("\nShape Calculator Console App:");
                Console.WriteLine("1. Circle");
                Console.WriteLine("2. Rectangle");
                Console.WriteLine("3. Triangle");
                Console.WriteLine("4. Exit");

                Console.Write("Which shape area do you want to calculate? ");
                string choice = Console.ReadLine();

                Shape shape = null;

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter radius: ");
                        double r = double.Parse(Console.ReadLine());
                        shape = new Circle(r);
                        break;

                    case "2":
                        Console.Write("Enter width: ");
                        double w = double.Parse(Console.ReadLine());
                        Console.Write("Enter height: ");
                        double h = double.Parse(Console.ReadLine());
                        shape = new Rectangle(w, h);
                        break;

                    case "3":
                        Console.Write("Enter base: ");
                        double b = double.Parse(Console.ReadLine());
                        Console.Write("Enter height: ");
                        double th = double.Parse(Console.ReadLine());
                        shape = new Triangle(b, th);
                        break;

                    case "4":
                        Console.WriteLine("Exit");
                        return;

                    default:
                        Console.WriteLine("Invalid choice");
                        continue;
                }

                if (shape != null)
                {
                    Console.WriteLine("Area = " + shape.CalculateArea());
                }
            }
        }
    }

}