namespace Deadliner.Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_LastCall_and_Interval_into_Notification : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "Interval", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.Notifications", "LastCall", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notifications", "LastCall");
            DropColumn("dbo.Notifications", "Interval");
        }
    }
}
