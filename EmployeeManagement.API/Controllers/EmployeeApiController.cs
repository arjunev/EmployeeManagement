using EmployeeManagement.API.Models;
using EmployeeManagement.Application.Contracts;
using EmployeeManagement.Application.Models;
using EmployeeManagement.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeApiController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeApiController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }
        [HttpGet]
        [Route("getall")]
        public IActionResult GetEmployees()
        {
            try
            {
               var getEmployee = _employeeService.GetEmployees();
                return Ok(getEmployee);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetEmployeeById([FromRoute] int Id)
        {
            try
            {
                /// get employee by calling GetEmployeeById() in IEmployeeService and store it in a variable and Map that variable to EmployeeDetailedViewModel. 
                var getEmployeeById = _employeeService.GetEmployeeById(Id);
                return Ok (MapToEmployeeById(getEmployeeById)); 
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
        private EmployeeDetailedViewModel MapToEmployeeById(EmployeeDto employee)
        {
            var employeeDetail = new EmployeeDetailedViewModel();
            {
                employeeDetail.Id = employee.Id;
                employeeDetail.Name = employee.Name;
                employeeDetail.Department = employee.Department;
                employeeDetail.Age = employee.Age;
                employeeDetail.Address = employee.Address;
            }
            return employeeDetail;
        }
        [HttpPost]
        [Route("insert")]
        public IActionResult InsertEmployee([FromBody] EmployeeDetailedViewModel employee)
        {
            try
            {
                var insertEmployee = _employeeService.InsertEmployee(MapToEmployeeInsert(employee));
                if (insertEmployee)
                {
                    return Ok(insertEmployee);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
        private EmployeeDto MapToEmployeeInsert(EmployeeDetailedViewModel employee)
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
        [HttpPut]
        [Route("update")]
        public IActionResult UpdateEmployee([FromBody] EmployeeDetailedViewModel employee)
        {
            try
            {
                var updateEmployee = _employeeService.UpdateEmployee(MapToEmployeeUpdate(employee));
                if (updateEmployee)
                {
                    return Ok(updateEmployee);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update employee details");
                }
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
       private EmployeeDto MapToEmployeeUpdate(EmployeeDetailedViewModel employee)
        {
            var employeeDetail = new EmployeeDto();
            {
                employeeDetail.Id = employee.Id;
                employeeDetail.Name = employee.Name;
                employeeDetail.Department = employee.Department;
                employeeDetail.Age = employee.Age;
                employeeDetail.Address = employee.Address;
            }
            return employeeDetail;
        }
        [HttpDelete]
        [Route("{Id}")]
        public IActionResult DeleteEmployee([FromRoute] int Id)
        {
            try
            {
                var deleteEmployee = _employeeService.DeleteEmployee(Id);
                return Ok(deleteEmployee);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
    }
}
