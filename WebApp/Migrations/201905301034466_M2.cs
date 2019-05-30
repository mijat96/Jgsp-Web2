namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "TipKorisnikaId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "TipKorisnikaId");
            AddForeignKey("dbo.AspNetUsers", "TipKorisnikaId", "dbo.TipKorisnikas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "TipKorisnikaId", "dbo.TipKorisnikas");
            DropIndex("dbo.AspNetUsers", new[] { "TipKorisnikaId" });
            DropColumn("dbo.AspNetUsers", "TipKorisnikaId");
        }
    }
}
