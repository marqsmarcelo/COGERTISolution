namespace COGERTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredResourceFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recursos", "FuncionarioUPI", "dbo.Funcionarios");
            DropIndex("dbo.Recursos", new[] { "FuncionarioUPI" });
            AlterColumn("dbo.Recursos", "FuncionarioUPI", c => c.Int());
            CreateIndex("dbo.Recursos", "FuncionarioUPI");
            AddForeignKey("dbo.Recursos", "FuncionarioUPI", "dbo.Funcionarios", "UPI");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recursos", "FuncionarioUPI", "dbo.Funcionarios");
            DropIndex("dbo.Recursos", new[] { "FuncionarioUPI" });
            AlterColumn("dbo.Recursos", "FuncionarioUPI", c => c.Int(nullable: false));
            CreateIndex("dbo.Recursos", "FuncionarioUPI");
            AddForeignKey("dbo.Recursos", "FuncionarioUPI", "dbo.Funcionarios", "UPI", cascadeDelete: true);
        }
    }
}
