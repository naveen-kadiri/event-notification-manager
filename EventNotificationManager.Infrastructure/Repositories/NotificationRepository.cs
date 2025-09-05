using EventNotificationManager.Application.Interfaces;

public class NotificationRepository : INotificationRepository
{
    private readonly EventDbContext _context;
    public NotificationRepository(EventDbContext context)
    {
        _context = context;
    }
    public async Task SaveNotificationAsync(Notification notification)
    {
        _context.Notifications.Add(notification);
        await _context.SaveChangesAsync();
    }
}