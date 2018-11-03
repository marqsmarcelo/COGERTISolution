namespace COGERTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTipos1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CodigosDdd", "UF", c => c.String(maxLength: 2));
            AddColumn("dbo.CodigosDdd", "Regiao", c => c.String());
            AlterColumn("dbo.LocalSites", "Sigla", c => c.String(maxLength: 10));
            AlterColumn("dbo.LocalSites", "UF", c => c.String(maxLength: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LocalSites", "UF", c => c.String());
            AlterColumn("dbo.LocalSites", "Sigla", c => c.String());
            DropColumn("dbo.CodigosDdd", "Regiao");
            DropColumn("dbo.CodigosDdd", "UF");
        }
    }
}
