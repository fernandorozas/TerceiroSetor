using FluentValidation.Results;

namespace TerceiroSetor.Application.Notifications
{
    public class Notificator : INotificator
    {
        private List<string> _notifications;
        public Notificator() => _notifications = new List<string>();
        public IEnumerable<string> GetNotifications() => _notifications;
        public void AddNotification(string notification) => _notifications.Add(notification);
        public bool HasNotification() => _notifications.Any();

        public void AddNotifications(ValidationResult notifications)
        {
            foreach (var item in notifications.Errors)
            {
                _notifications.Add(item.ErrorMessage);
            }
        }
    }
}
