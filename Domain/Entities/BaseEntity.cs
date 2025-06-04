namespace Domain.Entities;

public abstract class BaseEntity
{
    public DateTime Created_at { get; set; } = DateTime.UtcNow;
    public DateTime? Updated_at  { get; set; }
}