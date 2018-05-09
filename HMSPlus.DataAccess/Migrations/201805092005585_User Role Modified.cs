namespace HMSPlus.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRoleModified : DbMigration
    {
        public override void Up()
        {
            AddColumn("Users.UserRoles", "Discriminator", c => c.String());
        }

        public override void Down()
        {
            DropColumn("Users.UserRoles", "Discriminator");
        }
    }
}
