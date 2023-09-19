namespace LibraryProject.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "BorrowDate", c => c.DateTime());
            AddColumn("dbo.Items", "ReturnDate", c => c.DateTime());
            DropColumn("dbo.Items", "IsDeleted");
        }

        public override void Down()
        {
            AddColumn("dbo.Items", "IsDeleted", c => c.Boolean(nullable: false));
            DropColumn("dbo.Items", "ReturnDate");
            DropColumn("dbo.Items", "BorrowDate");
        }
    }
}
