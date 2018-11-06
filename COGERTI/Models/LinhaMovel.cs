using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace COGERTI.Models
{
    [Table("LinhaMovel")]
    public partial class LinhaMovel : Recurso
    {
        [Display(Name = "Linha No")]
        public string LinhaNo { get; set; }
        [Display(Name = "ID do Chip")]
        public string ChipId { get; set; }
        [Display(Name = "Código DDD")]
        public int CodigoDddId { get; set; }
        [Display(Name = "Tipo da Linha")]
        public int TipoLinhaId { get; set; }
        [Display(Name = "Plano Celular")]
        public int TipoPlanoMovelId { get; set; }
        [Display(Name = "Status da Linha")]
        public int StatusLinhaId { get; set; }

        public virtual StatusLinha StatusLinha { get; set; }
        public virtual CodigoDdd CodigoDdd { get; set; }
        public virtual TipoLinha TipoLinha { get; set; }
        public virtual TipoPlanoMovel TipoPlanoMovel { get; set; }
    }
}
