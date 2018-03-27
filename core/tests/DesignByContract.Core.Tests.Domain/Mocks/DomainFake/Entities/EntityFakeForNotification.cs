using DesignByContract.Core.Tests.Domain.Mocks.CoreDomainFake.Notification;

namespace DesignByContract.Core.Tests.Domain.Mocks.DomainFake.Entities
{
    public class EntityFakeForNotification
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
        public bool Active { get; set; }
        public NotificationFake NotificationFake { get; } = new NotificationFake();
    }
}