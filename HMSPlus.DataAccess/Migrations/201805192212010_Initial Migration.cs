namespace HMSPlus.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Users.Actions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Key = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Users.MenuActions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuId = c.Int(),
                        ActionId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Users.Actions", t => t.ActionId)
                .ForeignKey("Users.Menus", t => t.MenuId)
                .Index(t => t.MenuId)
                .Index(t => t.ActionId);
            
            CreateTable(
                "Users.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Link = c.String(),
                        JsFunction = c.String(),
                        Icon = c.String(),
                        IsSidebarMenu = c.Boolean(nullable: false),
                        MenuKey = c.String(),
                        ParentId = c.Int(),
                        DisplayOrder = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Users.Menus", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "Users.RolePermissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuActionId = c.Int(),
                        RoleId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Users.MenuActions", t => t.MenuActionId)
                .ForeignKey("Users.Roles", t => t.RoleId)
                .Index(t => t.MenuActionId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "Users.Roles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Users.UserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        Discriminator = c.String(),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("Users.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("Users.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "Users.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        ImageUrl = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Users.UserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Users.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "Users.UserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("Users.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "Configurations.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameEn = c.String(),
                        NameAr = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Hotel.Floors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        HotelId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Hotel.Hotels", t => t.HotelId)
                .Index(t => t.HotelId);
            
            CreateTable(
                "Hotel.Hotels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BranchCode = c.String(maxLength: 250),
                        Description = c.String(),
                        HotelTypeId = c.Int(nullable: false),
                        Location = c.String(maxLength: 250),
                        CityId = c.Int(nullable: false),
                        Address = c.String(),
                        NumberOfFloors = c.Int(nullable: false),
                        NumberOfRooms = c.Int(nullable: false),
                        DateCreated = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Configurations.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("Hotel.HotelTypes", t => t.HotelTypeId, cascadeDelete: true)
                .Index(t => t.HotelTypeId)
                .Index(t => t.CityId);
            
            CreateTable(
                "Hotel.HotelTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameEn = c.String(),
                        NameAr = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Hotel.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomNumber = c.Int(nullable: false),
                        RoomName = c.String(maxLength: 250),
                        FloorId = c.Int(),
                        RoomTypeId = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Hotel.Floors", t => t.FloorId)
                .ForeignKey("Hotel.RoomTypes", t => t.RoomTypeId)
                .Index(t => t.FloorId)
                .Index(t => t.RoomTypeId);
            
            CreateTable(
                "Hotel.RoomTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameEn = c.String(maxLength: 250),
                        NameAr = c.String(maxLength: 250),
                        NumberOfBeds = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        HotelId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Hotel.Hotels", t => t.HotelId)
                .Index(t => t.HotelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Hotel.Rooms", "RoomTypeId", "Hotel.RoomTypes");
            DropForeignKey("Hotel.RoomTypes", "HotelId", "Hotel.Hotels");
            DropForeignKey("Hotel.Rooms", "FloorId", "Hotel.Floors");
            DropForeignKey("Hotel.Floors", "HotelId", "Hotel.Hotels");
            DropForeignKey("Hotel.Hotels", "HotelTypeId", "Hotel.HotelTypes");
            DropForeignKey("Hotel.Hotels", "CityId", "Configurations.Cities");
            DropForeignKey("Users.RolePermissions", "RoleId", "Users.Roles");
            DropForeignKey("Users.UserRoles", "UserId", "Users.Users");
            DropForeignKey("Users.UserLogins", "UserId", "Users.Users");
            DropForeignKey("Users.UserClaims", "UserId", "Users.Users");
            DropForeignKey("Users.UserRoles", "RoleId", "Users.Roles");
            DropForeignKey("Users.RolePermissions", "MenuActionId", "Users.MenuActions");
            DropForeignKey("Users.Menus", "ParentId", "Users.Menus");
            DropForeignKey("Users.MenuActions", "MenuId", "Users.Menus");
            DropForeignKey("Users.MenuActions", "ActionId", "Users.Actions");
            DropIndex("Hotel.RoomTypes", new[] { "HotelId" });
            DropIndex("Hotel.Rooms", new[] { "RoomTypeId" });
            DropIndex("Hotel.Rooms", new[] { "FloorId" });
            DropIndex("Hotel.Hotels", new[] { "CityId" });
            DropIndex("Hotel.Hotels", new[] { "HotelTypeId" });
            DropIndex("Hotel.Floors", new[] { "HotelId" });
            DropIndex("Users.UserLogins", new[] { "UserId" });
            DropIndex("Users.UserClaims", new[] { "UserId" });
            DropIndex("Users.UserRoles", new[] { "RoleId" });
            DropIndex("Users.UserRoles", new[] { "UserId" });
            DropIndex("Users.RolePermissions", new[] { "RoleId" });
            DropIndex("Users.RolePermissions", new[] { "MenuActionId" });
            DropIndex("Users.Menus", new[] { "ParentId" });
            DropIndex("Users.MenuActions", new[] { "ActionId" });
            DropIndex("Users.MenuActions", new[] { "MenuId" });
            DropTable("Hotel.RoomTypes");
            DropTable("Hotel.Rooms");
            DropTable("Hotel.HotelTypes");
            DropTable("Hotel.Hotels");
            DropTable("Hotel.Floors");
            DropTable("Configurations.Cities");
            DropTable("Users.UserLogins");
            DropTable("Users.UserClaims");
            DropTable("Users.Users");
            DropTable("Users.UserRoles");
            DropTable("Users.Roles");
            DropTable("Users.RolePermissions");
            DropTable("Users.Menus");
            DropTable("Users.MenuActions");
            DropTable("Users.Actions");
        }
    }
}
