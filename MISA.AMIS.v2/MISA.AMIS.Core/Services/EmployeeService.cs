using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MISA.AMIS.Core.Exceptions;
using MISA.AMIS.Core.Interfaces;
using MISA.AMIS.Core.Models;
using MISA.AMIS.Core.Services;

namespace MISA.AMIS.Core.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        IEmployeeRepository employeeRepository;


        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }


        //Ghi de Valdate tu cha
        protected override bool ValidateObject(Employee employee)
        {
            //Check trùng mã:
            if (employeeRepository.CheckEmployeeCodeExist(employee.EmployeeCode) == true)
            {
                IsValid = false;
                ErrorValidateMsgs.Add("Mã Nhân Viên đã tồn tại trong hệ thống.");
            }

            //Check trống 
            if (string.IsNullOrEmpty(employee.EmployeeName))
            {
                IsValid = false;
                ErrorValidateMsgs.Add("Tên Nhân Viên không được để trống.");
            }

            if (string.IsNullOrEmpty(employee.EmployeeCode))
            {
                IsValid = false;
                ErrorValidateMsgs.Add("Mã Nhân Viên không được để trống.");
            }

            //Check ngày sinh không được lớn hơn ngày hiện tại
            if (employee.DateOfBirth > DateTime.Now)
            {
                IsValid = false;
                ErrorValidateMsgs.Add("Ngày sinh không được lớn hơn ngày hiện tại.");
            }

            if (!ValidateUsingRegex(employee.Email))
            {
                IsValid = false;
                ErrorValidateMsgs.Add("Email không đúng với định dạng.");
            }
            return IsValid;
        }

        public bool ValidateUsingRegex(string emailAddress)
        {
            var pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
            var regex = new Regex(pattern);
            return regex.IsMatch(emailAddress);
        }

    }
}
