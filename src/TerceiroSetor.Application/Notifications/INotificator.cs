using FluentValidation.Results;

namespace TerceiroSetor.Application.Notifications
{
    public interface INotificator
    {
        bool HasNotification();
        IEnumerable<string> GetNotifications();
        void AddNotification(string notification);
        void AddNotifications(ValidationResult notifications);
    }

}
