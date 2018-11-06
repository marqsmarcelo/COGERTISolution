namespace COGERTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsuariosVpnDelete : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.LinhasMoveis", newName: "LinhaMovel");
            DropForeignKey("dbo.UsuariosVpn", "Id", "dbo.Recursos");
            DropIndex("dbo.UsuariosVpn", new[] { "Id" });
            DropTable("dbo.UsuariosVpn");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UsuariosVpn",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Usuario = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.UsuariosVpn", "Id");
            AddForeignKey("dbo.UsuariosVpn", "Id", "dbo.Recursos", "Id");
            RenameTable(name: "dbo.LinhaMovel", newName: "LinhasMoveis");
        }
    }
}
