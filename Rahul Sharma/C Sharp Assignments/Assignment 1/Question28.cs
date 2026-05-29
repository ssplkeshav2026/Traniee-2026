
//28.Vehicle Rental Console System:
//Base class: Vehicle(Brand, Model, DailyRate)
//Derived: Car(NumberOfDoors), Bike(HasCarrier), Truck(Load Capacity)
//Console menu to display different vehicles and calculate rental costs


using System;
using System.Collections.Generic;

class Vehicle
{
    public string Brand;
    public string Model;
    public double DailyRate;

    public Vehicle(string brand, string model, double dailyRate)
    {
        Brand = brand;
        Model = model;
        DailyRate = dailyRate;
    }

    public virtual void DisplayDetails()
    {
        Console.WriteLine("Brand: " + Brand);
        Console.WriteLine("Model: " + Model);
        Console.WriteLine("Daily Rate: " + DailyRate);
    }

    public double CalculateRentalCost(int days)
    {
        return DailyRate * days;
    }
}

class Car : Vehicle
{
    public int NumberOfDoors;

    public Car(string brand, string model, double dailyRate, int numberOfDoors)
        : base(brand, model, dailyRate)
    {
        NumberOfDoors = numberOfDoors;
    }

    public override void DisplayDetails()
    {
        Console.WriteLine("\n--- Car Details ---");
        base.DisplayDetails();
        Console.WriteLine("Number Of Doors: " + NumberOfDoors);
    }
}

class Bike : Vehicle
{
    public bool HasCarrier;

    public Bike(string brand, string model, double dailyRate, bool hasCarrier)
        : base(brand, model, dailyRate)
    {
        HasCarrier = hasCarrier;
    }

    public override void DisplayDetails()
    {
        Console.WriteLine("\n--- Bike Details ---");
        base.DisplayDetails();
        Console.WriteLine("Has Carrier: " + HasCarrier);
    }
}

class Truck : Vehicle
{
    public double LoadCapacity;

    public Truck(string brand, string model, double dailyRate, double loadCapacity)
        : base(brand, model, dailyRate)
    {
        LoadCapacity = loadCapacity;
    }

    public override void DisplayDetails()
    {
        Console.WriteLine("\n--- Truck Details ---");
        base.DisplayDetails();
        Console.WriteLine("Load Capacity: " + LoadCapacity + " tons");
    }
}

class VehicleRentalSystem
{
    public VehicleRentalSystem()
    {
        List<Vehicle> vehicles = new List<Vehicle>();

        vehicles.Add(new Car("Toyota", "Innova", 3000, 4));
        vehicles.Add(new Bike("Honda", "Shine", 700, true));
        vehicles.Add(new Truck("Tata", "Ace", 2500, 1.5));

        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("\n--- Vehicle Rental System ---");
            Console.WriteLine("1. Display All Vehicles");
            Console.WriteLine("2. Calculate Rental Cost");
            Console.WriteLine("3. Exit");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    foreach (Vehicle v in vehicles)
                    {
                        v.DisplayDetails();
                    }
                    break;

                case 2:
                    Console.WriteLine("\nSelect Vehicle:");
                    for (int i = 0; i < vehicles.Count; i++)
                    {
                        Console.WriteLine((i + 1) + ". " + vehicles[i].Brand + " " + vehicles[i].Model);
                    }

                    Console.Write("Enter vehicle number: ");
                    int vehicleNumber = int.Parse(Console.ReadLine());

                    if (vehicleNumber >= 1 && vehicleNumber <= vehicles.Count)
                    {
                        Console.Write("Enter number of rental days: ");
                        int days = int.Parse(Console.ReadLine());

                        double cost = vehicles[vehicleNumber - 1].CalculateRentalCost(days);

                        Console.WriteLine("Total Rental Cost: " + cost);
                    }
                    else
                    {
                        Console.WriteLine("Invalid vehicle number!");
                    }
                    break;

                case 3:
                    isRunning = false;
                    Console.WriteLine("Program Closed.");
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }
}