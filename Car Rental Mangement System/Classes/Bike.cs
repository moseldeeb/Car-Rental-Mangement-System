namespace Car_Rental_Mangement_System.Classes
{
    public class Bike : Vehicle
    {
        public bool Helmet { get; set; }
        public override string DisplayInfo()
        {
            return $"Model : {Model}, Brand : {Brand}, Price/Day : {PricePerDay:F2} EGP, Helmet : {Helmet}";
        }
    }
}
