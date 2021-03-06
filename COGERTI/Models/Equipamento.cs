using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace COGERTI.Models
{
    [Table("Equipamentos")]
    public abstract partial class Equipamento : Recurso
    {
        [Display(Name = "Serial No")]
        [Required]
        public string SerialNo { get; set; }

        [Display(Name = "Patrimônio")]
        [StringLength(6, MinimumLength = 4, ErrorMessage = "O patrimônio deve ter entre 4 e 6 caractéres.")]
        public String Patrimonio { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data da Fabricação")]
        public Nullable<System.DateTime> DataFabricacao { get; set; }

        [Required]
        public string Marca { get; set; }
        [Required]
        public string Modelo { get; set; }
        [Display(Name = "Propriedade")]
        public int PropriedadeId { get; set; }
        [Display(Name = "Status do Equipamento")]
        public int StatusEquipamentoId { get; set; }
    
        public virtual StatusEquipamento StatusEquipamento { get; set; }
        public virtual PropriedadeEquipamento Propriedade { get; set; }
    }
}
