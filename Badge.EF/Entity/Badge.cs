using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Badge.EF.Entity
{
    [Table("Badge")]//Nome della Tabella nel Database
    public class Badge
    {
        [Key]
        public string NomeBadge { get; set; }

        public List<Swipe> Swipes { get; set; } = new List<Swipe>();

        public int IdPerson { get; set; }
        [ForeignKey("IdPerson")]
        public Person Person { get; set; }

        public override string ToString()
        {
            return $"NomeBadge: {NomeBadge}";
        }
    }
}
