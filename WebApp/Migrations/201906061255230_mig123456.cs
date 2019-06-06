namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig123456 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CenaKartes", "TipKupca", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CenaKartes", "TipKupca");
        }
    }
}
