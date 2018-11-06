using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COGERTI.Models
{
    [Table("PropriedadeEquipamentos")]
    public partial class PropriedadeEquipamento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PropriedadeEquipamento()
        {
            this.Equipamento = new HashSet<Equipamento>();
        }
    
        public int Id { get; set; }
        public string Lote { get; set; }
        [Display(Name = "Pedido SAP No")]
        public string PedidoSapNo { get; set; }
        [Display(Name = "Contrato No")]
        public string ContratoNo { get; set; }
        [Display(Name = "Data da Compra")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> DataCompra { get; set; }
        [Display(Name = "Data do Recebimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> DataRecebimento { get; set; }
        [Display(Name = "Data do Término da Garantia")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> DataTerminoGarantia { get; set; }
        [Display(Name = "Tipo de Propriedade")]
        public TipoPropriedade TipoPropriedade { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Equipamento> Equipamento { get; set; }
    }

    public enum TipoPropriedade
    {
        Compra,
        Leasing,
        Comodato
    }
}
