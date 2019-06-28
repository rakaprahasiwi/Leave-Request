using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Repository;
using DataAccess.Models;

namespace BusinessLogic.Service.Application
{
    public class LeaveRequestEmployeeService : ILeaveRequestEmployeeService
    {
        private readonly ILeaveRequestEmployeeRepository iLeaveRequestEmployeeRepository;

        public LeaveRequestEmployeeService() { }
        public LeaveRequestEmployeeService(ILeaveRequestEmployeeRepository _iLeaveRequestEmployeeRepository)
        {
            iLeaveRequestEmployeeRepository = _iLeaveRequestEmployeeRepository;
        }

        public LeaveRequest GetEmployee()
        {
            return iLeaveRequestEmployeeRepository.GetEmployee();
        }
    }
}
