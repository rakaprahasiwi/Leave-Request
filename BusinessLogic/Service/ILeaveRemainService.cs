using DataAccess.Models;
using DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public interface ILeaveRemainService
    {
        List<LeaveRemain> Get();
        List<LeaveRemain> GetSearch(string values);
        LeaveRemain Get(int id);
        bool Insert(LeaveRemainVM leaveRemainVM);
        bool Update(int id, LeaveRemainVM leaveRemainVM);
        bool Delete(int id);
    }
}
