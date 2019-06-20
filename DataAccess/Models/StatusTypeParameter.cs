using Core.Base;
using DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    [Table("TB_M_StatusTypeParameter")]
    public class StatusTypeParameter : BaseModel
    {
        public string Name { get; set; }

        public StatusTypeParameter() { }
        public StatusTypeParameter(StatusTypeParameterVM statusTypeParameterVM)
        {
            this.Name = statusTypeParameterVM.Name;
            this.CreateDate = DateTimeOffset.Now.ToLocalTime();
        }

        public void Update(StatusTypeParameterVM statusTypeParameterVM)
        {
            this.Name = statusTypeParameterVM.Name;
            this.UpdateDate = DateTimeOffset.Now.ToLocalTime();
        }

        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.ToLocalTime();
        }
    }
}
