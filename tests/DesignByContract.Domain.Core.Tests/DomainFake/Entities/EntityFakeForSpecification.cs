using DesignByContract.Domain.Core.Tests.DomainCoreFake.Notification;

namespace DesignByContract.Domain.Core.Tests.DomainFake.Entities
{
    public class EntityFakeForSpecification
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
        public bool Active { get; set; }
        public NotificationFake NotificationFake { get; } = new NotificationFake();
    }
}