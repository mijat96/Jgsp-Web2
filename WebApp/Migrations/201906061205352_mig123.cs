namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig123 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Kartas", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Kartas", "ApplicationUserId");
            RenameColumn(table: "dbo.Kartas", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            AlterColumn("dbo.Kartas", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Kartas", "ApplicationUserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Kartas", new[] { "ApplicationUserId" });
            AlterColumn("dbo.Kartas", "ApplicationUserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Kartas", name: "ApplicationUserId", newName: "ApplicationUser_Id");
            AddColumn("dbo.Kartas", "ApplicationUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Kartas", "ApplicationUser_Id");
        }
    }
}
