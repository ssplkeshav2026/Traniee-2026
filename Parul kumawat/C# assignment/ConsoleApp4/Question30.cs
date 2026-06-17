using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public abstract class Shape
    {
        public abstract double GetShapeArea();
        public abstract string GetShapeName();
    }
     public class Circle : Shape
    {
        public double radius { get; set; }
        public Circle(double r)
        {
            radius = r;
        }
        public override string GetShapeName()
        {
            return "Circle";  
          }
        public override double GetShapeArea() {
           return Math.PI* radius *radius;

    }
}

    public class Rectangle : Shape
    {
        public double length { get; set; }
        public double width { get; set; }
        public Rectangle(double l, double w)
        {
            length = l;
            width = w;
        }
        public override string GetShapeName()
        {
            return "Rectangle";
        }
        public override double GetShapeArea()
        {
            return length * width;

        }
    }
    public class Triangle : Shape{

        public double b { get; set; }
    public double h { get; set; }
    public Triangle(double b, double height)
    {
        this.b = b;
        this.h = height;
    }
        public override string GetShapeName()
        {
            return "Triangle";
        }
        public override double GetShapeArea()
        {
            return (1.0/2) * b * h;

        }
    }
        public class Question30
        {
            bool keepRun = true;

            public Question30()
            {
                while (keepRun)
                {
                    Console.WriteLine(" Menu ");
                    Console.WriteLine("1 = calculate Circle area");
                    Console.WriteLine("2 = calculate Rectangle area");
                    Console.WriteLine("3 = calculate Triangle area");
                    Console.WriteLine("4 = Exit");
                    Console.Write("Select an option: ");
                    int option = Convert.ToInt32(Console.ReadLine());


                    switch (option)
                    {
                        case 1:

                        Console.WriteLine("Enter radius :");
                        double radius = Convert.ToDouble(Console.ReadLine());
                        Circle c = new Circle(radius);
                        Console.WriteLine($"the shape name is : {c.GetShapeName()} , and the area is : {c.GetShapeArea()}");
                        
                            break;

                        case 2:
                        Console.WriteLine("Enter length :");
                        double length = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter width :");
                        double width = Convert.ToDouble(Console.ReadLine());
                        Rectangle r = new Rectangle(length,width);
                        Console.WriteLine($"the shape name is : {r.GetShapeName()} , and the area is : {r.GetShapeArea()}");

                        break;

                        case 3:
                        Console.WriteLine("Enter base :");
                        double b = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter height :");
                        double height = Convert.ToDouble(Console.ReadLine());
                        Triangle t = new Triangle(b, height);
                        Console.WriteLine($"the shape name is : {t.GetShapeName()} , and the area is : {t.GetShapeArea()}");

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

