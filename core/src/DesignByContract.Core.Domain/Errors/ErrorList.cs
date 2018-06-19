using DesignByContract.Core.Domain.Interfaces.Errors;
using DesignByContract.Core.Domain.Notifications;
using System.Collections.Generic;
using System.Linq;

namespace DesignByContract.Core.Domain.Errors
{
    public class ErrorList : Notification, IErrorList
    {
        public IReadOnlyList<IErrorItemDetail> Criticals =>
            List.Cast<IErrorItemDetail>().Where(x => x.Level is Critical).ToList();
        public IReadOnlyList<IErrorItemDetail> Warnings =>
            List.Cast<IErrorItemDetail>().Where(x => x.Level is Warning).ToList();
        public IReadOnlyList<IErrorItemDetail> Informations =>
            List.Cast<IErrorItemDetail>().Where(x => x.Level is Information).ToList();

        public bool HasCriticals()
        {
            return List.Cast<IErrorItemDetail>().Any(x => x.Level is Critical);
        }

        public bool HasWarnings()
        {
            return List.Cast<IErrorItemDetail>().Any(x => x.Level is Warning);
        }

        public bool HasInformations()
        {
            return List.Cast<IErrorItemDetail>().Any(x => x.Level is Information);
        }
    }
}