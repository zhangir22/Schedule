namespace Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTableState : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Pending = c.Boolean(nullable: false),
                        Jeopardy = c.Boolean(nullable: false),
                        Completed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Cases", "Duratation", c => c.Double(nullable: false));
            DropColumn("dbo.Cases", "Duration");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cases", "Duration", c => c.Int(nullable: false));
            DropColumn("dbo.Cases", "Duratation");
            DropTable("dbo.States");
        }
    }
}
