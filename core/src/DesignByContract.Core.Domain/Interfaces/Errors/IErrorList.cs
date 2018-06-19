using DesignByContract.Core.Domain.Interfaces.Notifications;
using System.Collections.Generic;

namespace DesignByContract.Core.Domain.Interfaces.Errors
{
    public interface IErrorList : INotification
    {
        IReadOnlyList<IErrorItemDetail> Criticals { get; }
        IReadOnlyList<IErrorItemDetail> Warnings { get; }
        IReadOnlyList<IErrorItemDetail> Informations { get; }
        bool HasCriticals();
        bool HasWarnings();
        bool HasInformations();
    }
}