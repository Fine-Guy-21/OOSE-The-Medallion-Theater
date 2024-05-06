namespace The_Medallion_Theater.Models
{
    public class BookingVm
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? PerformanceID { get; set; }
        public string? PerformanceName {  get; set; }
        public DateTime PerformanceDate {  get; set; }
        public string? PerformanceTime {  get; set; }
        public string? Seats { get; set; }
        public string? ReservedSeats {  get; set; }
        public double TotalPrice { get; set; }

    }

}
