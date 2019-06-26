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
    public class LeaveTypeService : ILeaveTypeService
    {
        private readonly ILeaveTypeRepository iLeaveTypeRepository;

        public LeaveTypeService() { }
        public LeaveTypeService(ILeaveTypeRepository _iLeaveTypeRepository)
        {
            iLeaveTypeRepository = _iLeaveTypeRepository;
        }

        public bool Delete(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return false;
            }
            else
            {
                return iLeaveTypeRepository.Delete(id);
            }
        }

        public List<LeaveType> Get()
        {
            return iLeaveTypeRepository.Get();
        }

        public LeaveType Get(int id)
        {
            return iLeaveTypeRepository.Get(id);
        }

        public List<LeaveType> GetSearch(string values)
        {
            return iLeaveTypeRepository.GetSearch(values);
        }

        public bool Insert(LeaveTypeVM leaveTypeVM)
        {
            if (string.IsNullOrWhiteSpace(leaveTypeVM.Name)||
                string.IsNullOrWhiteSpace(leaveTypeVM.Duration.ToString())||
                string.IsNullOrWhiteSpace(leaveTypeVM.Note))
            {
                return false;
            }
            else
            {
                return iLeaveTypeRepository.Insert(leaveTypeVM);
            }
        }

        public bool Update(int id, LeaveTypeVM leaveTypeVM)
        {
            if (string.IsNullOrWhiteSpace(leaveTypeVM.Name) ||
                string.IsNullOrWhiteSpace(leaveTypeVM.Duration.ToString()) ||
                string.IsNullOrWhiteSpace(leaveTypeVM.Note))
            {
                return false;
            }
            else
            {
                return iLeaveTypeRepository.Update(id, leaveTypeVM);
            }
        }
    }
}
