using System;
using DesignByContract.Domain.Entities;
using DesignByContract.Domain.ValueObjects;

namespace DesignByContract.Prompt
{
    internal class Program
    {
        private static void Main()
        {
            var validPerson = new Person(Guid.NewGuid(),
                                         new PersonName("Tiago Pariz"),
                                         new Email("tiagopariz@gmail.com"),
                                         new Category(Guid.NewGuid(), "Cliente"),
                                         true);

            var invalidPerson = new Person(Guid.NewGuid(),
                                           new PersonName("", true),
                                           new Email("dfsjdlskfjl"),
                                           new Category(Guid.NewGuid(), "", true),
                                           true);

            Console.WriteLine(":: INVALID ::");
            Console.ForegroundColor = ConsoleColor.Red;

            foreach (var error in invalidPerson.Notification.Errors)
            {
                Console.WriteLine(error.ToString());    
            }

            Console.ReadKey();
        }
    }
}