namespace Car_Rental_Mangement_System.Classes
{
    public class Car : Vehicle
    {
        public int Seats { get; set; }
        public override string DisplayInfo()
        {
            return $"Model : {Model}, Brand : {Brand}, Price/Day : {PricePerDay:F2} EGP, Seats : {Seats}";
        }
    }
}
