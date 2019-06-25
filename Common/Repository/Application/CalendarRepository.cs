using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.ViewModels;
using DataAccess.Context;
using System.Data.Entity;

namespace Common.Repository.Application
{
    public class CalendarRepository : ICalendarRepository
    {
        MyContext myContext = new MyContext();
        bool status = false;

        public bool Delete(int id)
        {
            var get = Get(id);
            if (get != null)
            {
                get.Delete();
                myContext.Entry(get).State = EntityState.Modified;
                myContext.SaveChanges();
                status = true;
            }
            return status;
        }

        public List<Calendar> Get()
        {
            var get = myContext.Calendars.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public Calendar Get(int id)
        {
            var get = myContext.Calendars.SingleOrDefault(x => x.Id == id);
            return get;
        }

        public List<Calendar> GetSearch(string values)
        {
            var get = myContext.Calendars.Where(x => (x.Name.Contains(values) || x.Id.ToString().Contains(values)) && x.IsDelete == false).ToList();
            return get;
        }

        public bool Insert(CalendarVM calendarVM)
        {
            var push = new Calendar(calendarVM);
            myContext.Calendars.Add(push);
            var result = myContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(int id, CalendarVM calendarVM)
        {
            var get = Get(id);
            if (get != null)
            {
                get.Update(calendarVM);
                myContext.Entry(get).State = EntityState.Modified;
                var result = myContext.SaveChanges();
                return result > 0;
            }
            else
            {
                return false;
            }
        }
    }
}
