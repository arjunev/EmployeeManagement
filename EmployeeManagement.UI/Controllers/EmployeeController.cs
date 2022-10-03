﻿using EmployeeManagement.Application.Contracts;
using EmployeeManagement.UI.Models;
using EmployeeManagement.UI.Providers.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.UI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeApiClient _employeeApiClient;

        public EmployeeController(IEmployeeApiClient employeeApiClient)
        {
            this._employeeApiClient = employeeApiClient;
        }

        public IActionResult Index()
        {
            try
            {
                var employees = _employeeApiClient.GetAllEmployee();

/*                //Dummy Data Need to Replace with employees object
                var employeeViewModels = new List<EmployeeViewModel>()*/

                return View(employees);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IActionResult GetElementById(int Id)
        {
            try
            {
                var employees = _employeeApiClient.GetEmployeeById(Id);
                return View(employees);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public IActionResult InsertEmployee(EmployeeDetailedViewModel employee)
        {
            try
            {
                var employees = _employeeApiClient.InsertEmployee(employee);
                return View(employees);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IActionResult DeleteEmployee(int Id)
        {
            try
            {
                var employees = _employeeApiClient.DeleteEmployee(Id);
                return View(employees);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
