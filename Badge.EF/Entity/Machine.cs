using System;
using System.Collections.Generic;
using System.Text;

namespace Badge.EF.Entity
{
    public class Machine
    {
        public string ipmachine = "";
        public string macaddress = "";
        public string nmachine = ""; 

        public void infomachine()
        {
            Console.WriteLine("Inserisci ip della machine ");
            string ipmachine = Console.ReadLine();
            Console.WriteLine("Inserisci macaddress della machine ");
            string macaddress = Console.ReadLine();
            Console.WriteLine("Inserisci il numero di machine");
            string nmachine = Console.ReadLine();
        }

    }
}
