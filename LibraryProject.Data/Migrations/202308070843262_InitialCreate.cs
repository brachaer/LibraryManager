namespace LibraryProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                        PrintDate = c.DateTime(),
                        BookPublishing = c.String(),
                        Price = c.Int(nullable: false),
                        Category = c.Int(nullable: false),
                        Author = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CopyNumber = c.Int(),
                        ISBN = c.String(),
                        IssueNumber = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        IsLibrarian = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Items");
        }
    }
}
