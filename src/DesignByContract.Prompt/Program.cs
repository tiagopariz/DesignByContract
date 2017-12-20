using System;
using DesignByContract.Domain.Entities;
using DesignByContract.Domain.ValueObjects;

namespace DesignByContract.Prompt
{
    internal class Program
    {
        private static void Main()
        {
            //var validPerson = new Person(Guid.NewGuid(),
            //                             new PersonName("Tiago Pariz"),
            //                             new Email("tiagopariz@gmail.com"),
            //                             new Category(Guid.NewGuid(), "Gerente"));

            //var invalidPerson = new Person(Guid.NewGuid(),
            //                               new PersonName(""),
            //                               new Email("dfsjdlskfjl"),
            //                               new Category(Guid.NewGuid(), "Cliente"),
            //                               validPerson);

            var nullPerson = new Person(Guid.Empty,
                                        null,
                                        null,
                                        null);

            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine(":: INVALID ::");

            //foreach (var error in invalidPerson.Notification.Errors)
            //{
            //    Console.WriteLine(error.Message + " | " + error.FieldName);
            //}

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n:: NULL ::");

            foreach (var error in nullPerson.Notification.Errors)
            {
                Console.WriteLine(error.Message + " | " + error.FieldName);
            }

            Console.ReadKey();
        }
    }
}