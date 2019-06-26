using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ViewModels
{
    public class EmployeeVM
    {
        public string Name { get; set; }
        public int Employee_Id { get; set; }
        public int Manager_Id { get; set; }
        public string Gender { get; set; }
        public string Religion { get; set; }
        public string MaritalStatus { get; set; }
        public int Role_Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public EmployeeVM() { }

        public EmployeeVM(string name, int employee_id, int manager_id, string gender, string religion, string maritalStatus,
            int role_id, string email, string password)
        {
            this.Name = name;
            this.Employee_Id = employee_id;
            this.Manager_Id = manager_id;
            this.Gender = gender;
            this.Religion = religion;
            this.MaritalStatus = maritalStatus;
            this.Role_Id = role_id;
            this.Email = email;
            this.Password = password;
        }
    }
}
