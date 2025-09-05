using EventNotificationManager.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

public class NotificationController : ControllerBase
{
    private readonly INotificationService _notificationService;

    public NotificationController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendNotification([FromBody] NotificationDto notificationDto)
    {
        if (notificationDto == null
            || string.IsNullOrWhiteSpace(notificationDto.Recipient)
            || string.IsNullOrWhiteSpace(notificationDto.Message))
        {
            return BadRequest("Invalid notification data.");
        }

        await _notificationService.SendNotificationAsync(notificationDto);
        return Ok("Notification Sent Successfully");
    }
}