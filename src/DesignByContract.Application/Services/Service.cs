using DesignByContract.Domain.Core.Entities;
using System.Collections;
using System.Linq;

namespace DesignByContract.Application.Services
{
    public abstract class Service
    {
        protected Entity ErrorEntity;

        public bool HasErrors => 
            ErrorEntity != null && ErrorEntity.ErrorList.Any;
        public bool HasCriticals => 
            ErrorEntity != null && ErrorEntity.ErrorList.HasCriticals;
        public bool HasWarnings =>
            ErrorEntity != null && ErrorEntity.ErrorList.HasWarnings;
        public bool HasInformations => 
            ErrorEntity != null && ErrorEntity.ErrorList.HasInformations;

        public IEnumerable Errors()
        {
            if (ErrorEntity?.ErrorList.Criticals == null) return null;

            var notifications = (from error in ErrorEntity?.ErrorList.Criticals
                                 select $"Description: {error.Message} | " +
                                        $"Level: {error.Level.Description} | " +
                                        $"Field: {error.FieldName}").ToList();

            return notifications;
        }

        public IEnumerable Warnings()
        {
            if (ErrorEntity?.ErrorList.Warnings == null) return null;

            var notifications = (from error in ErrorEntity?.ErrorList.Warnings
                                 select $"Description: {error.Message} | " +
                                        $"Level: {error.Level.Description} | " +
                                        $"Field: {error.FieldName}").ToList();

            return notifications;
        }

        public IEnumerable Informations()
        {
            if (ErrorEntity?.ErrorList.Informations == null) return null;

            var notifications = (from error in ErrorEntity?.ErrorList.Informations
                                 select $"Description: {error.Message} | " +
                                        $"Level: {error.Level.Description} | " +
                                        $"Field: {error.FieldName}").ToList();

            return notifications;
        }
    }
}