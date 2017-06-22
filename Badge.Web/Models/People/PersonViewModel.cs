using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Badge.Web.Models.People
{
    public class PeopleViewModel
    {
        [Key]
        public int IdPerson { get; set; }

        [StringLength(250)]
        [DataType(DataType.Text)]
        [Display(Name = "Nome di battesimo")]
        public string Nome { get; set; }

        [StringLength(250)]
        public string Cognome { get; set; } 
        public bool CanDelete { get; set; }
    }
}
