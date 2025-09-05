// This is the main service interface that controller will call.
// it encapsulates the logic that to send notifications via different channels.
namespace EventNotificationManager.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendNotificationAsync(NotificationDto notificationDto);
    }
}
