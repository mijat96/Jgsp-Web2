namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1234 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Kartas", "Tip", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Kartas", "Tip", c => c.Int(nullable: false));
        }
    }
}
