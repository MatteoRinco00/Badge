using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Badge.EF.Entity
{
    [Table("People")]//Nome della Tabella nel Database
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPerson { get; set; }

        public string Nome { get; set; }
        public string Cognome { get; set; }

        public List<Badge> Badge { get; set; } = new List<Badge>();

        public Person()
        {

        }
    }
}
