namespace Deadliner.Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_description_in_Deadline : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Deadlines", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Deadlines", "Description");
        }
    }
}
