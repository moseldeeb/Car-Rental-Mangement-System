using System.Runtime.CompilerServices;

namespace Car_Rental_Mangement_System.Classes
{
    public class RentalSystem
    {
        private List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        private List<Rental> Rentals { get; set; } = new List<Rental>();

        public IReadOnlyList<Vehicle> GetVehicles() => Vehicles.AsReadOnly();
        public IReadOnlyList<Rental> GetRentals() => Rentals.AsReadOnly();

        public bool AddVehicle(Vehicle v)
        {
            //Prevent adding duplicate vehicles
            if (Vehicles.Any(i => v.Model == i.Model && v.Brand == i.Brand))
                return false;
            else
            {
                Vehicles.Add(v);
                return true;
            }
        }

        public List<Vehicle> ShowAvailableVehicles()
        {
            //Without LINQ

            /* List<Vehicle> available = new List<Vehicle>();

             foreach (var vehicle in Vehicles)
             {
                 if (vehicle.IsAvailable)
                     available.Add(vehicle);
             }
             if (available.Count > 0)
                 return available;
             else
             return null;*/

            //With LINQ
            return Vehicles.Where(v => v.IsAvailable).ToList();
        }
        public Rental RentVehicle(Vehicle chosenVehicle, string customerName, int days, decimal totalCost)
        {
            chosenVehicle.IsAvailable = false;
            var rentedVehicle = new Rental(chosenVehicle, customerName, days, totalCost);
            Rentals.Add(rentedVehicle);
            return rentedVehicle;
        }
        public List<Rental>  ShowRentals()
        {
            return Rentals;
        }
    }
}
