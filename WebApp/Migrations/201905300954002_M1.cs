namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M1 : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.TipKorisnikas",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Tip = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            //DropTable("dbo.TipKorisnikas");
        }
    }
}
