namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateToGenraTable : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into Genres (GenreName) Values ('Comedy')");
            Sql("Insert Into Genres (GenreName) Values ('Action')");
            Sql("Insert Into Genres (GenreName) Values ('Family')");
            Sql("Insert Into Genres (GenreName) Values ('Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
