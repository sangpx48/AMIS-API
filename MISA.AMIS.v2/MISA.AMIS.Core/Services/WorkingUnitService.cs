
using MISA.AMIS.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MISA.AMIS.Core.Models;
using MISA.AMIS.Core.Exceptions;
using System.Text.RegularExpressions;

namespace MISA.AMIS.Core.Services
{
    public class WorkingUnitService : BaseService<WorkingUnit>, IWorkingUnitService
    {
        private readonly IBaseRepository<WorkingUnit> repository;

        public WorkingUnitService(IBaseRepository<WorkingUnit> repository) : base(repository)
        {
            this.repository = repository;
        }

        //Ghi de Valdate tu cha
        protected override bool ValidateObject(WorkingUnit workingUnit)
        {

            //Check trống 
            if (string.IsNullOrEmpty(workingUnit.WorkingUnitName))
            {
                IsValid = false;
                ErrorValidateMsgs.Add("Tên Phòng Ban không được để trống.");
            }

            if (string.IsNullOrEmpty(workingUnit.WorkingUnitCode))
            {
                IsValid = false;
                ErrorValidateMsgs.Add("Mã Phòng Ban không được để trống.");
            }

            return IsValid;
        }


    }
}
