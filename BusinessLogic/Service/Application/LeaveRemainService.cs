using Common.Repository;
using DataAccess.Models;
using DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service.Application
{
    public class LeaveRemainService : ILeaveRemainService
    {
        private readonly ILeaveRemainRepository iLeaveRemainRepository;

        public LeaveRemainService() { }
        public LeaveRemainService(ILeaveRemainRepository _iLeaveRemainRepository)
        {
            iLeaveRemainRepository = _iLeaveRemainRepository;
        }

        public bool Delete(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return false;
            }
            else
            {
                return iLeaveRemainRepository.Delete(id);
            }
        }

        public List<LeaveRemain> Get()
        {
            return iLeaveRemainRepository.Get();
        }

        public LeaveRemain Get(int id)
        {
            return iLeaveRemainRepository.Get(id);
        }

        public List<LeaveRemain> GetSearch(string values)
        {
            return iLeaveRemainRepository.GetSearch(values);
        }

        public bool Insert(LeaveRemainVM leaveRemainVM)
        {
            if (string.IsNullOrWhiteSpace(leaveRemainVM.Duration.ToString()) ||
                string.IsNullOrWhiteSpace(leaveRemainVM.Employee_Id.ToString()))
            {
                return false;
            }
            else
            {
                return iLeaveRemainRepository.Insert(leaveRemainVM);
            }
        }

        public bool Update(int id, LeaveRemainVM leaveRemainVM)
        {
            if (string.IsNullOrWhiteSpace(leaveRemainVM.Duration.ToString()) ||
                string.IsNullOrWhiteSpace(leaveRemainVM.Employee_Id.ToString()))
            {
                return false;
            }
            else
            {
                return iLeaveRemainRepository.Update(id, leaveRemainVM);
            }
        }
    }
}
