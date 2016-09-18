namespace WebApp.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pizzas",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 128),
                    Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Description = c.String(nullable: false, maxLength: 512),
                    FileKey = c.String(maxLength: 128),
                    CreatedAt = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Pizzas");
        }
    }
}