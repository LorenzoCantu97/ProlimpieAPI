namespace ProlimpieAPI.Interfaces
{
    public interface IAuditable
    {
        string? CreatedById { get; set; }
        DateTime CreatedAt { get; set; }
        string? UpdatedById { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}
