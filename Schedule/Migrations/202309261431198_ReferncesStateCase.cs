namespace Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReferncesStateCase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.States", "CaseId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.States", "CaseId");
        }
    }
}
