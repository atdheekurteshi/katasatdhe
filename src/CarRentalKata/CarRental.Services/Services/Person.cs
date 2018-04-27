using System;

namespace CarRental.Services
{
    public class Person : Calculate
    {
        public Person()
        {
            var calcualte = new Calculate();
            Console.WriteLine(calcualte.Calcualte());
        }
    }
}