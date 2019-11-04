namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditInMemberShipTable : DbMigration
    {
        public override void Up()
        {
            Sql("Update MemberShipTypes set Name='Pay as you Go' where Id=1");
            Sql("Update MemberShipTypes set Name='Monthly' where Id=2");
            Sql("Update MemberShipTypes set Name='Quartile' where Id=3");
            Sql("Update MemberShipTypes set Name='annual' where Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
