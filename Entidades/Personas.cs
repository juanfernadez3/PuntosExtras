using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PuntosExtras.Entidades
{
    public class Personas
    {
        [Key]
        public int PersonaId { get; set; }
        public string  Nombre { get; set; }
    }
}
