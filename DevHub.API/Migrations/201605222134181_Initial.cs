namespace DevHub.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Categories", "Color", c => c.String(nullable: false, maxLength: 7));
            AlterColumn("dbo.Courses", "Title", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "Title", c => c.String());
            AlterColumn("dbo.Categories", "Color", c => c.String());
            AlterColumn("dbo.Categories", "Name", c => c.String());
        }
    }
}
