using EventNotificationManager.Application.Interfaces;

public class SmsNotificationHandler : INotificationHandler
{
    public async Task HandleAsync(NotificationDto notificationDto)
    {
        if (notificationDto.Type != NotificationType.SMS)
        {
            return;
        }

        Console.WriteLine($"SMS sent to {notificationDto.Recipient}: {notificationDto.Message}");
        await Task.CompletedTask;
    }
}