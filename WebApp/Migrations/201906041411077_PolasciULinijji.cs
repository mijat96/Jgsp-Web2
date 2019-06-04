namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PolasciULinijji : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Linijas", "Polasci", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Linijas", "Polasci");
        }
    }
}
