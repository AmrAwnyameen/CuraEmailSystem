namespace Core.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Inbox.MailType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Inbox.MailInbox",
                c => new
                    {
                        FromUserId = c.String(maxLength: 128),
                        ToUserId = c.String(maxLength: 128),
                        Id = c.Int(nullable: false, identity: true),
                        MailTypeId = c.Int(nullable: false),
                        Date = c.DateTime(),
                        Content = c.String(),
                        Subject = c.String(maxLength: 100),
                        IsDeleted = c.Boolean(),
                        IsRead = c.Boolean(),
                        IsStarred = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.FromUserId)
                .ForeignKey("dbo.AspNetUsers", t => t.ToUserId)
                .ForeignKey("Inbox.MailType", t => t.MailTypeId, cascadeDelete: true)
                .Index(t => t.FromUserId, name: "IX_FromUser")
                .Index(t => t.ToUserId, name: "IX_ToUser")
                .Index(t => t.MailTypeId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        RecoveryEmail = c.String(),
                        verified = c.Boolean(nullable: false),
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
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "Inbox.TrashInboxes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeleteBy = c.String(maxLength: 128),
                        InboxId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Inbox.MailInbox", t => t.InboxId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.DeleteBy)
                .Index(t => t.DeleteBy, name: "IX_TashUser")
                .Index(t => t.InboxId);
            
            CreateTable(
                "Inbox.MailAttachment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AttachmentId = c.Int(nullable: false),
                        InboxId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Inbox.Attachment", t => t.AttachmentId, cascadeDelete: true)
                .ForeignKey("Inbox.MailInbox", t => t.InboxId, cascadeDelete: true)
                .Index(t => t.AttachmentId)
                .Index(t => t.InboxId);
            
            CreateTable(
                "Inbox.Attachment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Path = c.String(),
                        Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Logging.RequestsLogger",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Action = c.String(),
                        UserId = c.String(),
                        Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("Inbox.MailInbox", "MailTypeId", "Inbox.MailType");
            DropForeignKey("Inbox.MailAttachment", "InboxId", "Inbox.MailInbox");
            DropForeignKey("Inbox.MailAttachment", "AttachmentId", "Inbox.Attachment");
            DropForeignKey("Inbox.TrashInboxes", "DeleteBy", "dbo.AspNetUsers");
            DropForeignKey("Inbox.TrashInboxes", "InboxId", "Inbox.MailInbox");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("Inbox.MailInbox", "ToUserId", "dbo.AspNetUsers");
            DropForeignKey("Inbox.MailInbox", "FromUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("Inbox.MailAttachment", new[] { "InboxId" });
            DropIndex("Inbox.MailAttachment", new[] { "AttachmentId" });
            DropIndex("Inbox.TrashInboxes", new[] { "InboxId" });
            DropIndex("Inbox.TrashInboxes", "IX_TashUser");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("Inbox.MailInbox", new[] { "MailTypeId" });
            DropIndex("Inbox.MailInbox", "IX_ToUser");
            DropIndex("Inbox.MailInbox", "IX_FromUser");
            DropTable("dbo.AspNetRoles");
            DropTable("Logging.RequestsLogger");
            DropTable("Inbox.Attachment");
            DropTable("Inbox.MailAttachment");
            DropTable("Inbox.TrashInboxes");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("Inbox.MailInbox");
            DropTable("Inbox.MailType");
        }
    }
}
