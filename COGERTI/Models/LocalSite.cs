using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COGERTI.Models
{
    [Table("LocalSites")]
    public partial class LocalSite
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LocalSite()
        {
            this.Funcionario = new HashSet<Funcionario>();
            this.Recurso = new HashSet<Recurso>();
        }
    
        public int Id { get; set; }
        public string Nome { get; set; }
        [MaxLength(10), MinLength(3)]
        public string Sigla { get; set; }
        [MaxLength(2), MinLength(2)]
        public string UF { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Funcionario> Funcionario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Recurso> Recurso { get; set; }
    }
}
