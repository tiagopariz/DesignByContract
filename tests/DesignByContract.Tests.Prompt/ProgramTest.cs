using DesignByContract.Application.Services.Entities;
using DesignByContract.Prompt;
using DesignByContract.Prompt.Dto;
using NUnit.Framework;
using System;

namespace DesignByContract.Tests.Prompt
{
    [TestFixture]
    public class ProgramTest
    {
        [Test]
        public void ProgramSubmitWhenValidPersonService()
        {
            var personDto = new PersonDto(Guid.NewGuid(),
                                          "Tiago Pariz",
                                          "tiagopariz@gmail.com",
                                          Guid.NewGuid(),
                                          Guid.NewGuid());

            var personService = new PersonService(personDto.PersonId,
                                                  personDto.Name,
                                                  personDto.Email,
                                                  personDto.CategoryId,
                                                  personDto.ManagerId);

            Program.Submit(personService, personDto);

            Assert.AreEqual(personService.HasCriticals, false);
        }
    }
}