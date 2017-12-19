using System;
using DesignByContract.Domain.ValueObjects;

namespace DesignByContract.Prompt
{
    internal class Program
    {
        private static void Main()
        {
            var validEmail = new Email("tiagopariz@gmail.com");
            var invalidEmail = new Email("tiagopariz_gmail.comtiagopariz_gmail.comtiagopariz_gmail.comtiagopariz_gmail.comtiagopariz_gmail.comtiagopariz_gmail.comtiagopariz_gmail.com" +
                                         "tiagopariz_gmail.comtiagopariz_gmail.comtiagopariz_gmail.comtiagopariz_gmail.comtiagopariz_gmail.comtiagopariz_gmail.comtiagopariz_gmail.com");

            Console.WriteLine("Pausa");
        }
    }
}