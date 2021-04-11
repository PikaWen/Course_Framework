namespace Course_Framework.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class BS_Student_AddColumn_Active : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SE_Student", "Active", c => c.Boolean(nullable: false, defaultValue: true));
        }

        public override void Down()
        {
            DropColumn("dbo.SE_Student", "Active");
        }
    }
}
