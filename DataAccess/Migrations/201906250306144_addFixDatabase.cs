namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFixDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_M_Calendar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        National_Date = c.DateTimeOffset(nullable: false, precision: 7),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TB_M_LeaveRemain",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Duration = c.Int(nullable: false),
                        Employee_Id = c.Int(nullable: false),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TB_T_LeaveRequest",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Request_Date = c.DateTimeOffset(nullable: false, precision: 7),
                        From_Date = c.DateTimeOffset(nullable: false, precision: 7),
                        End_Date = c.DateTimeOffset(nullable: false, precision: 7),
                        Employee_Id = c.Int(nullable: false),
                        Attachment = c.String(),
                        Reason = c.String(),
                        Manager_Id = c.Int(nullable: false),
                        Status = c.String(),
                        LeaveType_Id = c.Int(nullable: false),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TB_M_LeaveType", t => t.LeaveType_Id, cascadeDelete: true)
                .Index(t => t.LeaveType_Id);
            
            CreateTable(
                "dbo.TB_M_LeaveType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Duration = c.Int(nullable: false),
                        Note = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_T_LeaveRequest", "LeaveType_Id", "dbo.TB_M_LeaveType");
            DropIndex("dbo.TB_T_LeaveRequest", new[] { "LeaveType_Id" });
            DropTable("dbo.TB_M_LeaveType");
            DropTable("dbo.TB_T_LeaveRequest");
            DropTable("dbo.TB_M_LeaveRemain");
            DropTable("dbo.TB_M_Calendar");
        }
    }
}
