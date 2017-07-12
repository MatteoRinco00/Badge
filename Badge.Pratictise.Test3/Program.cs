using System.Text;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Badge.EF.Entity;
using Badge.EF;

namespace Badge.Practise.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            DbContextOptionsBuilder<BadgeContext> option = new DbContextOptionsBuilder<BadgeContext>(new DbContextOptions<BadgeContext>());
            option.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Badge;Trusted_Connection=True;MultipleActiveResultSets=true");
            BadgeContext db = new BadgeContext(option.Options);
            BadgeContextInitializer.Initialize(db);

            PopulatePerson p = new PopulatePerson();
            string nome1 = "Matteo";
            string professione1 = "Sviluppatore";
            string professione2 = "Sistemista";
            string professione3 = "Elettronico";
            string professione4 = "Elettricita";
            string nome2 = "Antonio";
            string cognome1 = "Rinco";
            string cognome2 = "Rossi";
            byte[] vettore = { 144, 86, 10, 133, 73 };
            byte[] vettore1 = { 0, 1, 2, 3, 4 };
            Person persona1 = p.Populate(nome1,cognome1,professione1);
            Person persona2 = p.Populate(nome2, cognome2, professione2);
            Person persona3 = p.Populate(nome1, cognome1, professione3);
            Person persona4 = p.Populate(nome2, cognome2, professione4);
            Person persona5 = p.Populate(nome1, cognome1, professione2);
            Person persona6 = p.Populate(nome2, cognome2, professione1);
            Person persona7 = p.Populate(nome1, cognome1, professione1);
            Person persona8 = p.Populate(nome2, cognome2, professione3);
            Person persona9 = p.Populate(nome1, cognome1, professione1);
            Person persona10 = p.Populate(nome2, cognome2, professione4);
            Person persona11 = p.Populate(nome1, cognome1, professione2);
            Person persona12 = p.Populate(nome2, cognome2, professione1);
            Console.WriteLine(persona1);
            db.People.Add(persona1);
            db.People.Add(persona2);
            db.People.Add(persona3);
            db.People.Add(persona4);
            db.People.Add(persona5);
            db.People.Add(persona6);
            db.People.Add(persona7);
            db.People.Add(persona8);
            db.People.Add(persona9);
            db.People.Add(persona10);
            db.People.Add(persona11);
            db.SaveChanges();

            PopulateMachine m = new PopulateMachine();
            string IpMachine1 = "172.168.0.1";
            string IpMachine2 = "172.168.0.2";
            string MacAddress1 = "DD-5A-38-A2-D3-27";
            string MacAddress2 = "DF-7B-7A-22-A2-60";
            Machine machine1 = m.Populate(IpMachine1, MacAddress1);
            Machine machine2 = m.Populate(IpMachine2, MacAddress2);
            Machine machine3 = m.Populate(IpMachine1, MacAddress1);
            Machine machine4 = m.Populate(IpMachine2, MacAddress2);
            Machine machine5 = m.Populate(IpMachine1, MacAddress1);
            Machine machine6 = m.Populate(IpMachine2, MacAddress2);
            Machine machine7 = m.Populate(IpMachine1, MacAddress1);
            Machine machine8 = m.Populate(IpMachine2, MacAddress2);
            Machine machine9 = m.Populate(IpMachine1, MacAddress1);
            Machine machine10 = m.Populate(IpMachine2, MacAddress2);
            Machine machine11 = m.Populate(IpMachine1, MacAddress1);
            Machine machine12 = m.Populate(IpMachine2, MacAddress2);
            Machine machine13 = m.Populate(IpMachine1, MacAddress1);
            Machine machine14 = m.Populate(IpMachine2, MacAddress2);
            Machine machine15 = m.Populate(IpMachine1, MacAddress1);
            Machine machine16 = m.Populate(IpMachine2, MacAddress2);
            Machine machine17 = m.Populate(IpMachine1, MacAddress1);
            Machine machine18 = m.Populate(IpMachine2, MacAddress2);
            Console.WriteLine(machine1);
            db.Machines.Add(machine1);
            db.Machines.Add(machine2);
            db.Machines.Add(machine3);
            db.Machines.Add(machine4);
            db.Machines.Add(machine5);
            db.Machines.Add(machine6);
            db.Machines.Add(machine7);
            db.Machines.Add(machine8);
            db.Machines.Add(machine9);
            db.Machines.Add(machine10);
            db.Machines.Add(machine11);
            db.Machines.Add(machine12);
            db.Machines.Add(machine13);
            db.Machines.Add(machine14);
            db.Machines.Add(machine15);
            db.Machines.Add(machine16);
            db.Machines.Add(machine17);
            db.Machines.Add(machine18);        
            db.SaveChanges();

            PopulateBadge b = new PopulateBadge();
            string nomeBadge1 = "Mtor01";
            string nomeBadge2 = "Mtor02";
            string nomeBadge3 = "AtonRsi01";
            EF.Entity.PopulateBadge badge1 = b.Populate(persona1, nomeBadge1, vettore);
            EF.Entity.PopulateBadge badge2 = b.Populate(persona1, nomeBadge2, vettore1);
            EF.Entity.PopulateBadge badge3 = b.Populate(persona2, nomeBadge3, vettore1);
            Console.WriteLine(badge1.ToString());
            PopulateBadge id = new PopulateBadge();
            id.idperson.Add(persona1.IdPerson);
            id.idperson.Add(persona1.IdPerson);
            id.idperson.Add(persona2.IdPerson);
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
            Swipe swipe8 = s.Populate(orario, badge3, pospersona, machine1);
            Swipe swipe9 = s.Populate(orario, badge1, pospersona, machine1);
            db.Swipe.Add(swipe1);
            db.Swipe.Add(swipe2);
            db.Swipe.Add(swipe3);
            db.Swipe.Add(swipe4);
            db.Swipe.Add(swipe5);
            db.Swipe.Add(swipe6);
            db.Swipe.Add(swipe7);
            db.Swipe.Add(swipe8);
            db.Swipe.Add(swipe9);
            db.SaveChanges();

            Console.ReadKey();
        }
    }
}