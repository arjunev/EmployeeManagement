using EmployeeManagement.Application.Contracts;
using EmployeeManagement.Application.Models;
using EmployeeManagement.DataAccess.Contracts;
using EmployeeManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<EmployeeDto> GetEmployees()
        {
            var getEmployees = _employeeRepository.GetEmployees();
            var employee = MapToEmployeesDto(getEmployees);
            return employee;
        }
        private IEnumerable<EmployeeDto> MapToEmployeesDto(IEnumerable<EmployeeData> employeeData)
        {
            var employeeDtos = new List<EmployeeDto>();
            foreach (var employee in employeeData)
            {
                var employeeDto = new EmployeeDto()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Department = employee.Department
                };
                employeeDtos.Add(employeeDto);
            }
            return employeeDtos;
        }

        public EmployeeDto GetEmployeeById(int Id)
        {
            var getEmployeesById = _employeeRepository.GetEmployeeById(Id);
            return (MapToEmployeeDto(getEmployeesById));
        }

        private EmployeeDto MapToEmployeeDto(EmployeeData employee)
        {
            var employeeDto = new EmployeeDto()
            {
                Id = employee.Id,
                Name = employee.Name,
                Department = employee.Department,
                Age = employee.Age,
                Address = employee.Address
            };
            return employeeDto;
        }

        public bool InsertEmployee(EmployeeDto employee)
        {
            try
            {

                var insertEmployee = _employeeRepository.InsertEmployee(MapToEmployeeInsert(employee));
                return insertEmployee;
            }
            catch (Exception)
            {
                throw;
            }

        }

        private EmployeeData MapToEmployeeInsert(EmployeeDto insertEmployee)
        {
            var insertDto = new EmployeeData()
            {
                Id = insertEmployee.Id,
                Name = insertEmployee.Name,
                Department = insertEmployee.Department,
                Age = insertEmployee.Age,
                Address = insertEmployee.Address
            };
            return insertDto;
        }

        public bool UpdateEmployee(EmployeeDto employee)
        {
            try
            {

                var updateEmployee = _employeeRepository.UpdateEmployee(MapToEmployeeUpdate(employee));
                return updateEmployee;
            }
            catch(Exception)
            {
                 throw;
            }

        }
        private EmployeeData MapToEmployeeUpdate(EmployeeDto updateEmployee)
        {
            var employeeDto = new EmployeeData()
            {
                Id = updateEmployee.Id,
                Name = updateEmployee.Name,
                Department = updateEmployee.Department,
                Age = updateEmployee.Age,
                Address = updateEmployee.Address
            };
            return employeeDto;
        }
        public bool DeleteEmployee(int Id)
         {
            try
            {
                var deleteEmployee = _employeeRepository.DeleteEmployee(Id);
                return deleteEmployee;
            }
            catch(Exception)
            {
                throw;
            }

         }

    }
}
