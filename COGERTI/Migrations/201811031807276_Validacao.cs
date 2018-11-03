namespace COGERTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Validacao : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Equipamentos", "Patrimonio", c => c.String(maxLength: 5));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Equipamentos", "Patrimonio", c => c.Double());
        }
    }
}
