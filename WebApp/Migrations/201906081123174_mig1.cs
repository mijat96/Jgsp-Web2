namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CenaKartes",
                c => new
                    {
                        IdCenaKarte = c.Int(nullable: false, identity: true),
                        Cena = c.Single(nullable: false),
                        TipKarte = c.String(),
                        TipKupca = c.String(),
                        CenovnikId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCenaKarte)
                .ForeignKey("dbo.Cenovniks", t => t.CenovnikId, cascadeDelete: true)
                .Index(t => t.CenovnikId);
            
            CreateTable(
                "dbo.Cenovniks",
                c => new
                    {
                        IdCenovnik = c.Int(nullable: false, identity: true),
                        VaziOd = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        VaziDo = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.IdCenovnik);
            
            CreateTable(
                "dbo.Kartas",
                c => new
                    {
                        IdKarte = c.Int(nullable: false, identity: true),
                        Cekirana = c.Boolean(nullable: false),
                        Tip = c.String(),
                        VaziDo = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ApplicationUserId = c.String(maxLength: 128),
                        CenaKarteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdKarte)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.CenaKartes", t => t.CenaKarteId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.CenaKarteId);
            
            CreateTable(
                "dbo.Linijas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RedniBroj = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RedVoznjes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DanUNedelji = c.String(),
                        Polasci = c.String(),
                        LinijaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Linijas", t => t.LinijaId, cascadeDelete: true)
                .Index(t => t.LinijaId);
            
            CreateTable(
                "dbo.Stanicas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Adresa = c.String(),
                        X = c.Int(nullable: false),
                        Y = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Voziloes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tip = c.String(),
                        X = c.Int(nullable: false),
                        Y = c.Int(nullable: false),
                        LinijaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Linijas", t => t.LinijaId, cascadeDelete: true)
                .Index(t => t.LinijaId);
            
            CreateTable(
                "dbo.StanicaLinijas",
                c => new
                    {
                        Stanica_Id = c.Int(nullable: false),
                        Linija_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Stanica_Id, t.Linija_Id })
                .ForeignKey("dbo.Stanicas", t => t.Stanica_Id, cascadeDelete: true)
                .ForeignKey("dbo.Linijas", t => t.Linija_Id, cascadeDelete: true)
                .Index(t => t.Stanica_Id)
                .Index(t => t.Linija_Id);
            
            AddColumn("dbo.AspNetUsers", "Tip", c => c.String());
            AddColumn("dbo.AspNetUsers", "Datum", c => c.String());
            AddColumn("dbo.AspNetUsers", "Password", c => c.String());
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "Surname", c => c.String());
            AddColumn("dbo.AspNetUsers", "ConfirmPassword", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Voziloes", "LinijaId", "dbo.Linijas");
            DropForeignKey("dbo.StanicaLinijas", "Linija_Id", "dbo.Linijas");
            DropForeignKey("dbo.StanicaLinijas", "Stanica_Id", "dbo.Stanicas");
            DropForeignKey("dbo.RedVoznjes", "LinijaId", "dbo.Linijas");
            DropForeignKey("dbo.Kartas", "CenaKarteId", "dbo.CenaKartes");
            DropForeignKey("dbo.Kartas", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CenaKartes", "CenovnikId", "dbo.Cenovniks");
            DropIndex("dbo.StanicaLinijas", new[] { "Linija_Id" });
            DropIndex("dbo.StanicaLinijas", new[] { "Stanica_Id" });
            DropIndex("dbo.Voziloes", new[] { "LinijaId" });
            DropIndex("dbo.RedVoznjes", new[] { "LinijaId" });
            DropIndex("dbo.Kartas", new[] { "CenaKarteId" });
            DropIndex("dbo.Kartas", new[] { "ApplicationUserId" });
            DropIndex("dbo.CenaKartes", new[] { "CenovnikId" });
            DropColumn("dbo.AspNetUsers", "ConfirmPassword");
            DropColumn("dbo.AspNetUsers", "Surname");
            DropColumn("dbo.AspNetUsers", "Name");
            DropColumn("dbo.AspNetUsers", "Password");
            DropColumn("dbo.AspNetUsers", "Datum");
            DropColumn("dbo.AspNetUsers", "Tip");
            DropTable("dbo.StanicaLinijas");
            DropTable("dbo.Voziloes");
            DropTable("dbo.Stanicas");
            DropTable("dbo.RedVoznjes");
            DropTable("dbo.Linijas");
            DropTable("dbo.Kartas");
            DropTable("dbo.Cenovniks");
            DropTable("dbo.CenaKartes");
        }
    }
}
