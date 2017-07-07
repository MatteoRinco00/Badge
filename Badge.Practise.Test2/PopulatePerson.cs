using Badge.EF.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Badge.Practise.Test
{
    public class PopulatePerson
    {
        public Person Populate(string nome, string cognome, string professione, byte[] vettore)
        {
            Person p = new Person();
            p.Nome = nome;
            p.Cognome = cognome;
            p.Professione = professione;
            p.Array = vettore;

            // TODO: NO
            // p.Badge
            return p;
        }
    }
}
