using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ViewModels
{
    public class LeaveRequestVM
    {
        public int Id { get; set; }
        public DateTimeOffset Request_Date { get; set; }
        public DateTimeOffset From_Date { get; set; }
        public DateTimeOffset End_Date { get; set; }
        public int Employee_Id { get; set; }
        public string Attachment { get; set; }
        public string Reason { get; set; }
        public int LeaveType_Id { get; set; }
        public int Manager_Id { get; set; }
        public string Status { get; set; }
        public LeaveRequestVM() { }

        public LeaveRequestVM(DateTimeOffset request_date, DateTimeOffset from_date, DateTimeOffset end_date, int employee_id,
            string attachment, string reason, int leave_type_id, int manager_id, string status)
        {
            this.Request_Date = request_date;
            this.From_Date = from_date;
            this.End_Date = end_date;
            this.Employee_Id = employee_id;
            this.Attachment = attachment;
            this.Reason = reason;
            this.LeaveType_Id = leave_type_id;
            this.Manager_Id = manager_id;
            this.Status = status;
        }

        public void Update(int id, DateTimeOffset request_date, DateTimeOffset from_date, DateTimeOffset end_date, int employee_id,
            string attachment, string reason, int leave_type_id, int manager_id, string status)
        {
            this.Id = id;
            this.Request_Date = request_date;
            this.From_Date = from_date;
            this.End_Date = end_date;
            this.Employee_Id = employee_id;
            this.Attachment = attachment;
            this.Reason = reason;
            this.LeaveType_Id = leave_type_id;
            this.Manager_Id = manager_id;
            this.Status = status;
        }
    }
}
