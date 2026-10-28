using Trip.Migrations;

namespace Trip.Models
{
    public class Trip : AuditableEntity
    {
        public long Id { get; set; }
        public string Destination { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double Lat { get; set; }
        public double Lon { get; set; }
        public ICollection<Member>? Members { get; set; }

    }
}
