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

 
            BadgeContext db = new BadgeContext("Server=(localdb)\\mssqllocaldb;Database=Badge;Trusted_Connection=True;MultipleActiveResultSets=true");
            BadgeContextInitializer.Initialize(db);

            PopulatePerson p = new PopulatePerson();
            string nome1 = "Matteo";
            string nome2 = "Antonio";
            string cognome1 = "Rinco";
            string cognome2 = "Rossi";
            Person persona1 = p.Populate(nome1,cognome1);
            Person persona2 = p.Populate(nome2, cognome2);
            Console.WriteLine(persona1);
            db.People.Add(persona1);
            db.People.Add(persona2);
            db.SaveChanges();

            PopulateMachine m = new PopulateMachine();
            string IpMachine1 = "172.168.0.1";
            string IpMachine2 = "172.168.0.2";
            string MacAddress1 = "DD-5A-38-A2-D3-27";
            string MacAddress2 = "DF-7B-7A-22-A2-60";
            Machine machine1 = m.Populate(IpMachine1, MacAddress1);
            Machine machine2 = m.Populate(IpMachine2, MacAddress2);
            Console.WriteLine(machine1);
            db.Machines.Add(machine1);
            db.Machines.Add(machine2);
            db.SaveChanges();


            PopulateBadge b = new PopulateBadge();
            string nomeBadge1 = "Mtor01";
            string nomeBadge2 = "Mtor02";
            string nomeBadge3 = "AtonRsi01";
            EF.Entity.Badge badge1 = b.Populate(persona1, nomeBadge1);
            EF.Entity.Badge badge2 = b.Populate(persona1, nomeBadge2);
            EF.Entity.Badge badge3 = b.Populate(persona2, nomeBadge3);
            Console.WriteLine(badge1.ToString());
            db.Badges.Add(badge1);
            db.Badges.Add(badge2);
            db.Badges.Add(badge3);
            db.SaveChanges();

            PopulateSwipe s = new PopulateSwipe();
            DateTime orario = DateTime.Now;
            string pospersona = "Villafranca";
            Swipe swipe1 = s.Populate(orario,badge1,pospersona,machine1);
            Swipe swipe2 = s.Populate(orario, badge1, pospersona, machine1);
            Swipe swipe3 = s.Populate(orario, badge1, pospersona, machine2);
            Swipe swipe4 = s.Populate(orario, badge2, pospersona, machine2);
            Swipe swipe5 = s.Populate(orario, badge2, pospersona, machine2);
            Swipe swipe6 = s.Populate(orario, badge3, pospersona, machine2);
            Swipe swipe7 = s.Populate(orario, badge3, pospersona, machine1);
            db.Swipe.Add(swipe1);
            db.Swipe.Add(swipe2);
            db.Swipe.Add(swipe3);
            db.Swipe.Add(swipe4);
            db.Swipe.Add(swipe5);
            db.Swipe.Add(swipe6);
            db.Swipe.Add(swipe7);
            db.SaveChanges();

            
            Console.ReadKey();

        }
    }
}