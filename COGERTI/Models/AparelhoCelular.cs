using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace COGERTI.Models
{   
    [Table("AparelhosCelulares")]
    public partial class AparelhoCelular : Equipamento
    {
        [Required]
        public string IMEI1 { get; set; }
        public string IMEI2 { get; set; }

        [Display(Name = "Tipo Aparelho")]
        public int TipoAparelhoCelularId { get; set; }
    
        public virtual TipoAparelhoCelular TipoAparelhoCelular { get; set; }
    }
}
