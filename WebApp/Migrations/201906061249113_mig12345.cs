namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig12345 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CenaKartes", "TipKarte", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CenaKartes", "TipKarte");
        }
    }
}
