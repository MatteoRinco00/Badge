using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Badge.EF.Entity
{
    [Table("Swipes")]//Nome della Tabella nel Database 
    public class Swipe
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSwipe { get; set; }
        
        public string PosPersona { get; set; }
        public DateTime Orario { get; set; }

        public string MachineName { get; set; }
        [ForeignKey("MachineName")]
        public Machine Machine { get; set; }

        public string NomeBadge { get; set; }
        [ForeignKey("NomeBadge")]
        public Badge Badge { get; set; }
        
    }
}
