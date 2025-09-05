// This is the domain entity representing a notification.
// Will be persisted (Stored/Saved) to the database.
public class Notification
{
    public int Id { get; set; }
    public string? Recipient { get; set; }
    public string? Message { get; set; }
    public NotificationType Type { get; set; }
    public DateTime SendAt { get; set; }
}