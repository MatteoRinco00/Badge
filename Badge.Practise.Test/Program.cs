using Badge.EF.Entity;
using System.Text;
using System;
using System.Collections.Generic;
using Badge.EF;
using Microsoft.EntityFrameworkCore;

namespace Badge.Practise.Test
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Machine machinepersona1 = new Machine()
            {
                IpMachine="172.168.0.1",
                MacAddress="00-E0-18-56-25"
            };
            Machine machinepersona2 = new Machine()
            {
                IpMachine = "172.168.0.2",
                MacAddress = "F3-E0-19-5A-87"
            };

            Swipe swipepersona1 = new Swipe()
            {
                Orario= "16.30",
                PosPersona = "Villafranca"

            };
            Swipe swipepersona2 = new Swipe()
            {
                Orario = "16.30",
                PosPersona = "Villafranca"

            };
            Swipe swipepersona3 = new Swipe()
            {
                Orario = "16.30",
                PosPersona = "Villafranca"

            };

            swipepersona1.Machine = machinepersona1;
            swipepersona2.Machine = machinepersona1;
            swipepersona3.Machine = machinepersona2;


            Person persona1 = new Person()
            {
                Nome = "Matteo",
                Cognome = "Rinco"                
            };

            
            persona1.Swipes.Add(swipepersona1);
            persona1.Swipes.Add(swipepersona2);

            Person persona2 = new Person()
            {
                Nome = "Matilde",
                Cognome = "Rinco"
            };
            persona2.Swipes.Add(swipepersona3);



            BadgeContext db = new BadgeContext("Server=(localdb)\\mssqllocaldb;Database=Badge;Trusted_Connection=True;MultipleActiveResultSets=true");
            BadgeContextInitializer.Initialize(db);

            db.Machines.Add(machinepersona1);
            db.Machines.Add(machinepersona2);
            db.Swipe.Add(swipepersona1);
            db.Swipe.Add(swipepersona2);
            db.Swipe.Add(swipepersona3);
            db.People.Add(persona1);
            db.People.Add(persona2);
            db.SaveChanges();
            Console.ReadKey();

        }
    }
}