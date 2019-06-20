using Core.Base;
using DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    [Table("TB_T_LeaveRequest")]
    public class LeaveRequest : BaseModel
    {
        public DateTimeOffset From_Date { get; set; }
        public DateTimeOffset Request_Date { get; set; }
        public DateTimeOffset End_Date { get; set; }
        public string Reason { get; set; }
        public string Attachment { get; set; }
        public int Employee_Id { get; set; }
        public int Manager_Id { get; set; }

        [ForeignKey("LeaveTypes")]
        public int LeaveTypes_Id { get; set; }
        public LeaveTypes LeaveTypes { get; set; }
        [ForeignKey("StatusTypeParameter")]
        public int StatusTypeParameter_Id { get; set; }
        public StatusTypeParameter StatusTypeParameter { get; set; }

        public LeaveRequest() { }

        public LeaveRequest(LeaveRequestVM leaveRequestVM)
        {
            this.From_Date = leaveRequestVM.From_Date;
            this.Request_Date = leaveRequestVM.Request_Date;
            this.End_Date = leaveRequestVM.End_Date;
            this.Reason = leaveRequestVM.Reason;
            this.Attachment = leaveRequestVM.Attachment;
            this.Employee_Id = leaveRequestVM.Employee_Id;
            this.Manager_Id = leaveRequestVM.Manager_Id;
            this.CreateDate = DateTimeOffset.Now.ToLocalTime();
        }

        public void Update(int id, LeaveRequestVM leaveRequestVM)
        {
            this.Id = id;
            this.From_Date = leaveRequestVM.From_Date;
            this.Request_Date = leaveRequestVM.Request_Date;
            this.End_Date = leaveRequestVM.End_Date;
            this.Reason = leaveRequestVM.Reason;
            this.Attachment = leaveRequestVM.Attachment;
            this.Employee_Id = leaveRequestVM.Employee_Id;
            this.Manager_Id = leaveRequestVM.Manager_Id;
            this.UpdateDate = DateTimeOffset.Now.ToLocalTime();
        }

        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.ToLocalTime();
        }
    }
}
