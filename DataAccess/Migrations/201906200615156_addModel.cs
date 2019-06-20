namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_T_LeaveRemain",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Duration = c.Int(nullable: false),
                        Employee_Id = c.Int(nullable: false),
                        LeaveRequest_Id = c.Int(nullable: false),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TB_T_LeaveRequest", t => t.LeaveRequest_Id, cascadeDelete: true)
                .Index(t => t.LeaveRequest_Id);
            
            CreateTable(
                "dbo.TB_T_LeaveRequest",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        From_Date = c.DateTimeOffset(nullable: false, precision: 7),
                        Request_Date = c.DateTimeOffset(nullable: false, precision: 7),
                        End_Date = c.DateTimeOffset(nullable: false, precision: 7),
                        Reason = c.String(),
                        Attachment = c.String(),
                        Employee_Id = c.Int(nullable: false),
                        Manager_Id = c.Int(nullable: false),
                        LeaveTypes_Id = c.Int(nullable: false),
                        StatusTypeParameter_Id = c.Int(nullable: false),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TB_M_LeaveTypes", t => t.LeaveTypes_Id, cascadeDelete: true)
                .ForeignKey("dbo.TB_M_StatusTypeParameter", t => t.StatusTypeParameter_Id, cascadeDelete: true)
                .Index(t => t.LeaveTypes_Id)
                .Index(t => t.StatusTypeParameter_Id);
            
            CreateTable(
                "dbo.TB_M_LeaveTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.Int(nullable: false),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TB_M_StatusTypeParameter",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_T_LeaveRemain", "LeaveRequest_Id", "dbo.TB_T_LeaveRequest");
            DropForeignKey("dbo.TB_T_LeaveRequest", "StatusTypeParameter_Id", "dbo.TB_M_StatusTypeParameter");
            DropForeignKey("dbo.TB_T_LeaveRequest", "LeaveTypes_Id", "dbo.TB_M_LeaveTypes");
            DropIndex("dbo.TB_T_LeaveRequest", new[] { "StatusTypeParameter_Id" });
            DropIndex("dbo.TB_T_LeaveRequest", new[] { "LeaveTypes_Id" });
            DropIndex("dbo.TB_T_LeaveRemain", new[] { "LeaveRequest_Id" });
            DropTable("dbo.TB_M_StatusTypeParameter");
            DropTable("dbo.TB_M_LeaveTypes");
            DropTable("dbo.TB_T_LeaveRequest");
            DropTable("dbo.TB_T_LeaveRemain");
        }
    }
}
