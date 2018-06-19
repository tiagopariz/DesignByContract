using DesignByContract.Core.Domain.Commands;
using DesignByContract.Core.Domain.Errors;
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
            var errorDescription =
                new ErrorItemDetail("New person instance create on memory.",
                                    new Warning(),
                                    "Person");
            _person.ErrorList.Add(errorDescription);
        }

        public void Run()
        {
            if (!_person.ErrorList.HasCriticals())
            {
                SavePersonInBackendSystems();
            }
            else
            {
                var errorDescription =
                    new ErrorItemDetail("Registration not saved.",
                                        new Critical(),
                                        "Person");
                _person.ErrorList.Add(errorDescription);
            }
        }

        private void SavePersonInBackendSystems()
        {
            var errorDescription =
                new ErrorItemDetail("Registration succeeded.",
                                    new Information(),
                                    "Person");
            _person.ErrorList.Add(errorDescription);
        }
    }
}