namespace The_Medallion_Theater.Models
{
    public class BookingVm
    {
        public Patron patron { get; set; }
        public Performance performance { get; set; }
        List <string>? Seats { get; set; }
        public int TotalPrice { get; set; }
    }

}
