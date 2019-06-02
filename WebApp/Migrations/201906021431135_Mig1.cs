namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Tip", c => c.String());
            //DropTable("dbo.TipKorisnikas");
        }
        
        public override void Down()
        {
            //CreateTable(
            //    "dbo.TipKorisnikas",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Tip = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.AspNetUsers", "Tip");
        }
    }
}
