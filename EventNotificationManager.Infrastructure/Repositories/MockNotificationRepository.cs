using EventNotificationManager.Application.Interfaces;

public class MockNotificationRepository : INotificationRepository
{
    private readonly List<Notification> _notifications = new();
    public Task SaveNotificationAsync(Notification notification)
    {
        notification.Id = _notifications.Count + 1;
        _notifications.Add(notification);
        Console.WriteLine($"Mock Save: Notification to {notification.Recipient} stored in memory");
        return Task.CompletedTask;
    }
}