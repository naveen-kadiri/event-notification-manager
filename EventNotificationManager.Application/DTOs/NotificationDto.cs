// This is data transfer object (DTO) used by the controller and service.
// Keeps the API layer decoupled from domain entities.

public class NotificationDto
{
    public string? Recipient { get; set; }
    public string? Message { get; set; }
    public NotificationType Type { get; set; } // Email or SMS
}