using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Badge.Web.Models.Badges
{
    public class BadgesViewModel
    {
        [Key]
        public string NomeBadge { get; set; }

        public int IdPerson { get; set; }

    }
}
    

