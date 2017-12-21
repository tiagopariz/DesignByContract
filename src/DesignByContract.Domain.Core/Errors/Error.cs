using System.Collections.Generic;
using System.Linq;
using DesignByContract.Domain.Core.Notifications;

namespace DesignByContract.Domain.Core.Errors
{
    public class Error : Notification
    {
        public IReadOnlyList<ErrorDescription> Errors => List.Cast<ErrorDescription>().Where(x => x.Level is Critical).ToList();
        public IReadOnlyList<ErrorDescription> Warnings => List.Cast<ErrorDescription>().Where(x => x.Level is Warning).ToList();
        public IReadOnlyList<ErrorDescription> Informations => List.Cast<ErrorDescription>().Where(x => x.Level is Information).ToList();
        public bool HasErrors => List.Cast<ErrorDescription>().Any(x => x.Level is Critical);
        public bool HasWarnings => List.Cast<ErrorDescription>().Any(x => x.Level is Warning);
        public bool HasInformations => List.Cast<ErrorDescription>().Any(x => x.Level is Information);
    }
}