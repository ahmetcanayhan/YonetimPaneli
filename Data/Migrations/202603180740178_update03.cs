namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update03 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "CoverImageUrl", c => c.String());
            DropColumn("dbo.Posts", "CoverImgUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "CoverImgUrl", c => c.String());
            DropColumn("dbo.Posts", "CoverImageUrl");
        }
    }
}
