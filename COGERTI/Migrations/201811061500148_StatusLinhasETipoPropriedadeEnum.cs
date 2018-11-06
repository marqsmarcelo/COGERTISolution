namespace COGERTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatusLinhasETipoPropriedadeEnum : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StatusLinhas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.LinhaMovel", "StatusLinhaId", c => c.Int(nullable: false));
            AddColumn("dbo.PropriedadeEquipamentos", "TipoPropriedade", c => c.Int(nullable: false));
            CreateIndex("dbo.LinhaMovel", "StatusLinhaId");
            AddForeignKey("dbo.LinhaMovel", "StatusLinhaId", "dbo.StatusLinhas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LinhaMovel", "StatusLinhaId", "dbo.StatusLinhas");
            DropIndex("dbo.LinhaMovel", new[] { "StatusLinhaId" });
            DropColumn("dbo.PropriedadeEquipamentos", "TipoPropriedade");
            DropColumn("dbo.LinhaMovel", "StatusLinhaId");
            DropTable("dbo.StatusLinhas");
        }
    }
}
