using EmployeeManagement.UI.Models;
using EmployeeManagement.UI.Models.Provider;
using EmployeeManagement.UI.Providers.Contracts;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace EmployeeManagement.UI.Providers.ApiClients
{
    public class EmployeeApiClient : IEmployeeApiClient
    {
        private readonly HttpClient _httpClient;

        public EmployeeApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IEnumerable<EmployeeViewModel> GetAllEmployee()
        {
            using var response = _httpClient.GetAsync("https://localhost:5001/api/employee/getall").Result;
            var employee = JsonConvert.DeserializeObject<IEnumerable<EmployeeViewModel>>
                           (response.Content.ReadAsStringAsync().Result);
            return employee;

        }

        public EmployeeDetailedViewModel GetEmployeeById(int Id)
        {
           
            using var response = _httpClient.GetAsync("https://localhost:5001/api/employee/" + Id).Result;
            var employee = JsonConvert.DeserializeObject<EmployeeDetailedViewModel>
                           (response.Content.ReadAsStringAsync().Result);
            return employee;



        }
    }
}
