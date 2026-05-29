using Project1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Vehicle
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double DailyRate { get; set; }


        public Vehicle(string b, string m, double r)
        {
            Brand = b;
            Model = m;
            DailyRate = r;
        }

        public void finalCode()
        {
            Car myCar = new Car("Toyota", "Corolla", 50.0, 4);
            Bike myBike = new Bike("Yamaha", "MT-07", 30.0, false);
            Truck myTruck = new Truck("Ford", "F-150", 100.0, 1.5);

            Console.WriteLine("Enter choice:");
            int choice = int.Parse(Console.ReadLine());
            do
            {
                Console.WriteLine("1. Car (" + myCar.Brand + ")");
                Console.WriteLine("2. Bike (" + myBike.Brand + ")");
                Console.WriteLine("3. Truck (" + myTruck.Brand + ")");
                Console.WriteLine("0. Exit");
                Console.Write("Select option: ");


                if (choice >= 1 && choice <= 3)
                {
                    Console.Write("Enter rental days: ");
                    int days = int.Parse(Console.ReadLine());

                    double rate = (choice == 1) ? myCar.DailyRate : (choice == 2) ? myBike.DailyRate : myTruck.DailyRate;
                    Console.WriteLine("Total Cost: $" + (rate * days));
                }
            } while (choice != 0);
        }
    }
    class Car : Vehicle
    {
        public int Doors;
        public Car(string b, string m, double r, int d) : base(b, m, r)
        {
            Doors = d;
        }
    }

    class Bike : Vehicle
    {
        public bool HasCarrier;
        public Bike(string b, string m, double r, bool c) : base(b, m, r)
        {
            HasCarrier = c;
        }
    }

    class Truck : Vehicle
    {
        public double LoadCapacity;
        public Truck(string b, string m, double r, double l) : base(b, m, r)
        {
            LoadCapacity = l;
        }
    }
   
}



