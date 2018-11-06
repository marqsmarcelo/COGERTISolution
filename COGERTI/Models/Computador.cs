using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace COGERTI.Models
{
    [Table("Computadores")]
    public partial class Computador : Equipamento
    {
        [Display(Name = "Tipo Computador")]
        public int TipoComputadorId { get; set; }
    
        public virtual TipoComputador TipoComputador { get; set; }
    }
}
