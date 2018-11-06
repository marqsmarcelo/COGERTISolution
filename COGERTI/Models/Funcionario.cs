using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace COGERTI.Models
{
    [Table("Funcionarios")]
    public partial class Funcionario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Funcionario()
        {
            this.CoordenadorCC = new HashSet<CentroDeCusto>();
            this.Recurso = new HashSet<Recurso>();
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

        [Display(Name = "Planta")]
        public virtual LocalSite LocalSite { get; set; }
        [Display(Name = "Status Funcion�rio")]
        public virtual StatusFuncionario StatusFuncionario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Recurso> Recurso { get; set; }
        [Display(Name = "Centro de Custo")]
        public virtual CentroDeCusto CentroDeCusto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CentroDeCusto> CoordenadorCC { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CentroDeCusto> GestorCC { get; set; }
    }
}
