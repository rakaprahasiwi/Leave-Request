using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ViewModels
{
    public class LeaveTypeVM
    {
        public LeaveTypeVM() { }
        public LeaveTypeVM(string name, int duration, string note)
        {
            this.Name = name;
            this.Duration = duration;
            this.Note = note;
        }

        public void Update(int id, string name, int duration, string note)
        {
            this.Id = id;
            this.Name = name;
            this.Duration = duration;
            this.Note = note;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public string Note { get; set; }
    }
}
