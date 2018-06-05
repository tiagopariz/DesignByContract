using DesignByContract.Core.Application.Services;
using DesignByContract.Domain.Commands;
using DesignByContract.Domain.Entities;
using DesignByContract.Domain.ValueObjects;
using System;

namespace DesignByContract.Application.Services.Entities
{
    public class PersonService : Service
    {
        private readonly Person _entity;

        public PersonService(Guid personId,
                             string name,
                             string email,
                             Guid categoryId,
                             Guid managerId)
        {
            // TODO: Criar serviço de categoria
            var category = new Category(categoryId, "Especial");
            // TODO: Criar serviço de gerente
            var manager = new Person(managerId,
                                     new PersonName("chefe"),
                                     new Email("chefe@aquelequetudopode.eu"),
                                     new Category(Guid.NewGuid(),
                                                  "Manager"));

            _entity = new Person(personId,
                                 new PersonName(name),
                                 new Email(email),
                                 category,
                                 manager);

            ErrorEntity = _entity;
        }

        public void SavePerson(Guid personId, string name)
        {
            var cmd = new SavePerson(_entity);
            cmd.Run();
        }
    }
}