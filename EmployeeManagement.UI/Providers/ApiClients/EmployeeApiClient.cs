using EmployeeManagement.UI.Models;
using EmployeeManagement.UI.Models.Provider;
using EmployeeManagement.UI.Providers.Contracts;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

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

        public bool InsertEmployee(EmployeeDetailedViewModel employee)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
            using (var response = _httpClient.PostAsync("https://localhost:5001/api/employee/insert", stringContent).Result)
            {
                response.Content.ReadAsStringAsync();
                return true;
            };
        }

        public bool UpdateEmployee(EmployeeDetailedViewModel employee)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
            using (var response = _httpClient.PutAsync("https://localhost:5001/api/employee/update", stringContent).Result)
            {
                response.Content.ReadAsStringAsync();
                return true;
            };
        }

        public bool DeleteEmployee(int Id)
        {
            new StringContent(JsonConvert.SerializeObject(Id));
            using (var response = _httpClient.DeleteAsync("https://localhost:5001/api/employee/" + Id ).Result)
            {
                response.Content.ReadAsStringAsync();
                return true;
            };
        }
    }

}
