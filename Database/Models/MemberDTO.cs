namespace Trip.Models;

public class  MemberDTO
{
    public long Id { get; set; }
    public string UserName { get; set; } = null!;
    public DateOnly DateOfBirth { get; set; }
    public List<long> TripIds { get; set; } = new();
}