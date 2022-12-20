namespace Core.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIsNotifiedCoulmntorequest : DbMigration
    {
        public override void Up()
        {
            AddColumn("req.requests", "IsNotified", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("req.requests", "IsNotified");
        }
    }
}
