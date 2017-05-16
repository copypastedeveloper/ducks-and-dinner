namespace DucksAndDinner.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingReservations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        NumberOfPeople = c.Int(nullable: false),
                        DuckIAmEating_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ducks", t => t.DuckIAmEating_Id)
                .Index(t => t.DuckIAmEating_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "DuckIAmEating_Id", "dbo.Ducks");
            DropIndex("dbo.Reservations", new[] { "DuckIAmEating_Id" });
            DropTable("dbo.Reservations");
        }
    }
}
