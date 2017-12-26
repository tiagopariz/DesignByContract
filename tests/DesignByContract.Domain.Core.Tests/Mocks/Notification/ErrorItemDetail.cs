using DesignByContract.Domain.Core.Notifications;

namespace DesignByContract.Domain.Core.Tests.Mocks.Notification
{
    public class FakeItemDetail : ItemDetail
    {
        public FakeItemDetail(string message, params string[] args)
            : base(message, args)
        {

        }
    }
}