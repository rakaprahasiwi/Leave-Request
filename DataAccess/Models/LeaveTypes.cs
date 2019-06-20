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
    [Table("TB_M_LeaveTypes")]
    public class LeaveTypes : BaseModel
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public LeaveTypes() { }
        public LeaveTypes(LeaveTypesVM leaveTypesVM)
        {
            this.Name = leaveTypesVM.Name;
            this.Value = leaveTypesVM.Value;
            this.CreateDate = DateTimeOffset.Now.ToLocalTime();
        }

        public void Update(LeaveTypesVM leaveTypesVM)
        {
            this.Name = leaveTypesVM.Name;
            this.Value = leaveTypesVM.Value;
            this.UpdateDate = DateTimeOffset.Now.ToLocalTime();
        }

        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.ToLocalTime();
        }
    }
}
