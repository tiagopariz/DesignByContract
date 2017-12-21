using DesignByContract.Domain.Core.Commands;
using DesignByContract.Domain.Core.Errors;
using DesignByContract.Domain.Entities;

namespace DesignByContract.Domain.Commands
{
    public class SavePerson : Command
    {
        private readonly Person _person;

        public SavePerson(Person person)
            : base(person)
        {
            _person = person;
            var newPersonOnMemory = new ErrorDescription("New person instance create on memory.", new Warning(), "Person");
            _person.Notification.Add(newPersonOnMemory);
        }

        public void Run()
        {
            if (!_person.Notification.HasErrors)
            {
                SavePersonInBackendSystems();
            }
            else
            {
                var error = new ErrorDescription("Registration not saved.", new Critical(), "Person");
                _person.Notification.Add(error);
            }
        }

        private void SavePersonInBackendSystems()
        {
            var message = new ErrorDescription("Registration succeeded.", new Information(), "Person");
            _person.Notification.Add(message);
        }
    }
}