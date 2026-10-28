namespace Trip.Models;

public abstract class AuditableEntity
{
    public DateTime CreatedAtUtc { get; set; }
    public string? CreatedBy { get; set; }

    public DateTime ModifiedAtUtc { get; set; }
    public string? ModifiedBy { get; set; }

    public DateTime? DeletedAtUtc { get; set; }
    public string? DeletedBy { get; set; }

    public bool IsDeleted { get; set; }
}