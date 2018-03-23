using DesignByContract.Core.Domain.Interfaces.Notifications;

namespace DesignByContract.Core.Domain.Notifications
{
    public abstract class ItemDetail : IItemDetail
    {
        public string Message { get; }

        protected ItemDetail(string message, params string[] args)
        {
            Message = message;

            if (string.IsNullOrWhiteSpace(Message)) return;

            for (var i = 0; i < args.Length; i++)
            {
                Message = Message.Replace("{" + i + "}", args[i]);
            }
        }

        public override string ToString() => Message;
    }
}