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
                                         true);

            var invalidPerson = new Person(Guid.NewGuid(),
                                           new PersonName("", true),
                                           new Email("dfsjdlskfjl"),
                                           true);

            Console.WriteLine("Pausa");
        }
    }
}