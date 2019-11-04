namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMoviesTable : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into Movies (Name,GenreId) Values ('Black Panther',2)");
            Sql("Insert Into Movies (Name,GenreId) Values ('A Star Is Born',4)");
            Sql("Insert Into Movies (Name,GenreId) Values ('The Favourite',1)");
            Sql("Insert Into Movies (Name,GenreId) Values ('Widows',4)");
            Sql("Insert Into Movies (Name,GenreId) Values ('The Lion King',3)");
        }
        
        public override void Down()
        {
        }
    }
}
