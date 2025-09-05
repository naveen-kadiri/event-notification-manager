using EventNotificationManager.Application.Interfaces;

public class EmailNotificationHandler : INotificationHandler
{
    public async Task HandleAsync(NotificationDto notificationDto)
    {
        if (notificationDto.Type != NotificationType.Email)
        {
            return;
        }

        // Simulate sending email
        Console.WriteLine($"Email sent to {notificationDto.Recipient}: {notificationDto.Message}");
        await Task.CompletedTask;
    }
}