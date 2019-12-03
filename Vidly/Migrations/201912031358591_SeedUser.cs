namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7f1e0113-a22c-4cf9-a227-44e6a6b308b8', N'Admin@domain.com', 0, N'AMQvR4e4M141CJoxe151oYJfaKJRX8r3/m5qOoamAvaIs43iQXPjdp53RBaDBxgeZw==', N'2e417386-6ae5-4aa6-83ca-f7e98f5ff55a', NULL, 0, 0, NULL, 1, 0, N'Admin@domain.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b0b5a012-c034-476e-85f3-2cfb4d81f895', N'geust@domain.com', 0, N'AIwLmx8I3WAEDX5wlz3QjBxcaCilFtRfmZyYXqde5P10+fBC4NbLdFG6nqpf1qy47Q==', N'204820d5-d9d5-446f-98cc-c0d838d3a4dd', NULL, 0, 0, NULL, 1, 0, N'geust@domain.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9c5eac69-3b37-4b0a-8d6a-5a895d58b708', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7f1e0113-a22c-4cf9-a227-44e6a6b308b8', N'9c5eac69-3b37-4b0a-8d6a-5a895d58b708')

                ");
        }
        
        public override void Down()
        {
        }
    }
}
