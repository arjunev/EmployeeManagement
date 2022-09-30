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

        public EmployeeDto GetEmployeeById(int Id)
        {
            var getEmployeesById = _employeeRepository.GetEmployeeById(Id);
            return (MapToEmployeeDto(getEmployeesById));
        }

        public EmployeeDto InsertEmployee(EmployeeDto employee)
        {
            try
            {
                var employeeData = new EmployeeData()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Department = employee.Department,
                    Age = employee.Age,
                    Address = employee.Address
                };
                var insertEmployee = _employeeRepository.InsertEmployee(employeeData);
                var empployeeInsert = (MapToEmployeeInsert(insertEmployee));
                return empployeeInsert;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public EmployeeDto UpdateEmployee(EmployeeData employee)
        {
            try
            {
                /*var employeeData = new EmployeeData()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Department = employee.Department,
                    Age = employee.Age,
                    Address = employee.Address
                };*/
                var updateEmployee = _employeeRepository.UpdateEmployee(employee);
                var empployeeUpdate = (MapToEmployeeUpdate(updateEmployee));
                return empployeeUpdate;
            }
            catch(Exception)
            {
                throw;
            }

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
        private IEnumerable<EmployeeDto> MapToEmployeesDto(IEnumerable<EmployeeData> employeeData)
        {
            var employeeDtos = new List<EmployeeDto>();
            foreach (var employee in employeeData)
            {
                var employeeDto = new EmployeeDto()
                {
                    Id=employee.Id,
                    Name=employee.Name,
                    Department=employee.Department
                };
                employeeDtos.Add(employeeDto);
            }
            return employeeDtos;
        }

        private EmployeeDto MapToEmployeeDto(EmployeeData employee)
        {
            var employeeDto = new EmployeeDto()
            {
                Id =employee.Id,
                Name=employee.Name,
                Department=employee.Department,
                Age=employee.Age,
                Address=employee.Address
            };
            return employeeDto;
        }
        private EmployeeDto MapToEmployeeInsert(EmployeeData employee)
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
        private EmployeeDto MapToEmployeeUpdate(EmployeeData employee)
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
        /*private EmployeeDto MapToEmployeeDelete(int id)
        {
            var employeeDto = new EmployeeDto()
            {
                Id = employee.Id,
                Name = employee.Name,
                Department = employee.Department,
                Age = employee.Age,
                Address = employee.Address
            };
            return employeeDto;*/
        
    }
}
