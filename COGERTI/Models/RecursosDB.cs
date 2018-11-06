using System.Data.Entity.Infrastructure;

namespace COGERTI.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class RecursosDB : DbContext
    {
        public RecursosDB()
            : base("name=RecursosDB")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<CentroDeCusto> CentrosDeCustos { get; set; }
        public DbSet<Recurso> Recursos { get; set; }
        public DbSet<LocalSite> LocalSites { get; set; }
        public DbSet<StatusFuncionario> StatusFuncionarios { get; set; }
        public DbSet<StatusEquipamento> StatusEquipamentos { get; set; }
        public DbSet<StatusLinha> StatusLinhas { get; set; }
        public DbSet<TipoComputador> TiposComputadores { get; set; }
        public DbSet<PropriedadeEquipamento> PropriedadeEquipamentos { get; set; }
        public DbSet<TipoAparelhoCelular> TiposAparelhosCelulares { get; set; }
        public DbSet<CodigoDdd> CodigosDdd { get; set; }
        public DbSet<TipoLinha> TiposLinhas { get; set; }
        public DbSet<TipoPlanoMovel> TiposPlanosMoveis { get; set; }

        public System.Data.Entity.DbSet<COGERTI.Models.Computador> Computadores { get; set; }

        public System.Data.Entity.DbSet<COGERTI.Models.AparelhoCelular> AparelhosCelulares { get; set; }

        public System.Data.Entity.DbSet<COGERTI.Models.LinhaMovel> LinhasMoveis { get; set; }
    }
}