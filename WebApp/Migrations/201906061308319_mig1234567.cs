namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1234567 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kartas", "VaziDo", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropColumn("dbo.Kartas", "CekiranaUTrenutku");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kartas", "CekiranaUTrenutku", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropColumn("dbo.Kartas", "VaziDo");
        }
    }
}
