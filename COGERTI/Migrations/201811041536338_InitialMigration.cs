namespace COGERTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CentrosDeCustos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        CoordenadorUPI = c.Int(),
                        GestorUPI = c.Int(),
                        Funcionario_UPI = c.Int(),
                        Funcionario_UPI1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Funcionarios", t => t.Funcionario_UPI)
                .ForeignKey("dbo.Funcionarios", t => t.Funcionario_UPI1)
                .ForeignKey("dbo.Funcionarios", t => t.CoordenadorUPI)
                .ForeignKey("dbo.Funcionarios", t => t.GestorUPI)
                .Index(t => t.CoordenadorUPI)
                .Index(t => t.GestorUPI)
                .Index(t => t.Funcionario_UPI)
                .Index(t => t.Funcionario_UPI1);
            
            CreateTable(
                "dbo.Funcionarios",
                c => new
                    {
                        UPI = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Sobrenome = c.String(),
                        UsuarioGad = c.String(),
                        LocalSiteId = c.Int(nullable: false),
                        StatusFuncionarioId = c.Int(nullable: false),
                        CentroDeCustoId = c.Int(nullable: false),
                        CentroDeCusto_Id = c.Int(),
                    })
                .PrimaryKey(t => t.UPI)
                .ForeignKey("dbo.CentrosDeCustos", t => t.CentroDeCustoId, cascadeDelete: true)
                .ForeignKey("dbo.LocalSites", t => t.LocalSiteId, cascadeDelete: true)
                .ForeignKey("dbo.StatusFuncionarios", t => t.StatusFuncionarioId, cascadeDelete: true)
                .ForeignKey("dbo.CentrosDeCustos", t => t.CentroDeCusto_Id)
                .Index(t => t.LocalSiteId)
                .Index(t => t.StatusFuncionarioId)
                .Index(t => t.CentroDeCustoId)
                .Index(t => t.CentroDeCusto_Id);
            
            CreateTable(
                "dbo.LocalSites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Sigla = c.String(maxLength: 10),
                        UF = c.String(maxLength: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recursos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocalSiteId = c.Int(nullable: false),
                        FuncionarioUPI = c.Int(nullable: false),
                        DataAssociacao = c.DateTime(nullable: false),
                        DataLiberacao = c.DateTime(),
                        MotivoLiberacao = c.String(),
                        TermoResponsabilidade = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Funcionarios", t => t.FuncionarioUPI, cascadeDelete: true)
                .ForeignKey("dbo.LocalSites", t => t.LocalSiteId, cascadeDelete: false)
                .Index(t => t.LocalSiteId)
                .Index(t => t.FuncionarioUPI);
            
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
                        DddCodigo = c.String(maxLength: 2),
                        UF = c.String(maxLength: 2),
                        Regiao = c.String(),
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
                        SerialNo = c.String(nullable: false),
                        Patrimonio = c.String(maxLength: 6),
                        DataFabricacao = c.DateTime(),
                        Marca = c.String(nullable: false),
                        Modelo = c.String(nullable: false),
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
                "dbo.LinhaMovel",
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
            DropForeignKey("dbo.LinhaMovel", "TipoPlanoMovelId", "dbo.TiposPlanosMoveis");
            DropForeignKey("dbo.LinhaMovel", "TipoLinhaId", "dbo.TiposLinhas");
            DropForeignKey("dbo.LinhaMovel", "CodigoDddId", "dbo.CodigosDdd");
            DropForeignKey("dbo.LinhaMovel", "Id", "dbo.Recursos");
            DropForeignKey("dbo.Computadores", "TipoComputadorId", "dbo.TiposComputadores");
            DropForeignKey("dbo.Computadores", "Id", "dbo.Equipamentos");
            DropForeignKey("dbo.AparelhosCelulares", "TipoAparelhoCelularId", "dbo.TiposAparelhosCelulares");
            DropForeignKey("dbo.AparelhosCelulares", "Id", "dbo.Equipamentos");
            DropForeignKey("dbo.Equipamentos", "StatusEquipamentoId", "dbo.StatusEquipamentos");
            DropForeignKey("dbo.Equipamentos", "PropriedadeId", "dbo.PropriedadeEquipamentos");
            DropForeignKey("dbo.Equipamentos", "Id", "dbo.Recursos");
            DropForeignKey("dbo.CentrosDeCustos", "GestorUPI", "dbo.Funcionarios");
            DropForeignKey("dbo.Funcionarios", "CentroDeCusto_Id", "dbo.CentrosDeCustos");
            DropForeignKey("dbo.CentrosDeCustos", "CoordenadorUPI", "dbo.Funcionarios");
            DropForeignKey("dbo.Funcionarios", "StatusFuncionarioId", "dbo.StatusFuncionarios");
            DropForeignKey("dbo.Recursos", "LocalSiteId", "dbo.LocalSites");
            DropForeignKey("dbo.Recursos", "FuncionarioUPI", "dbo.Funcionarios");
            DropForeignKey("dbo.Funcionarios", "LocalSiteId", "dbo.LocalSites");
            DropForeignKey("dbo.CentrosDeCustos", "Funcionario_UPI1", "dbo.Funcionarios");
            DropForeignKey("dbo.CentrosDeCustos", "Funcionario_UPI", "dbo.Funcionarios");
            DropForeignKey("dbo.Funcionarios", "CentroDeCustoId", "dbo.CentrosDeCustos");
            DropIndex("dbo.UsuariosVpn", new[] { "Id" });
            DropIndex("dbo.LinhaMovel", new[] { "TipoPlanoMovelId" });
            DropIndex("dbo.LinhaMovel", new[] { "TipoLinhaId" });
            DropIndex("dbo.LinhaMovel", new[] { "CodigoDddId" });
            DropIndex("dbo.LinhaMovel", new[] { "Id" });
            DropIndex("dbo.Computadores", new[] { "TipoComputadorId" });
            DropIndex("dbo.Computadores", new[] { "Id" });
            DropIndex("dbo.AparelhosCelulares", new[] { "TipoAparelhoCelularId" });
            DropIndex("dbo.AparelhosCelulares", new[] { "Id" });
            DropIndex("dbo.Equipamentos", new[] { "StatusEquipamentoId" });
            DropIndex("dbo.Equipamentos", new[] { "PropriedadeId" });
            DropIndex("dbo.Equipamentos", new[] { "Id" });
            DropIndex("dbo.Recursos", new[] { "FuncionarioUPI" });
            DropIndex("dbo.Recursos", new[] { "LocalSiteId" });
            DropIndex("dbo.Funcionarios", new[] { "CentroDeCusto_Id" });
            DropIndex("dbo.Funcionarios", new[] { "CentroDeCustoId" });
            DropIndex("dbo.Funcionarios", new[] { "StatusFuncionarioId" });
            DropIndex("dbo.Funcionarios", new[] { "LocalSiteId" });
            DropIndex("dbo.CentrosDeCustos", new[] { "Funcionario_UPI1" });
            DropIndex("dbo.CentrosDeCustos", new[] { "Funcionario_UPI" });
            DropIndex("dbo.CentrosDeCustos", new[] { "GestorUPI" });
            DropIndex("dbo.CentrosDeCustos", new[] { "CoordenadorUPI" });
            DropTable("dbo.UsuariosVpn");
            DropTable("dbo.LinhaMovel");
            DropTable("dbo.Computadores");
            DropTable("dbo.AparelhosCelulares");
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
            DropTable("dbo.Funcionarios");
            DropTable("dbo.CentrosDeCustos");
        }
    }
}
