namespace Core.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appliedfmgtoapplicantrequest : DbMigration
    {
        public override void Up()
        {
            AddColumn("DIG.ApplicantFarmRequest", "F_MIG", c => c.Int());
            AddColumn("cms.Request_ShipmentInfo", "F_MIG", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("cms.Request_ShipmentInfo", "F_MIG");
            DropColumn("DIG.ApplicantFarmRequest", "F_MIG");
        }
    }
}
