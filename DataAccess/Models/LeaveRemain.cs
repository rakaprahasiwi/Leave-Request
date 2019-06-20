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
    [Table("TB_T_LeaveRemain")]
    public class LeaveRemain : BaseModel
    {
        public int Duration { get; set; }
        public int Employee_Id { get; set; }

        [ForeignKey("LeaveRequest")]
        public int LeaveRequest_Id { get; set; }
        public LeaveRequest LeaveRequest { get; set; }

        public LeaveRemain() { }

        public LeaveRemain(LeaveRemainVM leaveRemainVM)
        {
            this.Duration = leaveRemainVM.Duration;
            this.Employee_Id = leaveRemainVM.Employee_Id;
            this.CreateDate = DateTimeOffset.Now.ToLocalTime();
        }

        public void Update(LeaveRemainVM leaveRemainVM)
        {
            this.Duration = leaveRemainVM.Duration;
            this.Employee_Id = leaveRemainVM.Employee_Id;
            this.UpdateDate = DateTimeOffset.Now.ToLocalTime();
        }

        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.ToLocalTime();
        }
    }
}
