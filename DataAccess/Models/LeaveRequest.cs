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
        public DateTimeOffset Request_Date { get; set; }
        public DateTimeOffset From_Date { get; set; }
        public DateTimeOffset End_Date { get; set; }
        public int Employee_Id { get; set; }
        public string Attachment { get; set; }
        public string Reason { get; set; }
        public int Manager_Id { get; set; }
        public string Status { get; set; }

        [ForeignKey("LeaveType")]
        public int LeaveType_Id { get; set; }
        public LeaveType LeaveType { get; set; }

        public LeaveRequest() { }

        public LeaveRequest(LeaveRequestVM leaveRequestVM)
        {
            this.Request_Date = leaveRequestVM.Request_Date;
            this.From_Date = leaveRequestVM.From_Date;
            this.End_Date = leaveRequestVM.End_Date;
            this.Employee_Id = leaveRequestVM.Employee_Id;
            this.Attachment = leaveRequestVM.Attachment;
            this.Reason = leaveRequestVM.Reason;
            this.Manager_Id = leaveRequestVM.Manager_Id;
            this.Status = leaveRequestVM.Status;
            this.CreateDate = DateTimeOffset.Now.ToLocalTime();
        }

        public void Update(LeaveRequestVM leaveRequestVM)
        {
            this.Request_Date = leaveRequestVM.Request_Date;
            this.From_Date = leaveRequestVM.From_Date;
            this.End_Date = leaveRequestVM.End_Date;
            this.Employee_Id = leaveRequestVM.Employee_Id;
            this.Attachment = leaveRequestVM.Attachment;
            this.Reason = leaveRequestVM.Reason;
            this.Manager_Id = leaveRequestVM.Manager_Id;
            this.Status = leaveRequestVM.Status;
            this.UpdateDate = DateTimeOffset.Now.ToLocalTime();
        }

        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.ToLocalTime();
        }
    }
}
