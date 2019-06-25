using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.ViewModels;
using Common.Repository;

namespace BusinessLogic.Service.Application
{
    public class CalendarService : ICalendarService
    {
        private readonly ICalendarRepository iCalendarRepository;

        public CalendarService() { }
        public CalendarService(ICalendarRepository _iCalendarRepository)
        {
            iCalendarRepository = _iCalendarRepository;
        }
        public bool Delete(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return false;
            }
            else
            {
                return iCalendarRepository.Delete(id);
            }
        }

        public List<Calendar> Get()
        {
            return iCalendarRepository.Get();
        }

        public Calendar Get(int id)
        {
            return iCalendarRepository.Get(id);
        }

        public List<Calendar> GetSearch(string values)
        {
            return iCalendarRepository.GetSearch(values);
        }

        public bool Insert(CalendarVM calendarVM)
        {
            if (string.IsNullOrWhiteSpace(calendarVM.Name.ToString()) ||
                string.IsNullOrWhiteSpace(calendarVM.National_Date.ToString()))
            {
                return false;
            }
            else
            {
                return iCalendarRepository.Insert(calendarVM);
            }
        }

        public bool Update(int id, CalendarVM calendarVM)
        {
            if (string.IsNullOrWhiteSpace(calendarVM.Name.ToString()) ||
                string.IsNullOrWhiteSpace(calendarVM.National_Date.ToString()))
            {
                return false;
            }
            else
            {
                return iCalendarRepository.Update(id, calendarVM);
            }
        }
    }
}
