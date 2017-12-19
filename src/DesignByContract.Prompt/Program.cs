using System;
using DesignByContract.Domain.ValueObjects;

namespace DesignByContract.Prompt
{
    internal class Program
    {
        private static void Main()
        {
            var validName = new PersonName("Tiago Pariz");
            var invalidName = new PersonName("tiagopariz_gmail.comtiagopariz_gmail.comtiagopariz_gmail.comtiagopariz_gmail.comtiagopariz_gmail.comtiagopariz_gmail.comtiagopariz_gmail.com" +
                                         "tiagopariz_gmail.comtiagopariz_gmail.comtiagopariz_gmail.comtiagopariz_gmail.comtiagopariz_gmail.comtiagopariz_gmail.comtiagopariz_gmail.com");

            Console.WriteLine("Pausa");
        }
    }
}