// This interface will be implemented by each notification channel (Email, SMS).
// Follows the Observer Pattern - each handler is an observer.
namespace EventNotificationManager.Application.Interfaces
{
    public interface INotificationHandler
    {
        Task HandleAsync(NotificationDto notificationDto);
    }
}
