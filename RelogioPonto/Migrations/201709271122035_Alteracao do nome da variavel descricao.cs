namespace RelogioPonto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alteracaodonomedavariaveldescricao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Relogios", "Descricao", c => c.String());
            AlterColumn("dbo.Relogios", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Relogios", "Ip", c => c.String(nullable: false));
            DropColumn("dbo.Relogios", "Descrição");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Relogios", "Descrição", c => c.String());
            AlterColumn("dbo.Relogios", "Ip", c => c.String());
            AlterColumn("dbo.Relogios", "Nome", c => c.String());
            DropColumn("dbo.Relogios", "Descricao");
        }
    }
}
