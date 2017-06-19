using Badge.EF.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Badge.Practise.Test
{
    public class PopulatePerson
    {
        public Person Populate(string nome, string cognome)
        {
            Person p = new Person();
            p.Nome = nome;
            p.Cognome = cognome;

            // TODO: NO
            // p.Badge
            return p;
        }
    }
}
