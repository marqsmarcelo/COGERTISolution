namespace COGERTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration1415 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssociacaoRecursos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FuncionarioUPI = c.Int(nullable: false),
                        RecursoId = c.Int(nullable: false),
                        DataAssociacao = c.DateTime(nullable: false),
                        DataLiberacao = c.DateTime(),
                        MotivoLiberacao = c.String(),
                        TermoResponsabilidade = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Funcionarios", t => t.FuncionarioUPI, cascadeDelete: true)
                .ForeignKey("dbo.Recursos", t => t.RecursoId, cascadeDelete: true)
                .Index(t => t.FuncionarioUPI)
                .Index(t => t.RecursoId);
            
            CreateTable(
                "dbo.Funcionarios",
                c => new
                    {
                        UPI = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Sobrenome = c.String(),
                        UsuarioGad = c.String(),
                        PlantaId = c.Int(nullable: false),
                        StatusFuncionarioId = c.Int(nullable: false),
                        CentroDeCustoId = c.Int(nullable: false),
                        CentroDeCusto_Id = c.Int(),
                        LocalSite_Id = c.Int(),
                    })
                .PrimaryKey(t => t.UPI)
                .ForeignKey("dbo.CentrosDeCustos", t => t.CentroDeCusto_Id)
                .ForeignKey("dbo.CentrosDeCustos", t => t.CentroDeCustoId, cascadeDelete: true)
                .ForeignKey("dbo.LocalSites", t => t.LocalSite_Id)
                .ForeignKey("dbo.StatusFuncionarios", t => t.StatusFuncionarioId, cascadeDelete: true)
                .Index(t => t.StatusFuncionarioId)
                .Index(t => t.CentroDeCustoId)
                .Index(t => t.CentroDeCusto_Id)
                .Index(t => t.LocalSite_Id);
            
            CreateTable(
                "dbo.CentrosDeCustos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        GestorUPI = c.Int(),
                        CoordenadorUPI = c.Int(),
                        CoordenadorCC_UPI = c.Int(),
                        GestorCC_UPI = c.Int(),
                        Funcionario_UPI = c.Int(),
                        Funcionario_UPI1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Funcionarios", t => t.CoordenadorCC_UPI)
                .ForeignKey("dbo.Funcionarios", t => t.GestorCC_UPI)
                .ForeignKey("dbo.Funcionarios", t => t.Funcionario_UPI)
                .ForeignKey("dbo.Funcionarios", t => t.Funcionario_UPI1)
                .Index(t => t.CoordenadorCC_UPI)
                .Index(t => t.GestorCC_UPI)
                .Index(t => t.Funcionario_UPI)
                .Index(t => t.Funcionario_UPI1);
            
            CreateTable(
                "dbo.LocalSites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Sigla = c.String(),
                        UF = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recursos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlantaId = c.Int(nullable: false),
                        LocalSite_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LocalSites", t => t.LocalSite_Id)
                .Index(t => t.LocalSite_Id);
            
            CreateTable(
                "dbo.PropriedadeEquipamentos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Lote = c.String(),
                        PedidoSapNo = c.String(),
                        ContratoNo = c.String(),
                        DataCompra = c.DateTime(),
                        DataRecebimento = c.DateTime(),
                        DataTerminoGarantia = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StatusEquipamentos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TiposAparelhosCelulares",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TiposComputadores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CodigosDdd",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DddCodigo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TiposLinhas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TiposPlanosMoveis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StatusFuncionarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Equipamentos",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        SerialNo = c.String(),
                        Patrimonio = c.Double(),
                        DataFabricacao = c.DateTime(),
                        Marca = c.String(),
                        Modelo = c.String(),
                        PropriedadeId = c.Int(nullable: false),
                        StatusEquipamentoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recursos", t => t.Id)
                .ForeignKey("dbo.PropriedadeEquipamentos", t => t.PropriedadeId, cascadeDelete: true)
                .ForeignKey("dbo.StatusEquipamentos", t => t.StatusEquipamentoId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.PropriedadeId)
                .Index(t => t.StatusEquipamentoId);
            
            CreateTable(
                "dbo.Computadores",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        TipoComputadorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Equipamentos", t => t.Id)
                .ForeignKey("dbo.TiposComputadores", t => t.TipoComputadorId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.TipoComputadorId);
            
            CreateTable(
                "dbo.AparelhosCelulares",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        IMEI1 = c.String(nullable: false),
                        IMEI2 = c.String(),
                        TipoAparelhoCelularId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Equipamentos", t => t.Id)
                .ForeignKey("dbo.TiposAparelhosCelulares", t => t.TipoAparelhoCelularId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.TipoAparelhoCelularId);
            
            CreateTable(
                "dbo.LinhasMoveis",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        LinhaNo = c.String(),
                        ChipId = c.String(),
                        CodigoDddId = c.Int(nullable: false),
                        TipoLinhaId = c.Int(nullable: false),
                        TipoPlanoMovelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recursos", t => t.Id)
                .ForeignKey("dbo.CodigosDdd", t => t.CodigoDddId, cascadeDelete: true)
                .ForeignKey("dbo.TiposLinhas", t => t.TipoLinhaId, cascadeDelete: true)
                .ForeignKey("dbo.TiposPlanosMoveis", t => t.TipoPlanoMovelId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.CodigoDddId)
                .Index(t => t.TipoLinhaId)
                .Index(t => t.TipoPlanoMovelId);
            
            CreateTable(
                "dbo.UsuariosVpn",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Usuario = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recursos", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsuariosVpn", "Id", "dbo.Recursos");
            DropForeignKey("dbo.LinhasMoveis", "TipoPlanoMovelId", "dbo.TiposPlanosMoveis");
            DropForeignKey("dbo.LinhasMoveis", "TipoLinhaId", "dbo.TiposLinhas");
            DropForeignKey("dbo.LinhasMoveis", "CodigoDddId", "dbo.CodigosDdd");
            DropForeignKey("dbo.LinhasMoveis", "Id", "dbo.Recursos");
            DropForeignKey("dbo.AparelhosCelulares", "TipoAparelhoCelularId", "dbo.TiposAparelhosCelulares");
            DropForeignKey("dbo.AparelhosCelulares", "Id", "dbo.Equipamentos");
            DropForeignKey("dbo.Computadores", "TipoComputadorId", "dbo.TiposComputadores");
            DropForeignKey("dbo.Computadores", "Id", "dbo.Equipamentos");
            DropForeignKey("dbo.Equipamentos", "StatusEquipamentoId", "dbo.StatusEquipamentos");
            DropForeignKey("dbo.Equipamentos", "PropriedadeId", "dbo.PropriedadeEquipamentos");
            DropForeignKey("dbo.Equipamentos", "Id", "dbo.Recursos");
            DropForeignKey("dbo.Funcionarios", "StatusFuncionarioId", "dbo.StatusFuncionarios");
            DropForeignKey("dbo.Recursos", "LocalSite_Id", "dbo.LocalSites");
            DropForeignKey("dbo.AssociacaoRecursos", "RecursoId", "dbo.Recursos");
            DropForeignKey("dbo.Funcionarios", "LocalSite_Id", "dbo.LocalSites");
            DropForeignKey("dbo.CentrosDeCustos", "Funcionario_UPI1", "dbo.Funcionarios");
            DropForeignKey("dbo.CentrosDeCustos", "Funcionario_UPI", "dbo.Funcionarios");
            DropForeignKey("dbo.Funcionarios", "CentroDeCustoId", "dbo.CentrosDeCustos");
            DropForeignKey("dbo.CentrosDeCustos", "GestorCC_UPI", "dbo.Funcionarios");
            DropForeignKey("dbo.Funcionarios", "CentroDeCusto_Id", "dbo.CentrosDeCustos");
            DropForeignKey("dbo.CentrosDeCustos", "CoordenadorCC_UPI", "dbo.Funcionarios");
            DropForeignKey("dbo.AssociacaoRecursos", "FuncionarioUPI", "dbo.Funcionarios");
            DropIndex("dbo.UsuariosVpn", new[] { "Id" });
            DropIndex("dbo.LinhasMoveis", new[] { "TipoPlanoMovelId" });
            DropIndex("dbo.LinhasMoveis", new[] { "TipoLinhaId" });
            DropIndex("dbo.LinhasMoveis", new[] { "CodigoDddId" });
            DropIndex("dbo.LinhasMoveis", new[] { "Id" });
            DropIndex("dbo.AparelhosCelulares", new[] { "TipoAparelhoCelularId" });
            DropIndex("dbo.AparelhosCelulares", new[] { "Id" });
            DropIndex("dbo.Computadores", new[] { "TipoComputadorId" });
            DropIndex("dbo.Computadores", new[] { "Id" });
            DropIndex("dbo.Equipamentos", new[] { "StatusEquipamentoId" });
            DropIndex("dbo.Equipamentos", new[] { "PropriedadeId" });
            DropIndex("dbo.Equipamentos", new[] { "Id" });
            DropIndex("dbo.Recursos", new[] { "LocalSite_Id" });
            DropIndex("dbo.CentrosDeCustos", new[] { "Funcionario_UPI1" });
            DropIndex("dbo.CentrosDeCustos", new[] { "Funcionario_UPI" });
            DropIndex("dbo.CentrosDeCustos", new[] { "GestorCC_UPI" });
            DropIndex("dbo.CentrosDeCustos", new[] { "CoordenadorCC_UPI" });
            DropIndex("dbo.Funcionarios", new[] { "LocalSite_Id" });
            DropIndex("dbo.Funcionarios", new[] { "CentroDeCusto_Id" });
            DropIndex("dbo.Funcionarios", new[] { "CentroDeCustoId" });
            DropIndex("dbo.Funcionarios", new[] { "StatusFuncionarioId" });
            DropIndex("dbo.AssociacaoRecursos", new[] { "RecursoId" });
            DropIndex("dbo.AssociacaoRecursos", new[] { "FuncionarioUPI" });
            DropTable("dbo.UsuariosVpn");
            DropTable("dbo.LinhasMoveis");
            DropTable("dbo.AparelhosCelulares");
            DropTable("dbo.Computadores");
            DropTable("dbo.Equipamentos");
            DropTable("dbo.StatusFuncionarios");
            DropTable("dbo.TiposPlanosMoveis");
            DropTable("dbo.TiposLinhas");
            DropTable("dbo.CodigosDdd");
            DropTable("dbo.TiposComputadores");
            DropTable("dbo.TiposAparelhosCelulares");
            DropTable("dbo.StatusEquipamentos");
            DropTable("dbo.PropriedadeEquipamentos");
            DropTable("dbo.Recursos");
            DropTable("dbo.LocalSites");
            DropTable("dbo.CentrosDeCustos");
            DropTable("dbo.Funcionarios");
            DropTable("dbo.AssociacaoRecursos");
        }
    }
}
