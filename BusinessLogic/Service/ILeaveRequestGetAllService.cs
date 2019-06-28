using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public interface ILeaveRequestGetAllService
    {
        List<LeaveRequest> GetAllList();
        LeaveRequest Get(int id);
        List<LeaveRequest> GetSearch(string values);
        bool Delete(int id);
    }
}
