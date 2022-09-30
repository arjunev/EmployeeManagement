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
            /// get employees by calling GetEmployees() in IEmployeeService and store it in a variable and Map that variable to EmployeeDetailedViewModel. 
            /// 
            try
            {
               var getEmployee = _employeeService.GetEmployees();
               // var employeeGet = (MapToGetEmployee(getEmployee));
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
        //Create Employee Insert, Update and Delete Endpoint here
        [HttpPost]
        [Route("insert")]
        public IActionResult InsertEmployee([FromBody] EmployeeDto employee)
        {
            try
            {
                var insertEmployee = _employeeService.InsertEmployee(employee);
                var employeeInsert = ( MapToEmployeeInsert(insertEmployee));
                return Ok(employeeInsert);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public IActionResult UpdateEmployee([FromBody] EmployeeData employee)
        {
            try
            {
                var employeeUpdate = _employeeService.UpdateEmployee(employee);
                
                return Ok(MapToEmployeeUpdate(employeeUpdate));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteEmployee([FromRoute] int id)
        {
            try
            {
                var deleteEmployee = _employeeService.DeleteEmployee(id);
                return Ok(deleteEmployee);
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
        private EmployeeDetailedViewModel MapToEmployeeInsert(EmployeeDto employee)
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
        private EmployeeDetailedViewModel MapToEmployeeUpdate(EmployeeDto employee)
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
       /* private EmployeeDetailedViewModel MapToEmployeeDelete(EmployeeDto employee)
        {
            var employeeDetail = new EmployeeDetailedViewModel();
            {
                employeeDetail.Id = employee.Id;
                employeeDetail.Name = employee.Name;
                employeeDetail.Department = employee.Department;
                employeeDetail.Age = employee.Age;
                employeeDetail.Address = employee.Address;
            }
            return employeeDetail;*/
        
    }
}
