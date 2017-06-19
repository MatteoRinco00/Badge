using Badge.EF.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Badge.Practise.Test
{
    public class PopulateBadge
    {
        public EF.Entity.Badge Populate(Person p, string nomeBadge)
        {
            EF.Entity.Badge badge = new EF.Entity.Badge();
            badge.NomeBadge = nomeBadge;

            badge.Person = p;
            return badge;
        }
    }
}
