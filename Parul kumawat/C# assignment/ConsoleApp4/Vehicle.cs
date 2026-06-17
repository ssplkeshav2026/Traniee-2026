using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    abstract class Vehicle
    {
        public string brand;
        public string model;
        public double dailyRate;
        public abstract double CalculateRentalCost(int days);
        public abstract void printDetails(int days);

        public Vehicle(string b, string m, double rate)
        {
            this.brand = b;
            this.model = m;
            this.dailyRate = rate;


        }
    }
    class Car : Vehicle
    {

        public int NoOFDoors;



        public Car(string b, string m, double rate, int doors) : base(b, m, rate)
        {
            
            NoOFDoors = doors;
            

        }
         
        public override double CalculateRentalCost(int days)
        {
            int extra = (NoOFDoors == 4) ? 500 : 1000;

            return (days * dailyRate) + extra;
        }
        public override void printDetails(int days)
        {
            
            Console.WriteLine($"Car brand : {brand}, model : {model}, No. of doors : {NoOFDoors}, Daily rate : {CalculateRentalCost(days)}");
        }
    }
    class Bike : Vehicle
    {
        public Boolean hasCarrier;
        public Bike(string b, string m, double rate,Boolean hasCarrier) : base(b, m, rate)
        {
            this.hasCarrier = hasCarrier;
        }
        public override double CalculateRentalCost(int days)
        {
            return days * dailyRate;
        }
        public override void printDetails(int days)
        {
           
            Console.WriteLine($"Bike brand : {brand}, model : {model}, Carrier : {hasCarrier}, total cost : {CalculateRentalCost(days)}");
        }
    }
    class Truck : Vehicle
    {
        public int loadCapacity;
        public Truck(string b, string m, double rate, int loadCapacity) : base(b, m, rate)
        {
            this.loadCapacity = loadCapacity;

        }
        public override double CalculateRentalCost(int days)
        {
            return days * dailyRate;
        }
        public override void printDetails(int days)
        {
            
            Console.WriteLine($"Truck brand : {brand}, model : {model}, Capacity : {loadCapacity}, total cost : {CalculateRentalCost(days)}");
        }
    }

    public class Question28
    {
        bool keepRun = true;

        public Question28()
        {
            while (keepRun)
            {
                Console.WriteLine(" Select an animal ");
                Console.WriteLine("1 = Car");
                Console.WriteLine("2 = Bike");
                Console.WriteLine("3 = Truck");
                Console.WriteLine("4 = Exit");
                Console.Write("Select an option: ");
                int option = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter brand: ");
                string brand = Console.ReadLine();

                Console.Write("Enter model: ");
                string model = Console.ReadLine();

                Console.Write("Enter daily rate: ");
                double rate = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter days: ");
                int days = Convert.ToInt32(Console.ReadLine());

                Vehicle v = null;


                switch (option)
                {

                    case 1:
                        Console.Write("Enter number of doors: ");
                        int doors = Convert.ToInt32(Console.ReadLine());
                        v = new Car(brand,model,rate,doors);
                        break;

                    case 2:
                        v = new Bike(brand, model, rate, true);
                        break;
                    case 3:
                        Console.Write("Enter load capacity: ");
                        int loadCapacity = Convert.ToInt32(Console.ReadLine());
                        v = new Truck(brand, model, rate, loadCapacity);
                        break;
                    case 4:
                        keepRun = false;
                        Console.WriteLine("exit");
                        break;

                    default:
                        Console.WriteLine("Invalid option");
                        break;

                }
                v.printDetails(days);
            }
        }
    }
}