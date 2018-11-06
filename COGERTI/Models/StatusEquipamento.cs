using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace COGERTI.Models
{
    [Table("StatusEquipamentos")]
    public partial class StatusEquipamento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StatusEquipamento()
        {
            this.Equipamento = new HashSet<Equipamento>();
        }
    
        public int Id { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Equipamento> Equipamento { get; set; }
    }
}
