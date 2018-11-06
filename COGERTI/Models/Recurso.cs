using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace COGERTI.Models
{
    [Table("Recursos")]
    public abstract partial class Recurso
    {
        /*[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Recurso()
        {
            this.Funcionario = new HashSet<Funcionario>();
        }*/
    
        public int Id { get; set; }

        [Display(Name = "Planta")]
        public int LocalSiteId { get; set; }

        [Display(Name = "Funcion�rio")]
        public int? FuncionarioUPI { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data da Associa��o")]
        public System.DateTime DataAssociacao { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data da Libera��o")]
        public Nullable<System.DateTime> DataLiberacao { get; set; }

        [Display(Name = "Motivo da Libera��o")]
        public string MotivoLiberacao { get; set; }

        [Display(Name = "Termo de Responsabilidade")]
        public string TermoResponsabilidade { get; set; }

        [Display(Name = "Planta")]
        public virtual LocalSite LocalSite { get; set; }

        [Display(Name = "Funcion�rio")]
        [ForeignKey("FuncionarioUPI")]
        public virtual Funcionario Funcionario { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Funcionario> Funcionario { get; set; }
    }
}
