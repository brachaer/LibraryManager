namespace LibraryProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fifth : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Items", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.Items", name: "IX_User_Id", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Items", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Items", name: "UserId", newName: "User_Id");
        }
    }
}
