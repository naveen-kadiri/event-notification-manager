# COMPONENT                             # PURPOSE
INotificationService.cs---------------->Main Service to send notifications
INotificationHandler.cs---------------->Observer interface for channels
INotificationRepository.cs------------->Interface for DB operations
NotificationDto.cs--------------------->API-facing data model
Notification.cs------------------------>Domain entity
NotificationType.cs-------------------->Enum for channel type

# NotificationService
IEnumerable<INotificationHandler>------>Injects all registered handlers
OnNotificationSent--------------------->Delegate event to notify handlers
HandleAsync---------------------------->Each Handler implements this method
Invoke(notificationDto)---------------->Triggers all subscribed handlers
SaveNotificationAsync------------------>Persists the notification to DB.

    ## OBSERVER DESIGN PATTERN
    The Observer Pattern is a behavioral design pattern where:
        1. A subject maintains a list of observers.
        2. When the subject's state changes, it notifies all observers.
    
    Here, 
        1. subject is **NotificationService**
        2. observers are **INotificationHandler** implementations (Email, SMS)
        3. The event (OnNotificationSent) is the mechanism to notify them.
    
    # Observer Pattern Concept          # Your Code
    Subject---------------------------->NotificationService
    Observer Interface----------------->INotificationHandler
    Observer Instances----------------->EmailNotificationHandler, SMSNotificationHandler
    Subscription----------------------->OnNotificationSent += handler.HandlerAsync
    NotificationTrigger---------------->OnNotificationSent.Invoke(notificationDto)