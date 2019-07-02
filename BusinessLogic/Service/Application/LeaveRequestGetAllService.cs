using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using Common.Repository;

namespace BusinessLogic.Service.Application
{
    public class LeaveRequestGetAllService : ILeaveRequestGetAllService
    {
        private readonly ILeaveRequestGetAllRepository iLeaveRequestGetAllRepository;

        public LeaveRequestGetAllService() { }
        public LeaveRequestGetAllService(ILeaveRequestGetAllRepository _iLeaveRequestGetAllRepository)
        {
            iLeaveRequestGetAllRepository = _iLeaveRequestGetAllRepository;
        }

        public bool Delete(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return false;
            }
            else
            {
                return iLeaveRequestGetAllRepository.Delete(id);
            }
        }

        public LeaveRequest Get(int id)
        {
            return iLeaveRequestGetAllRepository.Get(id);
        }

        public List<LeaveRequest> GetAllList()
        {
            return iLeaveRequestGetAllRepository.GetAllList();
        }

        public List<LeaveRequest> GetSearch(string values)
        {
            return iLeaveRequestGetAllRepository.GetSearch(values);
        }
    }
}
