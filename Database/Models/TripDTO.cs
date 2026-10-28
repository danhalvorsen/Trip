namespace Trip.Models
{
    public class TripDTO
    {
        public long Id { get; set; }
        public string Destination { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double Lat { get; set; }
        public double Lon { get; set; }
        public List<long> MemberIds { get; set; } = new();
    }
}
