// This service will
// Accept a Notification Dto.
// Notify all registered handlers (Email, SMS).
// Use Observer Pattern to manage handlers.
// Use Delegates/Events to trigger them dynamically
using EventNotificationManager.Application.Interfaces;

public class NotificationService : INotificationService
{

    private readonly IEnumerable<INotificationHandler> _handlers;
    private readonly INotificationRepository _repository;

    // Delegate for notification event
    public delegate Task NotificationSentHandler(NotificationDto notificationDto);
    public event NotificationSentHandler? OnNotificationSent;

    public NotificationService(IEnumerable<INotificationHandler> handlers,
    INotificationRepository repository)
    {
        _handlers = handlers;
        _repository = repository;

        // Subscribe all handlers to the event
        foreach (var handler in _handlers)
        {
            OnNotificationSent += handler.HandleAsync;
        }
    }

    public async Task SendNotificationAsync(NotificationDto notificationDto)
    {
        // Notify all observers
        if (OnNotificationSent != null)
        {
            await OnNotificationSent.Invoke(notificationDto);
        }

        // Save to DB
        var notification = new Notification
        {
            Recipient = notificationDto.Recipient,
            Message = notificationDto.Message,
            Type = notificationDto.Type,
            SendAt = DateTime.UtcNow
        };

        await _repository.SaveNotificationAsync(notification);
    }
}