using DataAccess.Models;
using DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public interface ICalendarService
    {
        List<Calendar> Get();
        List<Calendar> GetSearch(string values);
        Calendar Get(int id);
        bool Insert(CalendarVM calendarVM);
        bool Update(int id, CalendarVM calendarVM);
        bool Delete(int id);
    }
}
