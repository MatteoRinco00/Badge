using System;
using System.Collections.Generic;
using System.Text;

namespace Badge.EF.Entity
{
    public class Person
    {
        public string nomecognome = "";
        public void nome()
        {
            Console.WriteLine("Inserisci il nome della persona ");
            string nomecognome = Console.ReadLine();
        }
        
    }
}
