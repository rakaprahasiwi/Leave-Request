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
        public int LeaveTypes_Id { get; set; }
        public int Employee_Id { get; set; }
        public int StatusTypeParameter_Id { get; set; }
        public int Manager_Id { get; set; }
        public DateTimeOffset From_Date { get; set; }
        public DateTimeOffset Request_Date { get; set; }
        public DateTimeOffset End_Date { get; set; }
        public string Reason { get; set; }
        public string Attachment { get; set; }

        public LeaveRequestVM() { }

        public LeaveRequestVM(int leave_type_id, int employee_id, int status_type_parameter_id, int manager_id,
                              DateTime from_date, DateTime end_date, DateTime request_date,
                              string reason, string attachment)
        {
            this.LeaveTypes_Id = leave_type_id;
            this.Employee_Id = employee_id;
            this.StatusTypeParameter_Id = status_type_parameter_id;
            this.Manager_Id = manager_id;
            this.From_Date = from_date;
            this.Request_Date = request_date;
            this.End_Date = end_date;
            this.Reason = reason;
            this.Attachment = attachment;
        }

        public void Update(int id, int leave_type_id, int employee_id, int status_type_parameter_id, int manager_id,
                              DateTime from_date, DateTime end_date, DateTime request_date,
                              string reason, string attachment)
        {
            this.Id = id;
            this.LeaveTypes_Id = leave_type_id;
            this.Employee_Id = employee_id;
            this.StatusTypeParameter_Id = status_type_parameter_id;
            this.Manager_Id = manager_id;
            this.From_Date = from_date;
            this.Request_Date = request_date;
            this.End_Date = end_date;
            this.Reason = reason;
            this.Attachment = attachment;
        }
    }
}
