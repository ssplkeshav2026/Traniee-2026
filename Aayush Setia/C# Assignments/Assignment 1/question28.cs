using System;
using System.Collections.Generic;
using System.Text;

namespace assignment_c__1
{
    internal class question28
    {
        class Vehicle
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public double DailyRate { get; set; }

            public Vehicle(string brand, string model, double rate)
            {
                Brand = brand;
                Model = model;
                DailyRate = rate;
            }

            public virtual void DisplayInfo()
            {
                Console.Write(Brand + " " + Model + " (Rate: " + DailyRate + "/day)");
            }
        }

        class Car : Vehicle
        {
            public int NumberOfDoors { get; set; }

            public Car(string b, string m, double r, int doors) : base(b, m, r)
            {
                NumberOfDoors = doors;
            }

            public override void DisplayInfo()
            {
                base.DisplayInfo();
                Console.WriteLine(" - " + NumberOfDoors + " Doors");
            }
        }

        class Bike : Vehicle
        {
            public bool HasCarrier { get; set; }

            public Bike(string b, string m, double r, bool carrier) : base(b, m, r)
            {
                HasCarrier = carrier;
            }

            public override void DisplayInfo()
            {
                base.DisplayInfo();
                Console.WriteLine(" - Carrier: " + HasCarrier);
            }
        }

        class Truck : Vehicle
        {
            public double LoadCapacity { get; set; }

            public Truck(string b, string m, double r, double cap) : base(b, m, r)
            {
                LoadCapacity = cap;
            }

            public override void DisplayInfo()
            {
                base.DisplayInfo();
                Console.WriteLine(" - Capacity: " + LoadCapacity + " tons");
            }
        }

        public question28()
        {
            List<Vehicle> ghora = new List<Vehicle>()
            {
                new Car("Toyota Car", "Camry", 50, 4),
                new Bike("Bike", "Escape", 15, true),
                new Truck("Volvo Truck", "FH16", 200, 25)
            };

            Console.WriteLine("Rental System ");

            for (int i = 0; i < ghora.Count; i++)
            {
                Console.Write((i + 1) + ". ");
                ghora[i].DisplayInfo();
            }

            Console.Write("\nSelect vehicle number: ");
            int choice = Convert.ToInt32(Console.ReadLine()) - 1;

            Console.Write("Enter rental days: ");
            int days = Convert.ToInt32(Console.ReadLine());

            double total = ghora[choice].DailyRate * days;

            Console.WriteLine("Total Rental Cost: " + total);
        }
    }
}