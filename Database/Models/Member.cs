namespace Trip.Models;

public class Member
{
    public long Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string UserName { get; set; } = null!;
    public DateOnly DateOfBirth { get; set; }
    public ICollection<Trip>? Trips { get; set; } = new List<Trip>();

}

