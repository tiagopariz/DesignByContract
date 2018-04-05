using DesignByContract.Application.Services.Entities;
using DesignByContract.Core.Application.Services;
using DesignByContract.Prompt.Dto;
using System;

namespace DesignByContract.Prompt
{
    public static class Program
    {
        private static void Main()
        {
            Console.WriteLine("Type your name");
            var name = Console.ReadLine();
            Console.WriteLine("Type your E-Mail");
            var email = Console.ReadLine();

            var personDto = new PersonDto(Guid.NewGuid(),
                                          name,
                                          email,
                                          Guid.NewGuid(),
                                          Guid.NewGuid());

            var personService = new PersonService(personDto.PersonId,
                                                  personDto.Name,
                                                  personDto.Email,
                                                  personDto.CategoryId,
                                                  personDto.ManagerId);

            Submit(personService, personDto);
            Console.ReadKey();
        }

        public static void Submit(PersonService personService,
                                  PersonDto personDto)
        {
            personService.SavePerson(personDto.PersonId,
                personDto.Name);

            if (personService.HasErrors)
                ShowErrorList(personService);
        }

        private static void ShowErrorList(Service personService)
        {
            if (!personService.HasErrors) return;

            Console.WriteLine("\nError list\n");

            if (personService.HasCriticals)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nCriticals\n");

                foreach (var error in personService.Errors())
                {
                    Console.WriteLine(error.ToString());
                }
            }

            if (personService.HasWarnings)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nWarnings\n");

                foreach (var error in personService.Warnings())
                {
                    Console.WriteLine(error.ToString());
                }
            }

            if (personService.HasInformations)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nInformations\n");

                foreach (var error in personService.Informations())
                {
                    Console.WriteLine(error.ToString());
                }
            }
        }
    }
}