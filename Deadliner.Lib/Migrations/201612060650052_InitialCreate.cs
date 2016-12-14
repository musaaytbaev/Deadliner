namespace Deadliner.Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Deadlines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Time = c.DateTime(nullable: false),
                        Priority = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Deadline_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Deadlines", t => t.Deadline_Id)
                .Index(t => t.Deadline_Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        TimeToDo = c.Time(nullable: false, precision: 7),
                        Deadline_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Deadlines", t => t.Deadline_Id)
                .Index(t => t.Deadline_Id);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "Deadline_Id", "dbo.Deadlines");
            DropForeignKey("dbo.Notifications", "Deadline_Id", "dbo.Deadlines");
            DropIndex("dbo.Tasks", new[] { "Deadline_Id" });
            DropIndex("dbo.Notifications", new[] { "Deadline_Id" });
            DropTable("dbo.Tasks");
            DropTable("dbo.Notifications");
            DropTable("dbo.Deadlines");
        }
    }
}
