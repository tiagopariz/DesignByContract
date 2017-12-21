using DesignByContract.Domain.Core.Notifications;
using System.Collections.Generic;
using System.Linq;

namespace DesignByContract.Domain.Core.Errors
{
    public class ErrorList : Notification
    {
        public IReadOnlyList<ErrorItemDetail> Criticals => 
            List.Cast<ErrorItemDetail>().Where(x => x.Level is Critical).ToList();
        public IReadOnlyList<ErrorItemDetail> Warnings =>
            List.Cast<ErrorItemDetail>().Where(x => x.Level is Warning).ToList();
        public IReadOnlyList<ErrorItemDetail> Informations => 
            List.Cast<ErrorItemDetail>().Where(x => x.Level is Information).ToList();
        public bool HasCriticals => 
            List.Cast<ErrorItemDetail>().Any(x => x.Level is Critical);
        public bool HasWarnings => 
            List.Cast<ErrorItemDetail>().Any(x => x.Level is Warning);
        public bool HasInformations => 
            List.Cast<ErrorItemDetail>().Any(x => x.Level is Information);
    }
}