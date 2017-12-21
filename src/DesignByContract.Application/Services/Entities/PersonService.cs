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
            var category = new Category(categoryId, "Especial"); // TODO: Criar serviço que verifica se a categoria existe
            var manager = new Person(managerId, new PersonName(name), new Email(email), category); // TODO: Criar serviço que verifica o gerente

            _entity = new Person(personId, new PersonName(name), new Email(email), category, manager);
            NotificationEntity = _entity;
        }

        public void SavePerson(Guid personId, string name)
        {
            var cmd = new SavePerson(_entity);
            cmd.Run();
        }
    }
}