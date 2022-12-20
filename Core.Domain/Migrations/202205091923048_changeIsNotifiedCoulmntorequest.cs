namespace Core.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeIsNotifiedCoulmntorequest : DbMigration
    {
        public override void Up()
        {
            AddColumn("req.requests", "IfNotified", c => c.Boolean());
            DropColumn("req.requests", "IsNotified");
        }
        
        public override void Down()
        {
            AddColumn("req.requests", "IsNotified", c => c.Boolean());
            DropColumn("req.requests", "IfNotified");
        }
    }
}
