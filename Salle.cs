﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    public class Salle
    {
        [Key]
        public int SalleId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        [InverseProperty("Salle")]
        public List<Film> Films { get; set; }

    }
}