namespace Course_Framework.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class BS_Course_AddColumn_Active : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BS_Course", "Active", c => c.Boolean(nullable: false, defaultValue: true));
        }

        public override void Down()
        {
            DropColumn("dbo.BS_Course", "Active");
        }
    }
}
