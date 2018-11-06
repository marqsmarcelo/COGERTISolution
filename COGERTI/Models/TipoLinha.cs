using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace COGERTI.Models
{

    [Table("TiposLinhas")]
    public partial class TipoLinha
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoLinha()
        {
            this.LinhaMovel = new HashSet<LinhaMovel>();
        }
    
        public int Id { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LinhaMovel> LinhaMovel { get; set; }
    }
}
