using Car_Rental_Mangement_System.Classes;

namespace Car_Rental_Mangement_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rentalSystem = new RentalSystem();
            string choice = "";
             dfge
            while (choice != "5")
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add vehicle (Car / Bike / Truck)");
                Console.WriteLine("2. Show available vehicles");
                Console.WriteLine("3. Rent a vehicle");
                Console.WriteLine("4. Show rentals");
                Console.WriteLine("5. Exit");

                Console.Write("Please enter your choice: ");
                choice = Console.ReadLine();

                // Add a vehicle
                if (choice == "1")
                {
                    char vehicleType = ' ';
                    while (vehicleType != '1' && vehicleType != '2' && vehicleType != '3')
                    {
                        Console.WriteLine("\nSelect Vehicle Type: (1.Car/ 2.Bike/ 3.Truck)\n");
                        vehicleType = Console.ReadKey().KeyChar;
                        if (vehicleType == '1')
                        {
                            Car car = new Car();
                            Console.WriteLine("\nEnter the Car Model: ");
                            car.Model = Console.ReadLine();

                            Console.WriteLine("\nEnter the Car Brand: ");
                            car.Brand = Console.ReadLine();

                            Console.WriteLine("\nEnter the Car Price per Day: ");
                            car.PricePerDay = Convert.ToDecimal(Console.ReadLine());

                            Console.WriteLine("\nHow many Seats?");
                            car.Seats = Convert.ToInt32(Console.ReadLine());
                            rentalSystem.AddVehicle(car);
                            Console.WriteLine("The Car Have been added Successfully.");
                        }
                        else if (vehicleType == '2')
                        {
                            Bike bike = new Bike();
                            Console.WriteLine("\nEnter the Bike Model: ");
                            bike.Model = Console.ReadLine();

                            Console.WriteLine("\nEnter the Bike Brand: ");
                            bike.Brand = Console.ReadLine();

                            Console.WriteLine("\nEnter the Bike Price per Day: ");
                            bike.PricePerDay = Convert.ToDecimal(Console.ReadLine());

                            Console.WriteLine("\nComes with a Helmet? (Y/N)");
                            bike.Helmet = Char.ToUpper(Console.ReadKey().KeyChar) == 'Y' ? true : false;
                            rentalSystem.AddVehicle(bike);
                            Console.WriteLine("The Bike Have been added Successfully.");

                        }
                        else if (vehicleType == '3')
                        {
                            Truck truck = new Truck();
                            Console.WriteLine("\nEnter the Truck Model: ");
                            truck.Model = Console.ReadLine();

                            Console.WriteLine("\nEnter the Truck Brand: ");
                            truck.Brand = Console.ReadLine();

                            Console.WriteLine("\nEnter the Truck Price per Day: ");
                            truck.PricePerDay = Convert.ToDecimal(Console.ReadLine());

                            Console.WriteLine("\nEnter the Truck Capacity in KG.");
                            truck.LoadCapacity = Convert.ToInt32(Console.ReadLine());
                            rentalSystem.AddVehicle(truck);
                            Console.WriteLine("The Truck Have been added Successfully.");

                        }
                        else
                            Console.WriteLine("\nWrong Input!, Try again.");

                    }
                }

                // Show available vehicles
                else if (choice == "2")
                {
                    var availableVehicles = rentalSystem.ShowAvailableVehicles();
                    if (!availableVehicles.Any())
                    {
                        Console.WriteLine("\nNo Vehicles available.");
                        continue;
                    }
                    else
                    {
                        foreach (var available in availableVehicles)
                        {
                            Console.WriteLine(available.DisplayInfo());
                        }
                    }
                }

                // Rent a vehicle
                else if (choice == "3")
                {
                    int selection = 0;
                    var availableVehicles = rentalSystem.ShowAvailableVehicles();

                    if (!availableVehicles.Any())
                    {
                        Console.WriteLine("\nNo Vehicles available for rent.");
                        continue;
                    }

                    Console.WriteLine("\nAvailable Vehicles:\n");
                    for (int i = 0; i < availableVehicles.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {availableVehicles[i].DisplayInfo()}\n");
                    }

                    while (selection < 1 || selection > availableVehicles.Count)
                    {
                        Console.WriteLine("Choose the Vehicle you want to rent by the number: ");
                        selection = Convert.ToInt32(Console.ReadLine());

                    }
                    var chosenVehicle = availableVehicles[selection - 1];


                    Console.WriteLine("Enter Customer Name: ");
                    string customerName = Console.ReadLine();

                    Console.WriteLine("How many Days do you want to rent it?");
                    int days = Convert.ToInt32(Console.ReadLine());

                    decimal totalCost = chosenVehicle.PricePerDay * days;

                    Console.WriteLine($"Total Cost = {totalCost:F2} EGP\n Type \"1\" to confirm or \"0\" to Decline.");

                    while (true)
                    {
                        char confirm = Console.ReadKey().KeyChar;
                        if (confirm == '1')
                        {
                            rentalSystem.RentVehicle(chosenVehicle, customerName, days, totalCost);
                            break;
                        }
                        else if (confirm == '0')
                        {
                            Console.WriteLine("\nRental Cancelled.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid Input.");

                        }

                    }
                }

                // Show rentals
                else if (choice == "4")
                {
                    var rentals = rentalSystem.ShowRentals();
                    if (!rentals.Any())
                    {
                        Console.WriteLine("\nNo Rentals yet.");
                        continue;
                    }
                    foreach (var rented in rentals)
                    {
                        Console.WriteLine(
                            $"\nCustomer: {rented.CustomerName}" +
                            $"\nVehicle: {rented.Vehicle.Brand} {rented.Vehicle.Model}" +
                            $"\nDuration: {rented.Days} Days" +
                            $"\nTotal Cost: {rented.TotalCost:F2} EGP" +
                            $"\n_______________________________");
                    }
                }

                // Exit
                else if (choice == "5")
                    Console.WriteLine("\nGood Bye.");
                else
                    Console.WriteLine("\nWrong selection please tey again.");


            }
        }
    }
}
