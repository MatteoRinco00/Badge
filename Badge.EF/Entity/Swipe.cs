using System;
using System.Collections.Generic;
using System.Text;

namespace Badge.EF.Entity
{
    public class Swipe
    {
        public string idpersona = "";
        public string pospersona = "";
        public string orario = "";
        public string numeroswipe = "";

        public void infoswipe()
        {
            Console.WriteLine("Inserisci Id della persona ");
            string idpersona = Console.ReadLine();
            Console.WriteLine("Inserisci la posizione dello swipe hdella persona ");
            string pospersona = Console.ReadLine();
            Console.WriteLine("Inserisci l'orario dello swipe");
            string orario = Console.ReadLine();
            Console.WriteLine("Inserisci il numero di swipe della persona ");
            string numeroswipe = Console.ReadLine();

        }

        
    }
}
