using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace COGERTI.Models
{
    [Table("CentrosDeCustos")]
    public partial class CentroDeCusto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CentroDeCusto()
        {
            this.Funcionario = new HashSet<Funcionario>();
        }
        
        public int Id { get; set; }

        [Display(Name = "Centro de Custo", Prompt = "Entre com o nome do Centro de Custo.")]
        public string Nome { get; set; }

        [Display(Name = "Coordenador")]
        public Nullable<int> CoordenadorUPI { get; set; }
        [Display(Name = "Gestor")]
        public Nullable<int> GestorUPI { get; set; }

        [Display(Name = "Coordenador")]
        [ForeignKey("CoordenadorUPI")]
        public virtual Funcionario CoordenadorCC { get; set; }
        [Display(Name = "Gestor")]
        [ForeignKey("GestorUPI")]
        public virtual Funcionario GestorCC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Funcionario> Funcionario { get; set; }
    }
}
