using Assignment1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//30.Shape Calculator Console App:
//Which shape area do you want to calculate?
//1. Circle
//2. Rectangle
//3. Triangle
//4. Exit
//Use inheritance with base Shape class and derived classes.

namespace Assignment1
{
    internal class Shape
    {

        public virtual void CalculateArea()
        {
            Console.WriteLine("Calculating area...");
        }
    }
}

class Circle : Shape
{
    public override void CalculateArea()
    {
        Console.Write("Enter radius: ");
        double r = double.Parse(Console.ReadLine());

        double area = 3.14 * r * r;
        Console.WriteLine("Area of Circle: " + area);
    }
}
class Rectangle : Shape
{
    public override void CalculateArea()
    {
        Console.Write("Enter length: ");
        double l = double.Parse(Console.ReadLine());

        Console.Write("Enter width: ");
        double w = double.Parse(Console.ReadLine());

        double area = l * w;
        Console.WriteLine("Area of Rectangle: " + area);
    }
}
class Triangle : Shape
{
    public override void CalculateArea()
    {
        Console.Write("Enter base: ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("Enter height: ");
        double h = double.Parse(Console.ReadLine());

        double area = 0.5 * b * h;
        Console.WriteLine("Area of Triangle: " + area);
    }
}

class Area
{   public Area()
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("\n1. Circle");
            Console.WriteLine("2. Rectangle");
            Console.WriteLine("3. Triangle");
            Console.WriteLine("4. Exit");

            Console.WriteLine("Enter Your Choice ");
            int choice = int.Parse(Console.ReadLine());

            Shape shape = null;

            switch (choice)
            {
                case 1:
                    shape = new Circle();

                    break;
                case 2:
                    shape  = new Rectangle();
                    break;
                case 3:
                    shape = new Triangle();
                    break;
                case 4:
                    isRunning = false;
                    break;
                default: Console.WriteLine("Invalid choice");
                    break;
            }
            if (shape != null)
            {
                shape.CalculateArea();  
            }
        }
    }
}




