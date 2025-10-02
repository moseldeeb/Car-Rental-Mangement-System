namespace Car_Rental_Mangement_System.Classes
{
    public class Truck : Vehicle
    {
        public int LoadCapacity { get; set; }
        public override string DisplayInfo()
        {
            return $"Model : {Model}, Brand : {Brand}, Price/Day : {PricePerDay:F2} EGP, Load Capacity : {LoadCapacity}KG";
        }
    }
}
