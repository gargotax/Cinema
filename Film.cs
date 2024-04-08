using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    public class Film
    {
        [Key]
        public int FilmId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        // Chiave esterna per la relazione con la tabella Salle
        [ForeignKey("Salle")]
        public int SalleId { get; set; }
        [ForeignKey("Realisateur")]
        public int IdRealisateur { get; set; }
        public string Realisateur { get; set; }

        // Proprietà di navigazione
        [ForeignKey("SalleId")]
        public Salle SalleNavigation { get; set; }
        public virtual Film FilmNavigation { get; set; }
        public virtual Realisateur RealisateurNavigation { get; set; }

    }

}
