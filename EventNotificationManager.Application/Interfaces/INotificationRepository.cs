// This interface abstracts the data access logic.
// Will be implemented using EntityFrameworkCore in the Infrastructure Layer.
namespace EventNotificationManager.Application.Interfaces
{
    public interface INotificationRepository
    {
        Task SaveNotificationAsync(Notification notification);
    }
}