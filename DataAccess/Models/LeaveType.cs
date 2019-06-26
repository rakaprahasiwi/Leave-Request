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
    [Table("TB_M_LeaveType")]
    public class LeaveType : BaseModel
    {
        public string Name { get; set; }
        public int Duration { get; set; }
        public string Note { get; set; }

        public LeaveType() { }
        public LeaveType(LeaveTypeVM leaveTypeVM)
        {
            this.Name = leaveTypeVM.Name;
            this.Duration = leaveTypeVM.Duration;
            this.Note = leaveTypeVM.Note;
            this.CreateDate = DateTimeOffset.Now.ToLocalTime();
        }

        public void Update(LeaveTypeVM leaveTypeVM)
        {
            this.Name = leaveTypeVM.Name;
            this.Duration = leaveTypeVM.Duration;
            this.Note = leaveTypeVM.Note;
            this.UpdateDate = DateTimeOffset.Now.ToLocalTime();
        }

        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.ToLocalTime();
        }
    }
}
