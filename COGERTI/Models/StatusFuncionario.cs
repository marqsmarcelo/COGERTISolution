using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace COGERTI.Models
{
    [Table("StatusFuncionarios")]
    public partial class StatusFuncionario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StatusFuncionario()
        {
            this.Funcionario = new HashSet<Funcionario>();
        }
    
        public int Id { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Funcionario> Funcionario { get; set; }
    }
}
