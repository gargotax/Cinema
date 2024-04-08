using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    public class Realisateur
    {
        public int IdRealisateur {  get; set; }
        public string Name { get; set; }

        public ICollection<Film> FilmsRealises { get; set; }

    }
}
