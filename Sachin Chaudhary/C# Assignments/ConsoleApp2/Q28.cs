//using System;

//namespace Project1
//{
//    public class Vehicle
//    {
//        public string brand;
//        public string model;
//        public double Price;

//        public Vehicle(string brand1, string model1, double price1)
//        {
//            brand = brand1;
//            model = model1;
//            Price = price1;
//        }
//    }

//    public class Car : Vehicle
//    {
//        public int DoorCount;

//        public Car(string make, string version, double price, int doors) : base(make, version, price)
//        {
//            DoorCount = doors;
//        }
//    }

//    public class Bike : Vehicle
//    {
//        public bool Hascarrier;

//        public Bike(string make, string version, double price, bool Hascarrier1) : base(make, version, price)
//        {
//            Hascarrier = Hascarrier1;
//        }
//    }

//    public class Truck : Vehicle
//    {
//        public double LoadCapacity;

//        public Truck(string make, string version, double price, double load) : base(make, version, price)
//        {
//            LoadCapacity = load;
//        }
//    }

//    public class VehicleRentalSystem
//    {

//        private Car myCar = new Car("suziki", "City", 3000, 4);
//        private Bike myBike = new Bike("Hero", "Xtreme", 1000, true);
//        private Truck myTruck = new Truck("Tata", "Ace", 5000, 2.5);

//        public void StartSystem()
//        {
//            int userSelection;
//            do
//            {
//                Console.WriteLine("Vehicle Rental System");
//                Console.WriteLine("1. View Car");
//                Console.WriteLine("2. View Bike");
//                Console.WriteLine("3. View Truck");
//                Console.WriteLine("4. Get Billing Info");
//                Console.WriteLine("5. Exit");
//                Console.Write("Select an option: ");
//                userSelection = Convert.ToInt32(Console.ReadLine());

//                switch (userSelection)
//                {
//                    case 1:
//                        DCar();
//                        break;
//                    case 2:
//                        DB();
//                        break;
//                    case 3:
//                        DT();
//                        break;
//                    case 4:
//                        Program();
//                        break;
//                    case 5:
//                        Console.WriteLine("bye");
//                        break;
//                    default:
//                        Console.WriteLine("Error");
//                        break;
//                }
//            } while (userSelection != 5);
//        }

//        public void DCar()
//        {
//            Console.WriteLine("--- Car Details ---");
//            Console.WriteLine("Make: " + myCar.brand);
//            Console.WriteLine("Version: " + myCar.model);
//            Console.WriteLine("Price/Day: " + myCar.Price);
//            Console.WriteLine("Doors: " + myCar.DoorCount);
//        }

//        public void DB()
//        {
//            Console.WriteLine("--- Bike Details ---");
//            Console.WriteLine("Make: " + myBike.brand);
//            Console.WriteLine("Version: " + myBike.model);
//            Console.WriteLine("Price/Day: " + myBike.Price);
//            Console.WriteLine("Carrier Included: " + (myBike.Hascarrier ? "Yes" : "No"));
//        }

//        public void DT()
//        {
//            Console.WriteLine("--- Truck Details ---");
//            Console.WriteLine("Make: " + myTruck.brand);
//            Console.WriteLine("Version: " + myTruck.model);
//            Console.WriteLine("Price/Day: " + myTruck.Price);
//            Console.WriteLine("Max Capacity: " + myTruck.LoadCapacity + " tons");
//        }

//        public void Program()
//        {
//            Console.Write("vehicle (car/bike/truck): ");
//            string category = Console.ReadLine().ToLower();

//            Console.Write(" how many (days): ");
//            int rentalDuration = Convert.ToInt32(Console.ReadLine());

//            double billTotal = 0;

//            if (category == "car")
//                billTotal = myCar.Price * rentalDuration;
//            else if (category == "bike")
//                billTotal = myBike.Price * rentalDuration;
//            else if (category == "truck")
//                billTotal = myTruck.Price * rentalDuration;
//            else
//            {
//                Console.WriteLine("Error");
//                return;
//            }

//            Console.WriteLine("Grand Total: " + billTotal);
//        }
//    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            VehicleRentalSystem engine = new VehicleRentalSystem();
//            engine.StartSystem();
//        }
//    }
//}
