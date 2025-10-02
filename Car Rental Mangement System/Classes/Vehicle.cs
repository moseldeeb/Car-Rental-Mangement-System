namespace Car_Rental_Mangement_System.Classes
{

    public enum VehicleType
    {
        Car = 1,
        Bike = 2,
        Truck = 3
    }
    public abstract class Vehicle
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public decimal PricePerDay { get; set; }
        public bool IsAvailable { get; set; } = true;

        public abstract string DisplayInfo();
    }
}
