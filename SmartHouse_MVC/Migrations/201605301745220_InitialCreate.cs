namespace SmartHouse_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alarms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Access = c.Boolean(nullable: false),
                        State = c.Boolean(nullable: false),
                        Room_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.Room_Id)
                .Index(t => t.Room_Id);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Conditioners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CurrentTemperature = c.Int(nullable: false),
                        MinimalTemperature = c.Int(nullable: false),
                        MaximalTemperature = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Access = c.Boolean(nullable: false),
                        State = c.Boolean(nullable: false),
                        Room_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.Room_Id)
                .Index(t => t.Room_Id);
            
            CreateTable(
                "dbo.Exhausters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CurrentPower = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Access = c.Boolean(nullable: false),
                        State = c.Boolean(nullable: false),
                        Room_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.Room_Id)
                .Index(t => t.Room_Id);
            
            CreateTable(
                "dbo.Fridges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CurrentTemperature = c.Int(nullable: false),
                        MinimalTemperature = c.Int(nullable: false),
                        MaximalTemperature = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Access = c.Boolean(nullable: false),
                        State = c.Boolean(nullable: false),
                        Room_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.Room_Id)
                .Index(t => t.Room_Id);
            
            CreateTable(
                "dbo.Jalousies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Access = c.Boolean(nullable: false),
                        State = c.Boolean(nullable: false),
                        Room_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.Room_Id)
                .Index(t => t.Room_Id);
            
            CreateTable(
                "dbo.Lamps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LampType = c.String(nullable: false),
                        CurrentBrightness = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Access = c.Boolean(nullable: false),
                        State = c.Boolean(nullable: false),
                        Room_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.Room_Id)
                .Index(t => t.Room_Id);
            
            CreateTable(
                "dbo.Radiators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CurrentTemperature = c.Int(nullable: false),
                        MinimalTemperature = c.Int(nullable: false),
                        MaximalTemperature = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Access = c.Boolean(nullable: false),
                        State = c.Boolean(nullable: false),
                        Room_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.Room_Id)
                .Index(t => t.Room_Id);
            
            CreateTable(
                "dbo.Routers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Access = c.Boolean(nullable: false),
                        State = c.Boolean(nullable: false),
                        Room_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.Room_Id)
                .Index(t => t.Room_Id);
            
            CreateTable(
                "dbo.StereoSystems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CurrentVolume = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Access = c.Boolean(nullable: false),
                        State = c.Boolean(nullable: false),
                        Room_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.Room_Id)
                .Index(t => t.Room_Id);
            
            CreateTable(
                "dbo.TVs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CurrentVolume = c.Int(nullable: false),
                        CurrentBrightness = c.Int(nullable: false),
                        CurrentChannel = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Access = c.Boolean(nullable: false),
                        State = c.Boolean(nullable: false),
                        Room_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.Room_Id)
                .Index(t => t.Room_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TVs", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.StereoSystems", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.Routers", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.Radiators", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.Lamps", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.Jalousies", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.Fridges", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.Exhausters", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.Conditioners", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.Alarms", "Room_Id", "dbo.Rooms");
            DropIndex("dbo.TVs", new[] { "Room_Id" });
            DropIndex("dbo.StereoSystems", new[] { "Room_Id" });
            DropIndex("dbo.Routers", new[] { "Room_Id" });
            DropIndex("dbo.Radiators", new[] { "Room_Id" });
            DropIndex("dbo.Lamps", new[] { "Room_Id" });
            DropIndex("dbo.Jalousies", new[] { "Room_Id" });
            DropIndex("dbo.Fridges", new[] { "Room_Id" });
            DropIndex("dbo.Exhausters", new[] { "Room_Id" });
            DropIndex("dbo.Conditioners", new[] { "Room_Id" });
            DropIndex("dbo.Alarms", new[] { "Room_Id" });
            DropTable("dbo.TVs");
            DropTable("dbo.StereoSystems");
            DropTable("dbo.Routers");
            DropTable("dbo.Radiators");
            DropTable("dbo.Lamps");
            DropTable("dbo.Jalousies");
            DropTable("dbo.Fridges");
            DropTable("dbo.Exhausters");
            DropTable("dbo.Conditioners");
            DropTable("dbo.Rooms");
            DropTable("dbo.Alarms");
        }
    }
}
