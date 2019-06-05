namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RedVoznjes", "Polasci", c => c.String());
            DropColumn("dbo.Linijas", "Polasci");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Linijas", "Polasci", c => c.String());
            DropColumn("dbo.RedVoznjes", "Polasci");
        }
    }
}
