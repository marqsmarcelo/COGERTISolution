using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace COGERTI.Models
{
    [Table("CodigosDdd")]
    public partial class CodigoDdd
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CodigoDdd()
        {
            this.LinhaMovel = new HashSet<LinhaMovel>();
        }
    
        public int Id { get; set; }
        [Display(Name = "Código do DDD")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O DDD é composto por 2 números.")]
        public string DddCodigo { get; set; }
        [StringLength(2, MinimumLength = 2, ErrorMessage = "A Unidade Federativa é composta por duas letras.")]
        public String UF { get; set; }
        [Display(Name = "Região")]
        public String Regiao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LinhaMovel> LinhaMovel { get; set; }
    }
}
