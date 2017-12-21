using System;

namespace DesignByContract.Prompt.Dto
{
    public class PersonDto
    {
        public PersonDto(Guid personId,
                         string name, 
                         string email, 
                         Guid categoryId, 
                         Guid managerId)
        {
            PersonId = personId;
            Name = name;
            Email = email;
            CategoryId = categoryId;
            ManagerId = managerId;
        }

        public Guid PersonId { get; }
        public string Name { get; }
        public string Email { get; }
        public Guid CategoryId { get; }
        public Guid ManagerId { get; }
    }
}