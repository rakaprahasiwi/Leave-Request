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
    [Table("TB_M_Calendar")]
    public class Calendar : BaseModel
    {
        public string Name { get; set; }
        public DateTimeOffset National_Date { get; set; }

        public Calendar() { }
        public Calendar(CalendarVM calendarVM)
        {
            this.Name = calendarVM.Name;
            this.National_Date = calendarVM.National_Date;
            this.CreateDate = DateTimeOffset.Now.ToLocalTime();
        }

        public void Update(CalendarVM calendarVM)
        {
            this.Name = calendarVM.Name;
            this.National_Date = calendarVM.National_Date;
            this.UpdateDate = DateTimeOffset.Now.ToLocalTime();
        }

        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.ToLocalTime();
        }
    }
}
