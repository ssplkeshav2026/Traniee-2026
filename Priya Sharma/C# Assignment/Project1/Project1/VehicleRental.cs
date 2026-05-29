using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
     public class VehicleRental
    {
        public string Brand;
        public string Model;
        public double DailyRate;

        public VehicleRental(string brand, string model, double rate)
        {
            Brand = brand;
            Model = model;
            DailyRate = rate;
        }
    }

    public class Car : VehicleRental
    {
        public int NumberOfDoors;

        public Car(string brand, string model, double rate, int doors) : base(brand, model, rate)
        {
            NumberOfDoors = doors;
        }
    }

    public class Bike : VehicleRental
    {
        public bool HasCarrier;

        public Bike(string brand, string model, double rate, bool carrier) : base(brand, model, rate)
        {
            HasCarrier = carrier;
        }
    }

    public class Truck : VehicleRental
    {
        public double LoadCapacity;

        public Truck(string brand, string model, double rate, double capacity) : base(brand, model, rate)
        {
            LoadCapacity = capacity;
        }
    }

    public class VehicleRentalSystem
    {
        Car car = new Car("Honda", "City", 3000, 4);
        Bike bike = new Bike("Hero", "Xtreme", 1000, true);
        Truck truck = new Truck("Tata", "Ace", 5000, 2.5);
        

        
        public void System()
        {
            int choice;

            do
            {
                Console.WriteLine("\nVehicle Rental System");
                Console.WriteLine("1. Show Car");
                Console.WriteLine("2. Show Bike");
                Console.WriteLine("3. Show Truck");
                Console.WriteLine("4. Calculate Rental Cost");
                Console.WriteLine("5. Exit");
                Console.Write("Enter choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ShowCar();
                        break;

                    case 2:
                        ShowBike();
                        break;

                    case 3:
                        ShowTruck();
                        break;

                    case 4:
                        CalculateRental();
                        break;

                    case 5:
                        Console.WriteLine("Program Exit...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.....");
                        break;
                }

            } while (choice != 5);
        }

        public void ShowCar()
        {
            Console.WriteLine("\nCar Details");
            Console.WriteLine("Brand: " + car.Brand);
            Console.WriteLine("Model: " + car.Model);
            Console.WriteLine("Daily Rate: " + car.DailyRate);
            Console.WriteLine("Doors: " + car.NumberOfDoors);
        }

        public void ShowBike()
        {
            Console.WriteLine("\nBike Details");
            Console.WriteLine("Brand: " + bike.Brand);
            Console.WriteLine("Model: " + bike.Model);
            Console.WriteLine("Daily Rate: " + bike.DailyRate);
            Console.WriteLine("Carrier: " + bike.HasCarrier);
        }

        public void ShowTruck()
        {
            Console.WriteLine("\nTruck Details");
            Console.WriteLine("Brand: " + truck.Brand);
            Console.WriteLine("Model: " + truck.Model);
            Console.WriteLine("Daily Rate: " + truck.DailyRate);
            Console.WriteLine("Load Capacity: " + truck.LoadCapacity);
        }

        public void CalculateRental()
        {
            Console.Write("Enter vehicle type(car/bike/truck): ");
            string type = Console.ReadLine().ToLower();

            Console.Write("Enter no. of days: ");
            int days = Convert.ToInt32(Console.ReadLine());

            double total = 0;

            if (type == "car")
                total = car.DailyRate * days;
            else if (type == "bike")
                total = bike.DailyRate * days;
            else if (type == "truck")
                total = truck.DailyRate * days;
            else
            {
                Console.WriteLine("Invalid vehicle type");
                return;
            }

            Console.WriteLine("Total rental cost: " + total);
        }
    }

}





