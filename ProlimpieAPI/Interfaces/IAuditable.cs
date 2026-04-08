namespace ProlimpieAPI.Interfaces
{
    public interface IAuditable
    {
        int? CreatedById { get; set; }
        DateTime CreatedAt { get; set; }
        int? UpdatedById { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}
