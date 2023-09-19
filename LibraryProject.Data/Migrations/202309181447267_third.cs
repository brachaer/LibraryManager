namespace LibraryProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Items", "CopyNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "CopyNumber", c => c.Int());
        }
    }
}
