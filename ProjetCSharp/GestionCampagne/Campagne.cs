using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetCSharp.GestionCampagne
{
    [Table("Campagne")]
    public class Campagne
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // proprietés campagne
        [Column("Id")]
        public long Id { get; set; }

        [Column("NomCampagne")]
        public string NomCampagne { get; set; }

    }
}
