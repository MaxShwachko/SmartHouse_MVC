namespace SmartHouse_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Keys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Alarms", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.Conditioners", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.Exhausters", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.Fridges", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.Jalousies", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.Lamps", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.Radiators", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.Routers", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.StereoSystems", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.TVs", "Room_Id", "dbo.Rooms");
            DropIndex("dbo.Alarms", new[] { "Room_Id" });
            DropIndex("dbo.Conditioners", new[] { "Room_Id" });
            DropIndex("dbo.Exhausters", new[] { "Room_Id" });
            DropIndex("dbo.Fridges", new[] { "Room_Id" });
            DropIndex("dbo.Jalousies", new[] { "Room_Id" });
            DropIndex("dbo.Lamps", new[] { "Room_Id" });
            DropIndex("dbo.Radiators", new[] { "Room_Id" });
            DropIndex("dbo.Routers", new[] { "Room_Id" });
            DropIndex("dbo.StereoSystems", new[] { "Room_Id" });
            DropIndex("dbo.TVs", new[] { "Room_Id" });
            AlterColumn("dbo.Alarms", "Room_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Conditioners", "Room_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Exhausters", "Room_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Fridges", "Room_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Jalousies", "Room_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Lamps", "Room_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Radiators", "Room_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Routers", "Room_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.StereoSystems", "Room_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.TVs", "Room_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Alarms", "Room_Id");
            CreateIndex("dbo.Conditioners", "Room_Id");
            CreateIndex("dbo.Exhausters", "Room_Id");
            CreateIndex("dbo.Fridges", "Room_Id");
            CreateIndex("dbo.Jalousies", "Room_Id");
            CreateIndex("dbo.Lamps", "Room_Id");
            CreateIndex("dbo.Radiators", "Room_Id");
            CreateIndex("dbo.Routers", "Room_Id");
            CreateIndex("dbo.StereoSystems", "Room_Id");
            CreateIndex("dbo.TVs", "Room_Id");
            AddForeignKey("dbo.Alarms", "Room_Id", "dbo.Rooms", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Conditioners", "Room_Id", "dbo.Rooms", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Exhausters", "Room_Id", "dbo.Rooms", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Fridges", "Room_Id", "dbo.Rooms", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Jalousies", "Room_Id", "dbo.Rooms", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Lamps", "Room_Id", "dbo.Rooms", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Radiators", "Room_Id", "dbo.Rooms", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Routers", "Room_Id", "dbo.Rooms", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StereoSystems", "Room_Id", "dbo.Rooms", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TVs", "Room_Id", "dbo.Rooms", "Id", cascadeDelete: true);
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
            AlterColumn("dbo.TVs", "Room_Id", c => c.Int());
            AlterColumn("dbo.StereoSystems", "Room_Id", c => c.Int());
            AlterColumn("dbo.Routers", "Room_Id", c => c.Int());
            AlterColumn("dbo.Radiators", "Room_Id", c => c.Int());
            AlterColumn("dbo.Lamps", "Room_Id", c => c.Int());
            AlterColumn("dbo.Jalousies", "Room_Id", c => c.Int());
            AlterColumn("dbo.Fridges", "Room_Id", c => c.Int());
            AlterColumn("dbo.Exhausters", "Room_Id", c => c.Int());
            AlterColumn("dbo.Conditioners", "Room_Id", c => c.Int());
            AlterColumn("dbo.Alarms", "Room_Id", c => c.Int());
            CreateIndex("dbo.TVs", "Room_Id");
            CreateIndex("dbo.StereoSystems", "Room_Id");
            CreateIndex("dbo.Routers", "Room_Id");
            CreateIndex("dbo.Radiators", "Room_Id");
            CreateIndex("dbo.Lamps", "Room_Id");
            CreateIndex("dbo.Jalousies", "Room_Id");
            CreateIndex("dbo.Fridges", "Room_Id");
            CreateIndex("dbo.Exhausters", "Room_Id");
            CreateIndex("dbo.Conditioners", "Room_Id");
            CreateIndex("dbo.Alarms", "Room_Id");
            AddForeignKey("dbo.TVs", "Room_Id", "dbo.Rooms", "Id");
            AddForeignKey("dbo.StereoSystems", "Room_Id", "dbo.Rooms", "Id");
            AddForeignKey("dbo.Routers", "Room_Id", "dbo.Rooms", "Id");
            AddForeignKey("dbo.Radiators", "Room_Id", "dbo.Rooms", "Id");
            AddForeignKey("dbo.Lamps", "Room_Id", "dbo.Rooms", "Id");
            AddForeignKey("dbo.Jalousies", "Room_Id", "dbo.Rooms", "Id");
            AddForeignKey("dbo.Fridges", "Room_Id", "dbo.Rooms", "Id");
            AddForeignKey("dbo.Exhausters", "Room_Id", "dbo.Rooms", "Id");
            AddForeignKey("dbo.Conditioners", "Room_Id", "dbo.Rooms", "Id");
            AddForeignKey("dbo.Alarms", "Room_Id", "dbo.Rooms", "Id");
        }
    }
}
