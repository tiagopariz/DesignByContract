using System.Collections;
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
            return NotificationEntity?.Notification.Errors;
        }

        public IEnumerable Warnings()
        {
            return NotificationEntity?.Notification.Warnings;
        }

        public IEnumerable Informations()
        {
            return NotificationEntity?.Notification.Informations;
        }
    }
}