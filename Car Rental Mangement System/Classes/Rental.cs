namespace Car_Rental_Mangement_System.Classes
{
    public class Rental
    {

        public Vehicle Vehicle { get; set; }
        public string CustomerName { get; set; }
        public int Days { get; set; }
        public decimal TotalCost { get; set; }
        public Rental(Vehicle vehicle, string customerName, int days, decimal totalCost)
        {
            Vehicle = vehicle;
            CustomerName = customerName;
            Days = days;
            TotalCost = totalCost;
        }
    }
}
