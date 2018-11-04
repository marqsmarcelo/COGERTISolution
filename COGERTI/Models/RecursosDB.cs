using System.Data.Entity.Infrastructure;

namespace COGERTI.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class RecursosDB : DbContext
    {
        // Your context has been configured to use a 'RecursosDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'COGERTI.Models.RecursosDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'RecursosDB' 
        // connection string in the application configuration file.
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
        public DbSet<TipoComputador> TiposComputadores { get; set; }
        public DbSet<PropriedadeEquipamento> PropriedadeEquipamentos { get; set; }
        public DbSet<TipoAparelhoCelular> TiposAparelhosCelulares { get; set; }
        public DbSet<CodigoDdd> CodigosDdd { get; set; }
        public DbSet<TipoLinha> TiposLinhas { get; set; }
        public DbSet<TipoPlanoMovel> TiposPlanosMoveis { get; set; }

        //public System.Data.Entity.DbSet<COGERTI.Models.Computador> Computadores { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}