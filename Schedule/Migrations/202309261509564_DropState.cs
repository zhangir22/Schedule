namespace Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropState : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.States");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Pending = c.Boolean(nullable: false),
                        Jeopardy = c.Boolean(nullable: false),
                        Completed = c.Boolean(nullable: false),
                        CaseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
