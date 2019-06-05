namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kartas", "ApplicationUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Kartas", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Kartas", "ApplicationUser_Id");
            AddForeignKey("dbo.Kartas", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kartas", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Kartas", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Kartas", "ApplicationUser_Id");
            DropColumn("dbo.Kartas", "ApplicationUserId");
        }
    }
}
