//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace COGERTI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Funcionarios")]
    public partial class Funcionario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Funcionario()
        {
            this.CoordenadorCC = new HashSet<CentroDeCusto>();
            this.AssociacaoRecurso = new HashSet<AssociacaoRecurso>();
            this.GestorCC = new HashSet<CentroDeCusto>();
        }

        [Key]
        public int UPI { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        [Display(Name = "Usu�rio GAD")]
        public string UsuarioGad { get; set; }
        [Display(Name = "Planta")]
        public int LocalSiteId { get; set; }
        [Display(Name = "Status do Funcion�rio")]
        public int StatusFuncionarioId { get; set; }
        [Display(Name = "Centro de Custo")]
        public int CentroDeCustoId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CentroDeCusto> CoordenadorCC { get; set; }
        public virtual LocalSite LocalSite { get; set; }
        public virtual StatusFuncionario StatusFuncionario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssociacaoRecurso> AssociacaoRecurso { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CentroDeCusto> GestorCC { get; set; }
        public virtual CentroDeCusto CentroDeCusto { get; set; }
    }
}