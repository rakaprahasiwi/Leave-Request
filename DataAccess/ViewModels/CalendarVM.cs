using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ViewModels
{
    public class CalendarVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset National_Date { get; set; }

        public CalendarVM() { }

        public CalendarVM(string name, DateTimeOffset national_date)
        {
            this.Name = name;
            this.National_Date = national_date;
        }

        public void Update(int id, string name, DateTimeOffset national_date)
        {
            this.Id = id;
            this.Name = name;
            this.National_Date = national_date;
        }
    }
}
