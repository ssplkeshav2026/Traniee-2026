using System;
using System.Collections.Generic;
using System.Text;

namespace assignment_c__1
{
    internal class question30
    {
        class Shape
        {
            public virtual double CalculateArea()
            {
                return 0;
            }
        }


        class Circle : Shape
        {
            double radius;

            public Circle(double r)
            {
                radius = r;
            }

            public override double CalculateArea()
            {
                return Math.PI * radius * radius;
            }
        }

   
        class Rectangle : Shape
        {
            double length, width;

            public Rectangle(double l, double w)
            {
                length = l;
                width = w;
            }

            public override double CalculateArea()
            {
                return length * width;
            }
        }

        
        class Triangle : Shape
        {
            double baseVal, height;

            public Triangle(double b, double h)
            {
                baseVal = b;
                height = h;
            }

            public override double CalculateArea()
            {
                return 0.5 * baseVal * height;
            }
        }

        public question30()
        {
            int choice;

            do
            {
                Console.WriteLine("Which shape area do you want to calculate?");
                Console.WriteLine("1. Circle");
                Console.WriteLine("2. Rectangle");
                Console.WriteLine("3. Triangle");
                Console.WriteLine("4. Exit");

                Console.Write("Enter Choice");
                choice = Convert.ToInt32(Console.ReadLine());

                Shape shape = null;

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Radius ");
                        double r = Convert.ToDouble(Console.ReadLine());
                        shape = new Circle(r);
                        break;

                    case 2:
                        Console.Write("Enter Length ");
                        double l = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter Width ");
                        double w = Convert.ToDouble(Console.ReadLine());

                        shape = new Rectangle(l, w);
                        break;

                    case 3:
                        Console.Write("Enter Base ");
                        double b = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter Height ");
                        double h = Convert.ToDouble(Console.ReadLine());

                        shape = new Triangle(b, h);
                        break;

                    case 4:
                        Console.WriteLine("Exiting");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        continue;
                }

                if (shape != null)
                {
                    Console.WriteLine("Area = " + shape.CalculateArea());
                }

            } while (choice != 4);
        }
    }
}