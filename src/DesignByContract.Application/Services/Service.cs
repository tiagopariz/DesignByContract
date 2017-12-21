using System.Collections;
using System.Linq;
using DesignByContract.Domain.Core.Entities;

namespace DesignByContract.Application.Services
{
    public abstract class Service
    {
        protected Entity NotificationEntity;

        public bool HasNotifications => NotificationEntity != null && NotificationEntity.Notification.HasNotifications;
        public bool HasErrors => NotificationEntity != null && NotificationEntity.Notification.HasErrors;
        public bool HasWarnings => NotificationEntity != null && NotificationEntity.Notification.HasWarnings;
        public bool HasInformations => NotificationEntity != null && NotificationEntity.Notification.HasInformations;

        public IEnumerable Errors()
        {
            if (NotificationEntity?.Notification.Errors == null) return null;

            var notifications = (from error in NotificationEntity?.Notification.Errors
                                 select $"Description: {error.Message} | " +
                                        $"Level: {error.Level.Description} | " +
                                        $"Field: {error.FieldName}").ToList();

            return notifications;
        }

        public IEnumerable Warnings()
        {
            if (NotificationEntity?.Notification.Warnings == null) return null;

            var notifications = (from error in NotificationEntity?.Notification.Warnings
                                 select $"Description: {error.Message} | " +
                                        $"Level: {error.Level.Description} | " +
                                        $"Field: {error.FieldName}").ToList();

            return notifications;
        }

        public IEnumerable Informations()
        {
            if (NotificationEntity?.Notification.Informations == null) return null;

            var notifications = (from error in NotificationEntity?.Notification.Informations
                                 select $"Description: {error.Message} | " +
                                        $"Level: {error.Level.Description} | " +
                                        $"Field: {error.FieldName}").ToList();

            return notifications;
        }
    }
}